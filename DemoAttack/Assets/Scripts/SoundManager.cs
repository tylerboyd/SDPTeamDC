using UnityEngine;
using System.Collections;

//Larry zhao: 15913026

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    public AudioSource efxSource1;
    public AudioSource efxSource2;
    public AudioSource efxSource3;
    public AudioSource efxSource4;

    public static SoundManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void RandomPlayAttackSource(params AudioClip[] clips)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip clip = clips[index];
        efxSource1.clip = clip;
        efxSource1.pitch = pitch;
        efxSource1.Play();
    }

    public void RandomPlayWalkingSource(params AudioClip[] clips)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip clip = clips[index];

        //BUGGED
        efxSource2.clip = clip;
        efxSource2.pitch = pitch;
        efxSource2.Play();
    }

    public void RandomPlayEnemyDeadSource(params AudioClip[] clips)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip clip = clips[index];

        //BUGGED
        efxSource3.clip = clip;
        efxSource3.pitch = pitch;
        efxSource3.Play();
    }

    public void RandomPlayEnemyTakingDemageSource(params AudioClip[] clips)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip clip = clips[index];

        //BUGGED
        efxSource4.clip = clip;
        efxSource4.pitch = pitch;
        efxSource4.Play();
    }

}