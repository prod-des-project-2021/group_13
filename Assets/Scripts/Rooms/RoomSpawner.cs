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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(openingDirection == 1){
            // Spawn a room with a BOTTOM door.
        } else if(openingDirection == 2){
            // Spawn a room with a TOP door.
        } else if(openingDirection == 3){
            // Spawn a room with a LEFT door.
        } else if(openingDirection == 4){
            // Spawn a room with a RIGHT door.
        }
    }
}
