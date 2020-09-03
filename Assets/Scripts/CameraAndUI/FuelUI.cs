using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    
    private Slider fuelBar;
    public PlayerVitals vitals;

    void Start()
    {

        fuelBar = GetComponent<Slider>();
        fuelBar.maxValue = vitals.FuelCapacity;
        fuelBar.value = vitals.Fuel;

    }

    void Update()
    {

        if (fuelBar.value != vitals.Fuel)
            fuelBar.value = vitals.Fuel;

    }

}
