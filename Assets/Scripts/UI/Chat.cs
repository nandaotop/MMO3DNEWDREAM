using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;

public class Chat : MonoBehaviour, IChatClientListener
{
    [SerializeField] InputField field = null;
    ChatClient client;
    public List<string> channels = new List<string>()
    {
        "global"
    };
    string currentChannel;
    [SerializeField] Text prefab = null;
    [SerializeField] Transform content = null;

    private void Start() 
    {
        SetUp("Test");    
    }

    private void Update() 
    {
        client.Service();    
    }

    public void SetUp(string userID)
    {
        client = new ChatClient(this, ConnectionProtocol.Tcp);
        client.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat,
            PhotonNetwork.AppVersion, new AuthenticationValues(userID));
    }

    public void Send()
    {
        Debug.Log("aqui");
        string message = field.text;
        if (string.IsNullOrEmpty(message)) return;
        client.PublishMessage(currentChannel, message);
        CancelMessage();    
    }

    public void CancelMessage()
    {
        field.text = "";
    }

    void IChatClientListener.OnConnected()
    {
        currentChannel = channels[0];
        client.Subscribe(currentChannel);
    }

    void IChatClientListener.OnChatStateChange(ChatState state)
    {
        
    }

    void IChatClientListener.OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            var t = Instantiate(prefab, content);
            t.text = senders[i] + " : " + messages[i];
        }
    }

    void IChatClientListener.OnPrivateMessage(string sender, object message, string channelName)
    {
        
    }

    #region NOTUSED

    void IChatClientListener.DebugReturn(DebugLevel level, string message)
    {
        
    }

    void IChatClientListener.OnDisconnected()
    {
        
    }

    void IChatClientListener.OnSubscribed(string[] channels, bool[] results)
    {
        
    }

    void IChatClientListener.OnUnsubscribed(string[] channels)
    {
        
    }

    void IChatClientListener.OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        
    }

    void IChatClientListener.OnUserSubscribed(string channel, string user)
    {
        
    }

    void IChatClientListener.OnUserUnsubscribed(string channel, string user)
    {
        
    }

    #endregion
}
