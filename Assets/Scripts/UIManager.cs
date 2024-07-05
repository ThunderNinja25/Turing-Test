using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject reticle;
    [SerializeField] private GameObject robotKyle;
    [SerializeField] private CutsceneControl cutsceneControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReticleActivate()
    {
        reticle.SetActive(true);
        robotKyle.SetActive(false);
    }

    public void ReticleDeactivate()
    {
        reticle.SetActive(false);
    }

    public void LevelIncomplete()
    {
        cutsceneControl.PlayCutscene();
    }
}
