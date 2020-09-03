using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedAnim : MonoBehaviour
{
    
    public Sprite[] sprites;
    private float divisionFactor;
    public PlayerVitals vitals;
    private SpriteRenderer displaySprite;

    void Start()
    {

        divisionFactor = vitals.MaxHullStrength / sprites.Length;
        displaySprite = GetComponent<SpriteRenderer>();
        displaySprite.sprite = sprites[sprites.Length - 1];

    }

    void OnEnable()
    {

        PlayerVitals.OnTakeDamage += ChangeSprite;

    }

    void OnDisable()
    {

        PlayerVitals.OnTakeDamage -= ChangeSprite;

    }

    void ChangeSprite()
    {

        displaySprite.sprite = sprites[Mathf.CeilToInt(vitals.HullStrength / divisionFactor) - 1];

    }

}
