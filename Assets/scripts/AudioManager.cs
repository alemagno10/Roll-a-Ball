using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource music;
    public AudioSource sfx;

    public AudioClip background;
    public AudioClip winFX;
    public AudioClip death;
    public AudioClip deathFX;
    public AudioClip pickUpFX;

    void Start(){
        music.clip = background;
        music.loop = true;
        music.Play();
    }

    public void PlayNewPickUp(){
        sfx.clip = pickUpFX;
        sfx.Play();
    }

    public void PlayWin(){
        sfx.clip = winFX;
        sfx.Play();
        music.Stop();
    }

    public void PlayDeath(){
        sfx.clip = deathFX;
        sfx.Play();
        music.clip = death;
        music.Play();
    }
}
