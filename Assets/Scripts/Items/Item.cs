using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int cost;

    public bool inStore;
    
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
    

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "ShopSpawn"){
            inStore = true;
            Debug.Log(inStore);
        }
    }
}
