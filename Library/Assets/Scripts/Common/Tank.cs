using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    GameObject tankHead;
    public GameObject bullet;
    Transform firepos;
    Slider aimSlider;
    float min_LaunchForce = 15f;
    float max_LaunchForce = 30f;
    float maxChargeTime = 0.75f;
    float cur_LaunchForce;//发射子弹的力
    float chargeSpeed;//蓄力速度
    bool fired;
    private void Awake()
    {
        tankHead = transform.Find("TankTurret").gameObject;
        aimSlider = tankHead.transform.Find("Canvas/ForceSlider").GetComponent<Slider>();
        firepos = tankHead.transform.Find("fightpos");
        cur_LaunchForce = min_LaunchForce;
        aimSlider.value = min_LaunchForce;
        chargeSpeed = (max_LaunchForce - min_LaunchForce) / maxChargeTime;
    }

    private void FixedUpdate()
    {
        if (cur_LaunchForce >= max_LaunchForce && !fired)
        {
            cur_LaunchForce = max_LaunchForce;
            GameMgr.Instance.FireEvent.isDown = false;
            if (GameMgr.Instance.FireEvent.isUp)
            {
                FireFunc();
                GameMgr.Instance.FireEvent.isUp = false;
            }
        }
        else if (GameMgr.Instance.FireEvent.isDown)
        {
            fired = false;
            if (!fired)
            {
                GameMgr.Instance.AudioMgr.PlayShotAudio(AudioMgr.ShotCharging);
                cur_LaunchForce += chargeSpeed * Time.deltaTime;
                aimSlider.value = cur_LaunchForce;
            }
        }
        else if (GameMgr.Instance.FireEvent.isUp && !fired)
        {
            GameMgr.Instance.FireEvent.isDown = false;
            FireFunc();
            GameMgr.Instance.FireEvent.isUp = false;
        }
    }
    public void FireFunc()
    {
        aimSlider.value = min_LaunchForce;
        fired = true;
        GameObject shell = PhotonNetwork.Instantiate(bullet.name, firepos.position, firepos.rotation, 0);
        shell.AddComponent<Bullet>();
        GameMgr.Instance.AudioMgr.PlayShotAudio(AudioMgr.ShotFiring);
        shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * cur_LaunchForce;
        cur_LaunchForce = min_LaunchForce;
    }
}
