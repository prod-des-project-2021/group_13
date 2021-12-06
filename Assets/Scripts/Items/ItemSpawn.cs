using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    private List<GameObject> items;

    void Start() {

        items = GameObject.FindGameObjectWithTag("Items").GetComponent<Items>().items;

        Invoke("SpawnRandomItem", 0.1f);

    }

    void SpawnRandomItem(){

        int itemID = Random.Range(0, items.Count);

        Instantiate(items[itemID], transform.position, Quaternion.identity);

    }


}
