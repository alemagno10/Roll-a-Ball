using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeStamp : MonoBehaviour {
    public TextMeshProUGUI timeText;
    private Hud hud;
    private float playTime = 90f;
    private float gameTime;
    private bool pause = false;

    void Start(){
        gameTime = playTime;
        hud = FindObjectOfType<Hud>();
    }

    void Update(){
        gameTime -= Time.deltaTime;
        checkTime();
        UpdateTime();
    }

    public void UpdateTime(){
        if(!pause){
            int minutes = Mathf.FloorToInt(gameTime / 60);
            int seconds = Mathf.FloorToInt(gameTime % 60);
            int milliseconds = Mathf.FloorToInt((gameTime * 100) % 100);
            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    public void PauseTime(){
        pause = true;
    }

    private void checkTime(){
        if(gameTime <= 0 && !pause){
            pause = true;
            hud.DeathHandler();
        }
    }
}