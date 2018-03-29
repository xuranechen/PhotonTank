using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetUp : MonoBehaviour
{
    public Behaviour[] stuffDisable;
    Behaviour tank;
    public GameObject body;
    public GameObject head;
    MeshRenderer TankChassis;
    MeshRenderer TankTracksLeft;
    MeshRenderer TankTracksRight;
    MeshRenderer TankTurret;
    Material EnemyColor;

    PhotonView photonView;
    private void OnEnable()
    {
        //body = transform.Find("TankRenderers").gameObject;
        //head = transform.Find("TankTurret").gameObject;
        TankChassis = transform.Find("TankRenderers/TankChassis").GetComponent<MeshRenderer>();
        TankTracksLeft = transform.Find("TankRenderers/TankTracksLeft").GetComponent<MeshRenderer>();
        TankTracksRight = transform.Find("TankRenderers/TankTracksRight").GetComponent<MeshRenderer>();
        TankTurret = transform.Find("TankTurret").GetComponent<MeshRenderer>();
        EnemyColor = Resources.Load("Material/Rad") as Material;

    }
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.isMine)
        {
            //tank = gameObject.GetComponent<Tank>();
            //stuffDisable[0] = tank;
            //GameObject.Find("Tank1").SetActive(false);
            gameObject.tag = "Untagged";
            body.tag = "WinTag";
            head.tag = "Untagged";
            TankChassis.materials[0] = EnemyColor;
            TankTracksLeft.materials[0] = EnemyColor;
            TankTracksRight.materials[0] = EnemyColor;
            TankTurret.materials[0] = EnemyColor;
            for (int i = 0; i < stuffDisable.Length; i++)
            {
                stuffDisable[i].enabled = false;
            }
        }
        //else
        //{
        //    GameObject.Find("Tank2").SetActive(false);
        //}
    }
}
