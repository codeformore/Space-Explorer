using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HullUI : MonoBehaviour
{
    private Slider hullBar;
    public Text hullBarText;
    public PlayerVitals vitals;

    void Start()
    {

        hullBar = GetComponent<Slider>();
        hullBar.maxValue = vitals.MaxHullStrength;
        hullBar.value = vitals.HullStrength;

    }

    void Update()
    {

        if (hullBar.value != vitals.HullStrength)
            hullBar.value = vitals.HullStrength;

        hullBarText.text = vitals.HullStrength + "/" + vitals.MaxHullStrength;

    }
}
