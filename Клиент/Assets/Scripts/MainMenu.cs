using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputIP;
    [SerializeField] private TMP_InputField inputPort;

    public void Start()
    {
        //SceneManager.LoadScene(1);
    }

    public void Connect()
    {
        //SceneManager.LoadScene(1);
        NetworkManager.instance.ConnectToServer(inputIP.text, int.Parse(inputPort.text));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
