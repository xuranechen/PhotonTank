using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    GameObject player;
    TankHealth addBlood;
    public const float addblood = 30f;

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        if (player.GetComponent<TankHealth>())
        {
            addBlood = player.GetComponent<TankHealth>();
            ReHealth();
            transform .parent.GetComponent<BuffMgr>().isfull = false;
            Destroy(gameObject);
        }
    }
    void ReHealth()
    {
        if (addBlood.cur_blood + addblood >= 100)
        {
            addBlood.cur_blood = 100;
        }
        else
        {
            addBlood.cur_blood += addblood;
        }
    }
}
