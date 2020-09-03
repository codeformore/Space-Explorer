using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour
{

    //Delegates & Events
    public delegate void TakeDamageAction();
    public static event TakeDamageAction OnTakeDamage;

    //Fields
    private float shieldHealth;
    private float maxShieldHealth;
    private float hullStrength;
    private float maxHullStrength;
    private float fuel;
    private float fuelCapacity;
    private float shieldRechargeTime;
    private float shieldRechargRate;

    //Properties
    public float ShieldHealth { get => shieldHealth; }
    public float MaxShieldHealth { get => maxShieldHealth; }
    public float HullStrength { get => hullStrength; }
    public float MaxHullStrength { get => maxHullStrength; }
    public float Fuel { get => fuel; }
    public float FuelCapacity { get => fuelCapacity; }
    public float ShieldRechargRate { get => shieldRechargRate; }

    //Functions
    public void TakeDamage(float damage)
    {

        if (shieldHealth > 0)
        {

            if (damage > shieldHealth)
            {

                damage -= shieldHealth;
                shieldHealth = 0;

            }

            else
            {

                shieldHealth -= damage;
                damage = 0;

            }

        }

        if (damage > 0)
        {

            hullStrength -= damage;

        }

        if (hullStrength <= 0)
        {

            Death();

        }

        Debug.Log("Shield Strength: " + shieldHealth + " | Hull Strength: " + hullStrength);
        if (OnTakeDamage != null)
            OnTakeDamage();

    }
    public bool UseFuel(float joules)
    {

        fuel -= joules;

        if (fuel <= 0)
        {

            return false;

        }

        else 
        {

            return true;

        }

    }
    private void Death()
    {

        Debug.LogAssertion("Player Died");

    }

    //Updaters?
    void Awake()
    {

        //Test Numbers
        maxShieldHealth = 100;
        maxHullStrength = 250;
        fuelCapacity = 1000000; //1 million
        shieldRechargeTime = 2;

        //Not Test Numbers
        shieldRechargRate = 1 / shieldRechargeTime;
        fuel = fuelCapacity;
        shieldHealth = maxShieldHealth;
        hullStrength = maxHullStrength;

    }

    void Update()
    {

        if (shieldHealth < maxShieldHealth)
        {

            shieldHealth += (shieldRechargRate * Time.deltaTime);

        } 
            
        if (shieldHealth >= maxShieldHealth)
        {
                
           shieldHealth = maxShieldHealth;
            
        }

    }

}