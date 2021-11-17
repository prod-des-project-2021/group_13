using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float rayLength;
    private bool movingRight = true;

    private bool isWaiting = false;

    public Transform groundDetection;

    public Transform wallDetection;

    void Start(){
        
    }
    
    void Update(){

        if(isWaiting == false){
            Patrol();
        }

    }

    //Basic patrolling, stopping at an edge

    void Patrol(){

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayLength);

        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.down, rayLength);

        if(groundInfo.collider == false || wallInfo.collider == true){
            StartCoroutine(ledgeTurn());
        }
    }

    IEnumerator ledgeTurn(){
    
    isWaiting = true;

    yield return new WaitForSeconds(1);

        if(movingRight == true ){
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
            isWaiting = false;
        } else {
            transform.eulerAngles = new Vector3(0,0,0);
            movingRight = true;
            isWaiting = false;
        }
    }
}
