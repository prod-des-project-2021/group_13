using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float damage;
    public float range;
    public bool isRanged;

    public float currentHealth;

    private GameObject player;

    private bool playerInRange = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(){

        if(playerInRange && !isRanged){
            player.GetComponent<PlayerHealthSystem>().health -= damage;
            currentHealth = player.GetComponent<PlayerHealthSystem>().health;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        
        if(col.gameObject.name == "Player"){
            
            playerInRange = true;

        }
    }

    void OnTriggerExit2D(Collider2D col) {
        
        if(col.gameObject.name == "Player"){

            playerInRange = false;

        }

    }
}
