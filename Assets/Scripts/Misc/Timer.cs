using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private float timer;

    private GameObject player;

    private Text timerbox;

    void Start()
    {
        timer = 0f;
        player = GameObject.Find("Player");
        timerbox = this.gameObject.GetComponent<Text>();

    }

    void Update()
    {
        if(player.GetComponent<PlayerHealthSystem>().health > 0){
            timer += Time.deltaTime;
            timerbox.text = timer.ToString("0.00");
        } 

        
        
    }
}
