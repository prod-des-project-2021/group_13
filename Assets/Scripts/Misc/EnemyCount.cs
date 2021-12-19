using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{

    public int total = 0;

    private Text text;

    void Start() {
        
        text = this.GetComponent<Text>();

    }
    // Update is called once per frame
    void Update()
    {
        if(total > 0){
            text.text = "Enemies left: " + total.ToString();
        } else {
            text.text = "A door has opened...";
        }


    }
}
