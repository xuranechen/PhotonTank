using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetWorkTest : Photon.PunBehaviour
{
    GameObject playerpfb;
    private void OnEnable()
    {
        playerpfb = Resources.Load("Tank1") as GameObject;
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //private void OnDestroy()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}
    //void OnSceneLoaded(Scene scene,LoadSceneMode mod)
    //{
    //    PhotonNetwork.Instantiate(player.name, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, 0);
    //}

    private void OnLevelWasLoaded(int level)
    {
        GameMgr.Instance.UIMgr.CloseUI("LandUI");
        PhotonNetwork.Instantiate(playerpfb.name, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, 0)/*.AddComponent<PlayerSetUp>()*/;
    }
}
