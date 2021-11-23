using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawn : MonoBehaviour
{

    public GameObject healthPotion;
    public GameObject poisonPotion;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomPotion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomPotion(){

        var randomSeed = GetRandomSeed();

        switch (randomSeed){
            default:
            case 1:
                SpawnHealth();
                break;
            case 2:
                SpawnPoison();
                break;
            case 3:
                break;
        }

    }

    private float GetRandomSeed(){

        int seed = Random.Range(1, 4);

        return seed;

    }

    void SpawnHealth(){

        Instantiate(healthPotion, this.transform.position, Quaternion.identity);

    }

    void SpawnPoison(){

        Instantiate(poisonPotion, this.transform.position, Quaternion.identity);

    }

}
