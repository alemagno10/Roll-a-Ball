using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour {

    private Rigidbody rb;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI deathText;
    public GameObject winTextObject;
    public GameObject player;
    private TimeStamp timeStampScript;

    private float movementX;
    private float movementY;
    private bool reset = false;
    public float speed = 0;
    public float count = 0;

    void Start(){
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
        deathText.gameObject.SetActive(false);
    }

    void Update(){
        SetCountText();
        checkReset();
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

        if (count == 1){
            Debug.Log("WIN!");
            winTextObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            reset = true;
            deathText.gameObject.SetActive(true);
            // player.SetActive(false);
        }
    } 

    void FixedUpdate(){
        Vector3 moviment = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(moviment*speed);
    }

    void SetCountText() {
       countText.text =  "Count: " + count.ToString();
    }

    void checkReset(){
        if(reset && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
