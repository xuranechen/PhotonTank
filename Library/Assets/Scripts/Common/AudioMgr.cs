using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public const string BGM = "BackgroundMusic";
    public const string EngineDriving = "EngineDriving";
    public const string EngineIdle = "EngineIdle";
    public const string ShellExplosion = "ShellExplosion";
    public const string ShotCharging = "ShotCharging";
    public const string ShotFiring = "ShotFiring";
    public const string TankExplosion = "TankExplosion";
    AudioSource L_audio;
    AudioSource S_audio;
    AudioClip audio;

    Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();
    public void Inst()
    {
        audio = Resources.Load(string.Format("{0}{1}", "AudioClips/", BGM)) as AudioClip;
        audios.Add(BGM, audio);
        audio = Resources.Load(string.Format("{0}{1}", "AudioClips/", EngineDriving)) as AudioClip;
        audios.Add(EngineDriving, audio);
        audio = Resources.Load(string.Format("{0}{1}", "AudioClips/", EngineIdle)) as AudioClip;
        audios.Add(EngineIdle, audio);
        audio = Resources.Load(string.Format("{0}{1}", "AudioClips/", ShellExplosion)) as AudioClip;
        audios.Add(ShellExplosion, audio);
        audio = Resources.Load(string.Format("{0}{1}", "AudioClips/", ShotCharging)) as AudioClip;
        audios.Add(ShotCharging, audio);
        audio = Resources.Load(string.Format("{0}{1}", "AudioClips/", ShotFiring)) as AudioClip;
        audios.Add(ShotFiring, audio);
        audio = Resources.Load(string.Format("{0}{1}", "AudioClips/", TankExplosion)) as AudioClip;
        audios.Add(TankExplosion, audio);
        L_audio = GameObject.FindGameObjectWithTag("GameMgr").GetComponent<AudioSource>();
        S_audio = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<AudioSource>();
    }
    public void PlayLongAudio(string Laudio)
    {
        L_audio.clip = audios[Laudio];
    }
    public void PlayShotAudio(string Laudio)
    {
        S_audio.clip = audios[Laudio];
    }
}
