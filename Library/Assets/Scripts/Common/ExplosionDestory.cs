using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestory : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1.5f);
    }
}
