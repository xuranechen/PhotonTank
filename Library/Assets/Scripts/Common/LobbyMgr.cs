using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMgr : Photon.PunBehaviour
{
    public LandUI landUI;
    int maxPlayerNum = 2;
    void Start()
    {
        landUI = GameObject.FindGameObjectWithTag("LandUI").GetComponent<LandUI>();
        PhotonNetwork.ConnectUsingSettings("0.1");
        //landUI.TextShow("Connected To Sever!!");
        //landUI.GetPlayerName();
    }
    public void StartMacting()
    {
        landUI.TextShow("Start Ranking!!");
        PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.playerName= landUI.GetPlayerName().ToString();
    }
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom("RuneLand");
    }
    public override void OnCreatedRoom()
    {
        landUI.TextShow("Created Room!!");
        Debug.Log("Created Room!!");
    }
    public override void OnJoinedRoom()
    {
        landUI.TextShow("Joined Room!!\nWaiting For Other Players!!");
        Debug.Log("Joined Room!!");
        PhotonNetwork.automaticallySyncScene = true;
    }
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        int num = PhotonNetwork.playerList.Length;
        Debug.Log(num);
        if (num == maxPlayerNum)
        {
            if (PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.LoadLevel(1);
            }
        }
    }
}
