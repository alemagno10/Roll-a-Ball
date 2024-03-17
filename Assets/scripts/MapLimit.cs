using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimit : MonoBehaviour {

    public Transform player;

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.SetActive(false);
            Debug.Log("Fora dos limites do mapa!");
        }
    }
}
