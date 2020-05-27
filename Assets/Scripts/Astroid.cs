using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Astroids/New Astroid Type", fileName = "New Astroid Type")]
public class Astroid : ScriptableObject
{

    public int id;
    public string astroidName;
    public Vector2 healthRange;
    public float massScalar;
    public AstroidLoot[] loots;
    public Sprite[] sprites;
    
    //Biomes? Rarity?

    
    [System.Serializable]
    public struct AstroidLoot
    {
        public int itemToSpawn;
        [Range(0f, 100f)] public float chance;
    }

}
