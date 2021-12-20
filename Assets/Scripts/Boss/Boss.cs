using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform player;

    private GameObject enemytotal;

    public bool isFlipped = false;

    private void Start() {
        Invoke("SetPlayerTransform", 0.5f);

        enemytotal = GameObject.Find("EnemyCount");

        enemytotal.GetComponent<EnemyCount>().total += 1;
    }

    private void SetPlayerTransform(){
        player = GameObject.Find("Player").transform;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
