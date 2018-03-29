using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*public */GameObject bulletExp;
    LayerMask m_TankMask;
    float m_MaxDamage = 100f;
    float m_ExplosionForce = 1000f;
    float m_ExplosionRadius = 5f;
    public bool isself = true;
    private void Start()
    {
        m_TankMask = LayerMask.GetMask("Player");
        bulletExp = Resources.Load("ShellExplosion") as GameObject;
    }
    void OnTriggerEnter(Collider collider)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "soldier")
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
                if (!targetRigidbody)
                {
                    continue;
                }
                targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
                if (!targetHealth)
                {
                    continue;
                }
                float damage = CalculateDamage(targetRigidbody.position);
                PhotonView pv = targetRigidbody.GetComponent<PhotonView>();
                if (!pv)
                {
                    Debug.LogError(444);
                    continue;
                }
                pv.RPC("TakeDamage", PhotonTargets.All, damage);
            }
        }
        GameMgr.Instance.AudioMgr.PlayShotAudio(AudioMgr.ShellExplosion);
        //PhotonNetwork.Instantiate(bulletExp.name, transform.position, transform.rotation,0);
        Instantiate(bulletExp, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        float damage = relativeDistance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        Debug.Log(damage);
        return damage;
    }
}
