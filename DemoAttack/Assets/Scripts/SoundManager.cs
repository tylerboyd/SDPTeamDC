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

    public static SoundManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void RandomPlaySource1(params AudioClip[] clips)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip clip = clips[index];
        efxSource1.clip = clip;
        efxSource1.pitch = pitch;
        efxSource1.Play();
    }

    public void RandomPlaySource2(params AudioClip[] clips)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip clip = clips[index];

        //BUGGED
        efxSource2.clip = clip;
        efxSource2.pitch = pitch;
        efxSource2.Play();
    }


}