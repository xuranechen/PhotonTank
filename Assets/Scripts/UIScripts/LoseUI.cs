using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    Button back;
    Button revenge;
    //PhotonView photonView;
    TankHealth mytank;

    private void Awake()
    {
        PhotonNetwork.LeaveRoom();
        back = transform.Find("Back").GetComponent<Button>();
        revenge = transform.Find("Revenge").GetComponent<Button>();
        back.onClick.AddListener(ExitGame);
        revenge.onClick.AddListener(ReStarGame);
    }
    void ExitGame()
    {
        GameMgr.Instance.UIMgr.CloseUI(UIMgr.LoseUI);
        GameMgr.Instance.UIMgr.OpenUI(UIMgr.LandUI);
    }
    void ReStarGame()
    {
        GameMgr.Instance.UIMgr.CloseUI(UIMgr.LoseUI);
        GameMgr.Instance.myTank.SetActive(true);
        GameMgr.Instance.myTank.GetComponent<TankHealth>().ReStart();
        //GameMgr.Instance.myTank.GetComponent<TankHealth>().cur_blood= GameMgr.Instance.myTank.GetComponent<TankHealth>().startHealth;
        //GameMgr.Instance.myTank.GetComponent<TankHealth>().isDead = false;
        //GameMgr.Instance.myTank.GetComponent<TankHealth>().joyStick.SetActive(true);
    }

}
