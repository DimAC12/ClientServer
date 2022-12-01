using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    bool isPause = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    void Update()
    {
        PauseMenu();
    }

    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                isPause = true;
                SetCursor(true);
            }

            else
            {
                isPause = false;
                SetCursor(false);
            }
        }
    }

    public void SetCursor(bool isCursor)
    {
        if (isCursor)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void SetEnviroment(int id)
    {
        if (id == 0)
        {

        }

        if (id == 1)
        {

        }
    }
}
