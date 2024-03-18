using UnityEngine;

public class Hud : MonoBehaviour {
    public GameObject winTextObject;
    public GameObject player;
    public float count = 0;

    void Start(){
        winTextObject.SetActive(false);
    }

    void Update(){
        checkWin();
    }

    void checkWin(){
        if (count == 1){
            Debug.Log("WIN!");
            winTextObject.SetActive(true);
        }
    }
}