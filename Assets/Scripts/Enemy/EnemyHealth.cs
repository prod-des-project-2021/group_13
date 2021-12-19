using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    private GameObject enemy;
    private GameObject player;
    private GameObject enemytotal;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        enemytotal = GameObject.Find("EnemyCount");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died");

        enemytotal.GetComponent<EnemyCount>().total -= 1;
        //Disable the enemy
        Destroy(this.gameObject);

        //Give coins to player
        var reward = Random.Range(0,4);

        player.GetComponent<PlayerCoinSystem>().coins += reward;
    }
}
