using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private void Start() {
        Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name != "Player"){
            Debug.Log("Door Blocked");
            Destroy(other.gameObject, 0.5f);
        }
    }
}
