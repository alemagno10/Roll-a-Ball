using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeStamp : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float gameTime;
    private bool pause = false;

    void Update(){
        gameTime += Time.deltaTime;
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
}