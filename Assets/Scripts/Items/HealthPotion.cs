using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    private GameObject player;

    public float healStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        
        if(col.gameObject.name == "Player"){

            HealPlayer();
            Destroy(this.gameObject);

        }

    }

    void HealPlayer(){

        player.GetComponent<PlayerHealthSystem>().health += healStrength;

    }
}
