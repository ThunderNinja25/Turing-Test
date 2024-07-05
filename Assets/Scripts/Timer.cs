using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float gameTime;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TextMeshProUGUI timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowGameTime();
        gameTime -= Time.deltaTime;

        if( gameTime <= 0)
        {
            
            TimerEnded();
            this.enabled = false;
        }
    }

    public void TimerEnded()
    {
        gameTime = 0;
        uiManager.LevelIncomplete();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowGameTime()
    {
        timerText.text = gameTime.ToString();
    }
}
