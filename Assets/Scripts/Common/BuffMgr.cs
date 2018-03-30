using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMgr : MonoBehaviour
{
    public GameObject healthBuff;
    public GameObject shieldBuff;
    public GameObject buffPool;
    public bool isfull = false;

    private void Awake()
    {
        InvokeRepeating("AddBuff", 0, 30f);
    }
    void AddBuff()
    {
        if (!isfull)
        {
            int a = Random.Range(1, 3);
            switch (a)
            {
                case 1:
                    Instantiate(shieldBuff, transform);
                    isfull = true;
                    break;
                case 2:
                    Instantiate(healthBuff, transform);
                    isfull = true;
                    break;
                default:
                    break;
            }
        }
    }
}
