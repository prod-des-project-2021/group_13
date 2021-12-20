using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    
    private PlatformEffector2D effector;
    private GameObject player;

    private BoxCollider2D collider;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        player = GameObject.Find("Player");
        collider = GetComponent<BoxCollider2D>();
    }

    void Update() {

    if(player.transform.position.y < this.gameObject.transform.position.y + 0.2f){
        collider.isTrigger = true;
    } else if (player.transform.position.y > this.gameObject.transform.position.y + 0.65f) {
        collider.isTrigger = false;
    }

    if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
        collider.isTrigger = true;
    }

    }

    void OnTriggerExit2D(Collider2D other) {
        
        collider.isTrigger = false;

    }


    

}
