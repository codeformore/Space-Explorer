using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour
{
    
    private Slider shieldBar;
    public Text shieldBarText;
    public PlayerVitals vitals;

    void Start()
    {

        shieldBar = GetComponent<Slider>();
        shieldBar.maxValue = vitals.MaxShieldHealth;
        shieldBar.value = vitals.ShieldHealth;

    }

    void Update()
    {

        if (shieldBar.value != vitals.ShieldHealth)
            shieldBar.value = vitals.ShieldHealth;

        shieldBarText.text = vitals.ShieldHealth + "/" + vitals.MaxShieldHealth;

    }

}
