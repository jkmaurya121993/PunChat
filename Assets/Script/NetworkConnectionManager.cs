using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class NetworkConnectionManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private bool TrytoConnectToMaster = false;
    private bool TrytoConnectToRoom = false;
    public TextMeshProUGUI connectiontext;
    void Start()
    {
        connectiontext.text = "Connect to server!";
    }

    // Update is called once per frame
   
    public void OnClicktoMasterServer()
    {
        PhotonNetwork.OfflineMode = false;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "v1";
        PhotonNetwork.NickName = "PhotonChat";
        TrytoConnectToMaster = true;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        TrytoConnectToMaster = false;
        Debug.Log("Connected to Master");
        connectiontext.text = "Connection done!";
    }
    public override void OnCustomAuthenticationFailed(string debugMessage)
    {
        base.OnCustomAuthenticationFailed(debugMessage);
    }
   
}
