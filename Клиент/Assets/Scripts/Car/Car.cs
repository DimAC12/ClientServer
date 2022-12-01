using Assets.Network;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float MotoForce;  // мощьность врощения задних колес
    public float SteerForce; // угол поворота передних колес
    public float BreakForce; // тормоз для передних колес
    //public float ZADBreakForce; // тормоз для задних колес

    bool zadniHod = false;
    bool lights = false;
    bool povorotLeft = false;
    bool povorotRight = false;
    bool avariika = false;
    bool drift = false;

    public WheelCollider WheelColliderPL;
    public WheelCollider WheelColliderPP;
    public WheelCollider WheelColliderZL;
    public WheelCollider WheelColliderZP;

    public Transform PLTransform;
    public Transform PPTransform;
    public Transform ZLTransform;
    public Transform ZPTransform;

    public GameObject PPL;
    public GameObject PPP;

    Transform ubludok;

    [SerializeField] GameObject lightFL;
    [SerializeField] GameObject lightFR;
    [SerializeField] GameObject lightBL;
    [SerializeField] GameObject lightBR;

    [SerializeField] GameObject lightBLOst;
    [SerializeField] GameObject lightBROst;

    [SerializeField] GameObject lightLZad;
    [SerializeField] GameObject lightRZad;

    Vector3 TPL, TPP; // вектор поворота

    [SerializeField] GameObject centerMass;
    Animator animator;

    [SerializeField] Material materialDefauld;
    [SerializeField] Material materialMaya;
    [SerializeField] GameObject corpus;
    bool isMaya = false;
    bool isDoMaya = true;
    private float timeInSec = 15f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody body = GetComponent<Rigidbody>();
        body.centerOfMass = centerMass.gameObject.transform.localPosition;

        //ubludok.transform.up = Vector3.up;
    }

    private IEnumerator StartTimer()
    {
            yield return new WaitForSeconds(timeInSec);
            Debug.Log("Оба");
            isDoMaya = true;
    }

    public void SetMaya()
    {
        isDoMaya = false;
        isMaya = true;
        StartCoroutine(StartTimer());
        corpus.GetComponent<MeshRenderer>().material = materialMaya;
    }

    public void NotMaya()
    {
        isMaya = false;
        corpus.GetComponent<MeshRenderer>().material = materialDefauld;
    }

    private void Update()
    {
        //if ()
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lights)
            {
                lightFL.SetActive(false);
                lightFR.SetActive(false);
                lightBLOst.SetActive(false);
                lightBROst.SetActive(false);
                lights = false;
            }
            else
            {
                lightFL.SetActive(true);
                lightFR.SetActive(true);
                lightBLOst.SetActive(true);
                lightBROst.SetActive(true);
                lights = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (zadniHod)
            {
                zadniHod = false;
                lightLZad.SetActive(false);
                lightRZad.SetActive(false);
            }
            else
            {
                zadniHod = true;
                lightLZad.SetActive(true);
                lightRZad.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (povorotLeft)
            {
                povorotLeft = false;
                animator.SetInteger("State", 0);
            }
            else
            {
                povorotLeft = true;
                animator.SetInteger("State", 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (povorotRight)
            {
                povorotRight = false;
                animator.SetInteger("State", 0);
            }
            else
            {
                povorotRight = true;
                animator.SetInteger("State", 2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (avariika)
            {
                avariika = false;
                animator.SetInteger("State", 0);
            }
            else
            {
                avariika = true;
                animator.SetInteger("State", 3);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (drift)
            {
                WheelFrictionCurve myWfc;
                myWfc = WheelColliderPL.sidewaysFriction;
                myWfc.stiffness = 3f;
                WheelColliderPL.sidewaysFriction = myWfc;

                myWfc = WheelColliderPP.sidewaysFriction;
                myWfc.stiffness = 3f;
                WheelColliderPP.sidewaysFriction = myWfc;

                myWfc = WheelColliderZL.sidewaysFriction;
                myWfc.stiffness = 3f;
                WheelColliderZL.sidewaysFriction = myWfc;

                myWfc = WheelColliderZP.sidewaysFriction;
                myWfc.stiffness = 3f;
                WheelColliderZP.sidewaysFriction = myWfc;

                drift = false;
            }

            else
            {
                WheelFrictionCurve myWfc;
                myWfc = WheelColliderPL.sidewaysFriction;
                myWfc.stiffness = 1f;
                WheelColliderPL.sidewaysFriction = myWfc;

                myWfc = WheelColliderPP.sidewaysFriction;
                myWfc.stiffness = 1f;
                WheelColliderPP.sidewaysFriction = myWfc;

                myWfc = WheelColliderZL.sidewaysFriction;
                myWfc.stiffness = 1f;
                WheelColliderZL.sidewaysFriction = myWfc;

                myWfc = WheelColliderZP.sidewaysFriction;
                myWfc.stiffness = 1f;
                WheelColliderZP.sidewaysFriction = myWfc;

                drift = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player" && isMaya == true && isDoMaya)
        {
            Debug.Log("Еба?");
            Transport.SendData("SetMaya#" + collision.gameObject.name);
        }
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (zadniHod)
                Nazad();
            else
                Gaz();
        }

        else
        {
            OffGaz();
        }

        if (Input.GetKey(KeyCode.S) || isDoMaya == false)
        {
            Tormoz();
            lightBL.SetActive(true);
            lightBR.SetActive(true);
            lightBLOst.SetActive(false);
            lightBROst.SetActive(false);
        }

        else
        {
            OffTormoz();
            lightBL.SetActive(false);
            lightBR.SetActive(false);

            if (lights)
            {
                lightBLOst.SetActive(true);
                lightBROst.SetActive(true);
            }
        }

        Povorot();
    }

    void Gaz()
    {
        if (isDoMaya)
        {
            WheelColliderZL.motorTorque = MotoForce;
            WheelColliderZP.motorTorque = MotoForce;
            WheelColliderPL.motorTorque = MotoForce;
            WheelColliderPP.motorTorque = MotoForce;
        }
    }

    void Nazad()
    {
        if (isDoMaya)
        {
            WheelColliderZL.motorTorque = -MotoForce;
            WheelColliderZP.motorTorque = -MotoForce;
            WheelColliderPL.motorTorque = -MotoForce;
            WheelColliderPP.motorTorque = -MotoForce;
        }
    }

    void OffGaz()
    {
        WheelColliderZL.motorTorque = 0;
        WheelColliderZP.motorTorque = 0;
        WheelColliderPL.motorTorque = 0;
        WheelColliderPP.motorTorque = 0;
    }

    void Tormoz()
    {
        WheelColliderZL.brakeTorque = +BreakForce;
        WheelColliderZP.brakeTorque = +BreakForce;
        //WheelColliderPL.brakeTorque = +BreakForce;
        //WheelColliderPP.brakeTorque = +BreakForce;
    }

    void OffTormoz()
    {
        WheelColliderZL.brakeTorque = 0;
        WheelColliderZP.brakeTorque = 0;
        WheelColliderPL.brakeTorque = 0;
        WheelColliderPP.brakeTorque = 0;
    }

    void Povorot()
    {
        WheelColliderPL.steerAngle = Input.GetAxis("Horizontal") * SteerForce; // угол поворот передних колес
        WheelColliderPP.steerAngle = Input.GetAxis("Horizontal") * SteerForce; // угол поворот передних колес

        TPL = PLTransform.localEulerAngles;
        TPL.y = WheelColliderPL.steerAngle; // поворот коллайдера колеса
        PLTransform.transform.localEulerAngles = TPL; // поворот модели колеса

        TPP = PLTransform.localEulerAngles;
        TPP.y = WheelColliderPL.steerAngle;
        PPTransform.transform.localEulerAngles = TPP;
    }
}
