using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinSystem : MonoBehaviour
{

    public float coins = 0;

    private GameObject coinDisplay;
    // Start is called before the first frame update
    void Start()
    {
        coinDisplay = GameObject.Find("Coins");
        coinDisplay.GetComponent<Text>().text = coins.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<Text>().text = coins.ToString();
    }
}
