using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int cost;

    public bool inStore;

    private GameObject player;

    private GameObject canvas;

    private Transform infoBox;

    public float moveSpeed;
    public float moveMultiplr = 1;
    public float damage;
    public float damageMultiplr = 1;

    public string itemDsc;

    
    void Start()
    {
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
        infoBox = canvas.transform.GetChild(1);
        this.name = this.name.Replace("(Clone)", "");
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

        if(other.gameObject.name == "Player"){
            if(inStore == true){
                if(player.GetComponent<PlayerCoinSystem>().coins >= cost){
                    player.GetComponent<PlayerCoinSystem>().coins -= cost;
                    infoBox.GetComponent<InfoBox>().ShowItemInfo(this.gameObject.name, itemDsc);
                    GiveItem();
                } else {
                    infoBox.GetComponent<InfoBox>().ShowShopError();
                }

            } else {
                infoBox.GetComponent<InfoBox>().ShowItemInfo(this.gameObject.name, itemDsc);
                GiveItem();
            }
        }
    }

    private void GiveItem(){
        //Apply item effects
        player.GetComponent<PlayerPlatformerController>().maxSpeed += moveSpeed;
        player.GetComponent<PlayerPlatformerController>().maxSpeed *= moveMultiplr;
        player.transform.Find("Sword").GetComponent<PlayerCombat>().damage += damage;
        player.transform.Find("Sword").GetComponent<PlayerCombat>().damage *= damageMultiplr;
        
        Destroy(this.gameObject);


    }
}
