using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] CharacterController controllerPlayer;
    [SerializeField] GameObject head;
    [SerializeField] GameObject groundDetector;
    [SerializeField] GameObject ray;
    [SerializeField] LayerMask maskCheck;
    [SerializeField] GameObject UIPlayerMenu;

    GameManager gameManager;
    GameObject camera;

    [SerializeField] float speedMove = 2.0f;
    [SerializeField] float speedSprint = 5.0f;
    [SerializeField] float forseJump = 2.0f;
    [SerializeField] float speedRotation = 2.0f;
    [SerializeField] float gravy = -19.8f;
    [SerializeField] float rayDistance = 2.5f;

    Vector3 move;
    private Vector3 Up;
    float xRotation = 0f;

    bool isGround;
    bool isPlayerMenuActive = false;

    private void Start()
    {
        camera = GameObject.Find("Camera");
        camera.transform.position = head.transform.position + Vector3.forward * 0.2f + Vector3.up * 0.2f;
        camera.transform.SetParent(head.transform);

        gameManager = GameManager.instance;

        gameManager.SetCursor(false);
        UIPlayerMenu.SetActive(false);
    }

    private void Update()
    {
        if (!isPlayerMenuActive)
        {
            Action();
        }
        OpenPlayerMenu();
    }

    private void FixedUpdate()
    {
        if (!isPlayerMenuActive)
        {
            Moving();
            Looking();
            Jump();
            Sit();
        }

        Gravy();
    }

    void Moving()
    {
        move = Vector3.zero;
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        move = transform.right * xMove + transform.forward * zMove;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controllerPlayer.Move(move * speedSprint * Time.deltaTime);
        }

        else
        {
            controllerPlayer.Move(move * speedMove * Time.deltaTime);
        }
    }

    void Looking()
    {
        float xLook = Input.GetAxis("Mouse X") * speedRotation * Time.deltaTime;
        float yLook = Input.GetAxis("Mouse Y") * speedRotation * Time.deltaTime;

        xRotation = xRotation - yLook;
        xRotation = Mathf.Clamp(xRotation, -60f, 44.4f);
        head.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(xLook * new Vector3(0, 1, 0));
    }

    void Jump()
    {
        if (isGround && Input.GetButtonDown("Jump"))
        {
            Up.y = Mathf.Sqrt(forseJump * -2 * gravy);
        }
    }

    void Gravy()
    {
        isGround = Physics.CheckBox(groundDetector.transform.position, transform.localScale / 8, transform.rotation, maskCheck);

        if (isGround && Up.y < 0)
        {
            Up.y = -1f;
        }
        Up.y += gravy * Time.deltaTime;
        controllerPlayer.Move(Up * Time.deltaTime);
    }

    void Action()
    {
        Debug.DrawRay(ray.transform.position, ray.transform.forward, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray.transform.position, ray.transform.forward, out hit, rayDistance) && Input.GetKeyDown(KeyCode.E))
        {
            if (hit.collider.tag == "Interactive")
            {
                hit.collider.gameObject.SendMessage("SetObject", gameObject, SendMessageOptions.DontRequireReceiver);
                hit.collider.gameObject.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void Sit()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }

        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void OpenPlayerMenu()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isPlayerMenuActive)
            {
                UIPlayerMenu.SetActive(true);
                gameManager.SetCursor(true);
                isPlayerMenuActive = true;
            }
                
            else
            {
                UIPlayerMenu.SetActive(false);
                gameManager.SetCursor(false);
                isPlayerMenuActive = false;
            }
        }
    }
}
