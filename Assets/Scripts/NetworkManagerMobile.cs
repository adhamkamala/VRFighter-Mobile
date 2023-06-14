using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class NetworkManagerMobile : MonoBehaviourPunCallbacks
{
    private const string RoomName = "Room1";
    private const float JoinInterval = 2f;

    private float joinTimer;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI statusRoomText;

    private void Start()
    {
        joinTimer = JoinInterval;
    }

    private void Update()
    {
        joinTimer -= Time.deltaTime;

        if (joinTimer <= 0f)
        {
            ConnectAndJoinRoom();
            joinTimer = JoinInterval;
        }
    }

    private void ConnectAndJoinRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Connecting to Photon server...");
            statusText.text = "Connecting to Photon server...";
        }
        else
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinRoom(RoomName);
                Debug.Log("Joining Room: " + RoomName);
                statusRoomText.text = "Joining room...";
            }
        }
    }

    public void Reconnect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
            statusText.text = "Disconnected from Photon server.";
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to Photon server.");
        statusText.text = "Connected to Photon server.";
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        statusRoomText.text = "Joined Room";
        PhotonNetwork.RaiseEvent(1, null, RaiseEventOptions.Default, SendOptions.SendReliable);
    }
}
