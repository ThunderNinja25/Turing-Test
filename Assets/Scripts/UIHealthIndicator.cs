using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHealthIndicator : MonoBehaviour
{
    [SerializeField] private HealthModule healthModule;
    [SerializeField] private TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        //healthModule.OnHealthChanged.AddListener(UpdateHealthText);
        healthModule.OnCSharpHealthChanged += UpdateHealthText;
    }

    private void UpdateHealthText(int healthValue)
    {
        healthText.text = healthValue.ToString();
    }
}
