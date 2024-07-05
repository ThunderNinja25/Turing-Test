using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneControl : MonoBehaviour
{
    [SerializeField] private GameObject cutscene;
    [SerializeField] private PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Singleton.OnLevelStart.AddListener(PlayCutscene);
    }

    public void PlayCutscene()
    {
        director.Play();
    }

    public virtual void OnCutsceneEnter()
    {
        GameManager.Singleton.OnLevelStart.RemoveListener(PlayCutscene);
        GameManager.Singleton.LockPlayer(true);
    }

    public virtual void OnCutsceneFinish()
    {
        GameManager.Singleton.LockPlayer(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cutscene.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    
}
