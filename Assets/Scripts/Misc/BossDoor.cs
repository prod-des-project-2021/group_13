using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDoor : MonoBehaviour
{
    
    private GameObject enemycount;


    private void Start() {
        enemycount = GameObject.Find("EnemyCount");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            if(enemycount.GetComponent<EnemyCount>().total <= 0){
                Debug.Log("Door Open");
                SceneManager.LoadScene("BossScene");
            } else {
                Debug.Log("Enemies alive. Door closed.");
            }
        }
    }

}
