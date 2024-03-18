using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour {
    public AudioSource music;
    public AudioSource sfx;

    public AudioClip background;
    public AudioClip click;

    void Start(){
        music.clip = background;
        music.loop = true;
        music.Play();
    }

    public void playClick(){
        sfx.clip = click;
        sfx.Play();
    }
}