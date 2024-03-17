using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour {

    private Rigidbody rb;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float movementX;
    private float movementY;
    public float speed = 0;
    public float count = 0;

    void Start(){
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
    }

    void Update(){
        SetCountText();
    }

    void OnMove(InputValue value){
        Vector2 movementVector = value.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
            count = count + 1;
            other.gameObject.SetActive(false);
        }

        if (count >= 16){
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate(){
        Vector3 moviment = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(moviment*speed);
    }

    void SetCountText() {
       countText.text =  "Count: " + count.ToString();
    }

}
