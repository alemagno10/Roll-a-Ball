using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hud : MonoBehaviour {
    public TextMeshProUGUI countText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI options;
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
        options.gameObject.SetActive(false);
        player = FindObjectOfType<playerController>();
        enemies = FindObjectsOfType<Enemy>();
        timeStamp = FindObjectOfType<TimeStamp>();
        audioManager = FindObjectOfType<AudioManager>();
        SetCountText();
    }

    void Update(){
        SetCountText();
        checkWin();
        checkRedirect();
    }

    void checkWin(){
        if (count == 20 && !justWon){
            justWon = true;
            timeStamp.PauseTime();
            player.Freeze();
            Enemy.FreezeAll();
            winText.gameObject.SetActive(true);
            options.gameObject.SetActive(true);
            audioManager.PlayWin();
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
        deathText.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        reset = true;
        audioManager.PlayDeath();
        timeStamp.PauseTime();

        if(player != null){
            player.Freeze();
            Enemy.FreezeAll();
        }
    }

    private void checkRedirect(){
        Redirect(reset);
        Redirect(justWon);
    }

    private void Redirect(bool flag){
        if(flag){
            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("Menu");
            } else if (Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}