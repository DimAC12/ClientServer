using Assets.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{
    static public NetworkManager instance;

    public string ip = "127.0.0.1";
    public int port = 19235;
    public int myPort = 22334;

    public GameObject controlePlayer;
    public GameObject anotherPlayer;
    public GameObject spawnPoint;

    public Vector3 coordsSpawn;

    private GameObject myObj;

    public int myID;

    private void Reset()
    {
        gameObject.AddComponent<CommandHandler>();
    }

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public GameObject GetMayObj()
    {
        return myObj;
    }

    public void SpawnControlePlayer(float posX = 0, float posY = 0, float posZ = 0)
    {
        myObj = Instantiate(controlePlayer, coordsSpawn, transform.rotation);
    }
    
    public void SpawnAnotherPlayer(int id, float posX, float posY, float posZ)
    {
        GameObject gm = Instantiate(anotherPlayer, new Vector3(posX, posY, posZ), transform.rotation);
        gm.name = id.ToString();
        Debug.Log("Заспавнил челбосоида: " + gm.name);
        BasePlayers.AddPlayer(id, gm);
        BasePlayers.SetCoords(id,posX, posY, posZ, 0,0,0,1,1,1);
    }

    public void DestroyPlayer(int id)
    {
        GameObject gm = BasePlayers.GetObjectPlayer(id);
        Destroy(gm);
        BasePlayers.RemovePlayer(id);
    }

    public void ConnectToServer(string ip, int port)
    {
        SceneManager.LoadScene(1);
        Transport.StartReceive(ip, port, myPort);
    }
}
