using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
namespace Photon.Chat
{
    using ExitGames.Client.Photon;
    public class Chat : MonoBehaviour, IChatClientListener
    {
        public ChatClient chatClient;
        public InputField playerName;
        public TextMeshProUGUI connectionState;
        public InputField msgInput;
        public TextMeshProUGUI msgArea;
        private string worldChat;
        public GameObject introPanel;
        public GameObject msgPanel;
        private void Start()
        {
            Application.runInBackground = true;
            if(string.IsNullOrEmpty(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat))
            {
                Debug.Log("No chat Id provided!");
            }

            connectionState.text = "connecting.....";
            worldChat = "world";
           // getConnected();
        }

        public void SendMessage()
        {
            //worldChat = msgInput.text;
            //msgArea.text = worldChat;
            this.chatClient.PublishMessage(worldChat, msgInput.text);
           
        }
        private void Update()
        {
            if(this.chatClient!=null)
            this.chatClient.Service();
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKey(KeyCode.Escape))
                {

                    Application.Quit();

                    return;
                }
            }

            }
        public void getConnected()
        {
            this.chatClient = new ChatClient(this);
            this.chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, "anything", new AuthenticationValues(playerName.text));
            connectionState.text = "connecting to chat";
        }
        public   void DebugReturn(DebugLevel level, string message)
        {

        }
        public  void  OnDisconnected()
        {
            Debug.Log("Disconnected..");
        }

        public  void OnConnected()
        {
            Debug.Log("on connected ......");
            connectionState.text = "connected";
            introPanel.SetActive(false);
            msgPanel.SetActive(true);
            this.chatClient.Subscribe(new string[] { worldChat });
            this.chatClient.SetOnlineStatus(ChatUserStatus.Online);
              
        }
        public void OnClickClear()
        {
            msgArea.text = "";
        }
        public void OnClickClose()
        {
            Application.Quit();
        }
        public  void OnChatStateChange(ChatState state)
        {

        }

        public  void OnGetMessages(string channelName, string[] senders, object[] messages)
        {
            for(int i=0;i< senders.Length;i++)
            {
                msgArea.text += senders[i] + ": " + messages[i] + "\n";
            }

        }

        public  void OnPrivateMessage(string sender, object message, string channelName)
        {

        }

        public   void OnSubscribed(string[] channels, bool[] results)
        {

        }

        public   void OnUnsubscribed(string[] channels)
        {

        }

        public  void OnStatusUpdate(string user, int status, bool gotMessage, object message)
        {

        }

        public   void OnUserSubscribed(string channel, string user)
        {

        }

        public  void OnUserUnsubscribed(string channel, string user)
        { 

        }
    }
}

