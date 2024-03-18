using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimit : MonoBehaviour {

    public Transform player;
    private Hud hud;

    void Start(){
        hud = FindObjectOfType<Hud>();
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            hud.DeathHandler();
            other.gameObject.SetActive(false);
        }
    }
}
