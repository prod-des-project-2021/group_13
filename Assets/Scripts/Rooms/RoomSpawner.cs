using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 --> Need bottom
    // 2 --> Need top
    // 3 --> Need left
    // 4 --> Need right

    private RoomTemplates templates;
    private int rand;
    private bool spawned;

    public float waitTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if(spawned == false){
            if(openingDirection == 1){
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                // Spawn a room with a BOTTOM door.
            } else if(openingDirection == 2){
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                // Spawn a room with a TOP door.
            } else if(openingDirection == 3){
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                // Spawn a room with a LEFT door.
            } else if(openingDirection == 4){
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                // Spawn a room with a RIGHT door.
            }
        }
        spawned = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }

    }
}
