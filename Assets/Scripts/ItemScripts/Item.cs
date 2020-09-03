using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    
    public int id;
    public string itemName;
    public string description;
    //Measured in kg
    public float weight;

    public Sprite icon;

}
