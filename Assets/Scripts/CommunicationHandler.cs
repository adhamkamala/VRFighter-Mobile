using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class CommunicationHandler : MonoBehaviourPunCallbacks
{
    public static CommunicationHandler Instance;
    public TextMeshProUGUI orderStatus;
    private const float OrderStatusDisplayTime = 2f;
    private float orderStatusTimer;

    private const byte LButtonRedPressEventCode = 13;
    private const byte LButtonBlueEventCode = 2;
    private const byte LButtonUnderEventCode = 3;
    private const byte LButtonMiddleEventCode = 4;
    private const byte LButtonHighEventCode = 5;
    private const byte LButtonUpperEventCode = 6;
    private const byte RButtonRedPressEventCode = 7;
    private const byte RButtonBlueEventCode = 8;
    private const byte RButtonUnderEventCode = 9;
    private const byte RButtonMiddleEventCode = 10;
    private const byte RButtonHighEventCode = 11;
    private const byte RButtonUpperEventCode = 12;


    private void Awake()
    {
        // Singleton pattern to ensure only one instance of CommunicationHandler exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (orderStatusTimer > 0f)
        {
            orderStatusTimer -= Time.deltaTime;
            if (orderStatusTimer <= 0f)
            {
                orderStatus.text = string.Empty;
            }
        }
    }

    public void SendLButtonRedPressEvent()
    {
        PhotonNetwork.RaiseEvent(LButtonRedPressEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }

    public void SendLButtonBlueEvent()
    {
        PhotonNetwork.RaiseEvent(LButtonBlueEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }
    public void SendLButtonUnderEvent()
    {
        PhotonNetwork.RaiseEvent(LButtonUnderEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }
    public void SendLButtonMiddleEvent()
    {
        PhotonNetwork.RaiseEvent(LButtonMiddleEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }
    public void SendLButtonHighEvent()
    {
        PhotonNetwork.RaiseEvent(LButtonHighEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }
    public void SendLButtonUpperEvent()
    {
        PhotonNetwork.RaiseEvent(LButtonUpperEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }

    public void SendRButtonRedPressEvent()
    {
        PhotonNetwork.RaiseEvent(RButtonRedPressEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }

    public void SendRButtonBlueEvent()
    {
        PhotonNetwork.RaiseEvent(RButtonBlueEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }
    public void SendRButtonUnderEvent()
    {
        PhotonNetwork.RaiseEvent(RButtonUnderEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }
    public void SendRButtonMiddleEvent()
    {
        PhotonNetwork.RaiseEvent(RButtonMiddleEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }
    public void SendRButtonHighEvent()
    {
        PhotonNetwork.RaiseEvent(RButtonHighEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }
    public void SendRButtonUpperEvent()
    {
        PhotonNetwork.RaiseEvent(RButtonUpperEventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        SetText();
    }

    private void SetText()
    {
        orderStatus.text = "Order sent...";
        orderStatusTimer = OrderStatusDisplayTime;
    }

}
