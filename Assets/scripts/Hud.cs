using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hud : MonoBehaviour {
    public  player;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI winText;
    public TimeStamp timeStamp;

    private float count = 0;
    private bool reset = false;

    void Start(){
        winText.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);
        SetCountText();
    }

    void Update(){
        SetCountText();
        checkWin();
        checkReset();
    }

    void checkWin(){
        if (count == 16){
            timeStamp.PauseTime();
            player.Freeze();
            winText.gameObject.SetActive(true);
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

    public void IncreaseCount(){
        count++;
    }

    public void DeathHandler(){
        reset = true;
        timeStamp.PauseTime();
    }
}