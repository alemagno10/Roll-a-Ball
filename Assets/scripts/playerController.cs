using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour {

    private Rigidbody rb;
    private Hud hud;
    public GameObject player;

    private float movementX;
    private float movementY;
    private float slowdownFactor = 10f;
    public bool stop = false;
    public float speed = 0;

    void Start(){
        hud = FindObjectOfType<Hud>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if(!stop){
            Vector3 moviment = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(moviment*speed);
        } else {
            Vector3 oppositeForce = -rb.velocity * slowdownFactor;
            rb.AddForce(oppositeForce);
        }
    }

    public void Freeze(){
        stop = true;
    }

    void OnMove(InputValue value){
        Vector2 movementVector = value.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
            hud.NewPickUp();
            other.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            hud.DeathHandler();
            player.SetActive(false);
        }
    } 
}
