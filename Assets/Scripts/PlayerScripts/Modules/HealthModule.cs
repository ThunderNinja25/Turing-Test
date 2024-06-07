using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class HealthModule : MonoBehaviour
{

    [SerializeField] private int maxHealthPoints;
    private int healthPoints;
    private bool isDead;

    //public UnityEvent<int> OnHealthChanged;
    public Action<int> OnCSharpHealthChanged;
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damageCaused)
    {
        Debug.Log(healthPoints);
        healthPoints -= damageCaused;
        //OnHealthChanged.Invoke(healthPoints);
        OnCSharpHealthChanged.Invoke(healthPoints);
        if(healthPoints <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
    }
}
