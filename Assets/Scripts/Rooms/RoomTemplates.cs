using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;

    private bool spawnedBoss = false;
    private bool spawnedShop = false;

    public GameObject boss;
    public GameObject shop;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(waitTime <= 0 && spawnedBoss == false){
            for(int i = 0; i < rooms.Count; i++){
                if(i == rooms.Count-1){
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        } else {
            waitTime -= Time.deltaTime;
        }

        if(waitTime <= 0 && spawnedShop == false){
            for(int i = 0; i < rooms.Count; i++){
                if(i == rooms.Count/2){
                    Instantiate(shop, rooms[i].transform.position, Quaternion.identity);
                    spawnedShop = true;
                }
            }
        } else {
            waitTime -= Time.deltaTime;
        }

    }
}
