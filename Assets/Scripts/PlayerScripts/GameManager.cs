using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnLevelStart;
    public UnityEvent OnLevelFinished;
    private PlayerInput player;
    public static GameManager Singleton
    {
        get;

        private set;
    }
    

    

    public static GameManager instance;



    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartLevel();
    }

    public void StartLevel()
    {
        player = FindObjectOfType<PlayerInput>();
        OnLevelStart?.Invoke();
    }

    public void FinishLevel()
    {
        OnLevelFinished?.Invoke();
    }

    public void PlayerDied()
    {

    }

    public void LockPlayer(bool isLocked)
    {
        player.enabled = !isLocked;
    }
}
