using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class NetworkManagerMobile : MonoBehaviourPunCallbacks
{
    private const string RoomName = "Room1";
    private const float JoinInterval = 1.5f;

    private float joinTimer;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI statusRoomText;
    private int roomCreatorId;

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

    private void CheckRoomAvailable()
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
           // int roomCreatorId = PhotonNetwork.CurrentRoom.MasterClientId;
            bool isRoomCreatorPresent = false;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                    if (player.ActorNumber == roomCreatorId)
                {
                    isRoomCreatorPresent = true;
                    break; // Found the room creator, exit the loop
                }
            }

            if (!isRoomCreatorPresent)
            {
               Reconnect();
            }
  
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
            if (PhotonNetwork.InLobby || !PhotonNetwork.InRoom)
            {
                PhotonNetwork.JoinRoom(RoomName);
                Debug.Log("Joining Room: " + RoomName);
                statusRoomText.text = "Joining room...";
            }
        }
        if (PhotonNetwork.InRoom)
        {
            CheckRoomAvailable();
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
        roomCreatorId = PhotonNetwork.CurrentRoom.MasterClientId;
        statusRoomText.text = "Joined Room";
        PhotonNetwork.RaiseEvent(1, null, RaiseEventOptions.Default, SendOptions.SendReliable);
    }
}
