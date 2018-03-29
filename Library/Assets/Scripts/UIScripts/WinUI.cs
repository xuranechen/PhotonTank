using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    Button Back;
    Text PlayerName;
    private void Awake()
    {
        PhotonNetwork.LeaveRoom();
        GameObject.FindGameObjectWithTag("JoyStick").SetActive(false);
        Back = transform.Find("EXIT").GetComponent<Button>();
        Back.onClick.AddListener(ExitFunc);
        PlayerName = transform.Find("PlayerName").GetComponent<Text>();
        PlayerName.text = PhotonNetwork.playerName;
    }
    void ExitFunc()
    {
        GameMgr.Instance.UIMgr.CloseUI(UIMgr.WinUI);
        GameMgr.Instance.UIMgr.OpenUI(UIMgr.LandUI);
    }
}
