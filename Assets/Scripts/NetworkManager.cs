using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance;
    [SerializeField] GameObject connectPanel = null;
    [SerializeField] GameObject startButton = null;
    [SerializeField] GameObject playerPrefab = null;
    const string world = "World";
    int currentLevel = 1;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            // If an instance of NetworkManager already exists, destroy this one.
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Connect to the Photon server.
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // When connected to the Photon master server, join the lobby.
        connectPanel.SetActive(false);
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected: " + cause.ToString());
    }

    public void StartGame()
    {
        // Load the game level and create or join the room.
        PhotonNetwork.LoadLevel(currentLevel);
    }

    public override void OnJoinedRoom()
    {
        // Instantiate the player prefab when joined to the room.
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        startButton.SetActive(false);
    }
}
