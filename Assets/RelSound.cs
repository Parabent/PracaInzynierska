using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelSound : MonoBehaviour
{
    AudioSource reloading_sound;
    public AudioClip sound;

    private void Start()
    {
        reloading_sound = GetComponent<AudioSource>();
        //sound = GetComponent<AudioSource>().clip;
    }
    public AudioClip getsound()
    {
        return sound;
    }
    public void Play()
    {
        reloading_sound.Play();
    }
}
