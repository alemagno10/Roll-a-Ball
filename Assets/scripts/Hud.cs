using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hud : MonoBehaviour {
    public TextMeshProUGUI countText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI winText;
    private playerController player; 
    private TimeStamp timeStamp;
    private AudioManager audioManager;
    private Enemy[] enemies;

    private float count = 0;
    private bool reset = false;
    private bool justWon = false;

    void Start(){
        winText.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);
        player = FindObjectOfType<playerController>();
        enemies = FindObjectsOfType<Enemy>();
        timeStamp = FindObjectOfType<TimeStamp>();
        audioManager = FindObjectOfType<AudioManager>();
        SetCountText();
    }

    void Update(){
        SetCountText();
        checkWin();
        checkReset();
    }

    void checkWin(){
        if (count == 20 && !justWon){
            justWon = true;
            timeStamp.PauseTime();
            player.Freeze();
            Enemy.FreezeAll();
            winText.gameObject.SetActive(true);
            audioManager.PlayWin();
        }

        if(justWon){
            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("Menu");
            } else if (Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void checkReset(){
        if(reset){
            deathText.gameObject.SetActive(true);
        }

        if(reset && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SetCountText() {
       countText.text =  "Count: " + count.ToString();
    }

    public void NewPickUp(){
        count++;
        audioManager.PlayNewPickUp();
    }

    public void DeathHandler(){
        reset = true;
        audioManager.PlayDeath();
        timeStamp.PauseTime();
        if(player != null){
            player.Freeze();
            Enemy.FreezeAll();
        }
    }
}