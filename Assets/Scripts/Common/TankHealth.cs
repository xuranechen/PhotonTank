using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour, IPunObservable
{
    public float startHealth = 100f;
    Slider bloodSlider;
    Image fillImage;
    Color fullBlood = Color.green;
    Color nullBlood = Color.red;
    GameObject tankBoom;
    public GameObject joyStick;
    PhotonView photonView;
    ParticleSystem boomEff;
    public float cur_blood;
    public bool isDead = false;
    public bool isinvincible = false;
    void Awake()
    {
        tankBoom = Resources.Load("Prefabs/TankExplosion") as GameObject;
        bloodSlider = transform.Find("TankTurret/Canvas/BloodSlider").GetComponent<Slider>();
        fillImage = bloodSlider.transform.Find("Fill Area/Fill").GetComponent<Image>();
    }
    private void Start()
    {
        boomEff = Instantiate(tankBoom).GetComponent<ParticleSystem>();
        boomEff.gameObject.SetActive(false);
        InvokeRepeating("WinFunc", 3, 0.1f);
    }
    private void FixedUpdate()
    {
        bloodSlider.value = cur_blood / 100;
    }
    private void OnEnable()
    {
        cur_blood = startHealth;
        isDead = false;
        SetHealthUI();
    }
    float timer = 0f;
    [PunRPC]
    public void TakeDamage(float amount)
    {
        if (isinvincible)
        {
            isinvincible = false;
            return;
        }
        cur_blood -= amount;
        SetHealthUI();
        if (cur_blood <= 0f && !isDead)
        {
            OnDeath();
        }
        timer = 0f;
    }
    private void SetHealthUI()
    {
        bloodSlider.value = cur_blood / 100;
        fillImage.color = Color.Lerp(nullBlood, fullBlood, cur_blood / startHealth);
    }
    private void OnDeath()
    {
        photonView = GetComponent<PhotonView>();
        GameMgr.Instance.AudioMgr.PlayShotAudio(AudioMgr.TankExplosion);
        if (photonView.isMine)
        {
            GameMgr.Instance.myTank = gameObject;
            joyStick = GameObject.FindGameObjectWithTag("JoyStick");
            joyStick.SetActive(false);
            GameMgr.Instance.UIMgr.OpenUI(UIMgr.LoseUI);
            isDead = true;
            boomEff.transform.position = transform.position;
            boomEff.gameObject.SetActive(true);
            boomEff.Play();
            gameObject.SetActive(false);
        }
    }
    public void ReStart()
    {
        gameObject.SetActive(true);
        cur_blood = startHealth;
        isDead = false;
        GameMgr.Instance.myTank.GetComponent<TankHealth>().joyStick.SetActive(true);
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(this.cur_blood);
            stream.SendNext(GameMgr.Instance.myTank.GetActive());
        }
        else
        {
            this.cur_blood = (float)stream.ReceiveNext();
            GameMgr.Instance.myTank.SetActive((bool)stream.ReceiveNext());
        }
    }
    void WinFunc()
    {
        if (GameObject.FindGameObjectsWithTag("WinTag").Length == 1 && !GameMgr.Instance.UIMgr.UIGroup.ContainsKey(UIMgr.LoseUI))
        {
            GameMgr.Instance.UIMgr.OpenUI(UIMgr.WinUI);
        }
    }
}
