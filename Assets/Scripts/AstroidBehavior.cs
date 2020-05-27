using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidBehavior : MonoBehaviour
{
    
    public int id;
    public GameObject pickUpPrefab;

    private Astroid astroidInfo;
    private float health;
    private float mass;

    void Start()
    {

        astroidInfo = AstroidLibrary.GetAstroid(id);
        health = Random.Range(astroidInfo.healthRange.x, astroidInfo.healthRange.y);
        mass = health * astroidInfo.massScalar;
        GetComponent<Rigidbody2D>().mass = mass;
        GetComponent<SpriteRenderer>().sprite = astroidInfo.sprites[Random.Range(0, astroidInfo.sprites.Length)];

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        BulletBehavior bullet = other.GetComponent<BulletBehavior>();
        health -= bullet.damage;
        if (health <= 0)
        {

            foreach (Astroid.AstroidLoot loot in astroidInfo.loots)
            {
                float ran = Random.Range(0f, 100f);
                if (ran <= loot.chance)
                {
                    
                    GameObject itemDrop = Instantiate(pickUpPrefab);
                    itemDrop.transform.position = transform.position;
                    itemDrop.GetComponent<pickUp>().itemToPickUp = loot.itemToSpawn;
                    
                }
            }

            Destroy(gameObject);

        }

        Destroy(other.gameObject);

    }

}