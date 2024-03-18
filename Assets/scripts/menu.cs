using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {
    private MenuAudioManager menuAudioManager;

    void Start(){
        menuAudioManager = FindObjectOfType<MenuAudioManager>();
    }

    public void LoadScenes(string cena){
        SceneManager.LoadScene(cena);
    }

    public void PlayClick(){
        menuAudioManager.playClick();
    }

    public void Quit(){
        Application.Quit();
    }
}