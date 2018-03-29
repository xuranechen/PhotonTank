using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuff : MonoBehaviour
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
            addBlood.isinvincible = true;
            transform.parent.GetComponent<BuffMgr>().isfull = false;
            Destroy(gameObject);
        }
    }
}