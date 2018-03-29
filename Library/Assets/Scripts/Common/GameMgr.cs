using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    static GameMgr Inst;
    //public bool restar = false;
    public GameObject myTank;
    public static GameMgr Instance
    {
        get { return Inst; }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Inst = this;
        UIMgr = gameObject.AddComponent<UIMgr>();
        UIMgr.Inst();
        LobbyMgr = gameObject.AddComponent<LobbyMgr>();
        NetWorkTest = gameObject.AddComponent<NetWorkTest>();
        AudioMgr = gameObject.AddComponent<AudioMgr>();
        AudioMgr.Inst();
        AudioMgr.PlayLongAudio(AudioMgr.BGM);
        //FireEvent = GameObject.FindGameObjectWithTag("FireButton").AddComponent<FireEvent>();
    }
    public FireEvent FireEvent
    {
        get;
        private set;
    }
    public AudioMgr AudioMgr
    {
        get;
        private set;
    }
    public LobbyMgr LobbyMgr
    {
        get;
        private set;
    }
    public NetWorkTest NetWorkTest
    {
        get;
        private set;
    }
    public UIMgr UIMgr
    {
        get;
        private set;
    }
    public PlayerSetUp PlayerSetUp
    {
        get;
        private set;
    }
    private void OnLevelWasLoaded(int level)
    {
        FireEvent = GameObject.FindGameObjectWithTag("FireButton").AddComponent<FireEvent>();
    }
}
