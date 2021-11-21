using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    //State list
    private enum State{
        Resting,
        Patrolling,
        Chasing,
        Attacking
    }

    public float patrolSpeed;
    public float chaseSpeed;
    public float rayLength;

    public float visionDistance = 10;
    public float attackDistance = 2;

    private bool movingRight = true;

    private State state;

    private TextMesh stateText;

    private bool isWaiting = false;
    private bool isAttacking = false;

    public Transform groundDetection;
    public Transform wallDetection;

    private GameObject player;

    private Animator anim;


    void Awake(){
        //Access temporary textbox to display State 
        //ONLY FOR DEBUGGING
        stateText = this.transform.Find("StateDisplay").GetComponent<TextMesh>();

        state = State.Patrolling;
        player = GameObject.Find("Player");

        anim = this.transform.Find("Sword").GetComponent<Animator>();
    }

    void Start(){
        
    }
    
    void Update(){
        //State Machine
        switch (state){
        default:
        case State.Resting:
            Rest();
            break;
        case State.Patrolling:
            Patrol();
            break;
        case State.Chasing:
            Chase();
            break;
        case State.Attacking:
            Attack();
            break;
        }


        //Visualizing Raycasts for debugging
        Debug.DrawRay(groundDetection.position, transform.TransformDirection(Vector2.down) * rayLength);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * visionDistance);
    }

    //Rest before resuming patrol
    void Rest(){
        stateText.text = "Resting";
        if(!isWaiting){
            StartCoroutine(ledgeTurn());
        }
    }

    //Basic patrolling, stopping at an edge
    void Patrol(){

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayLength);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.down, rayLength);

        transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);

        stateText.text = "Patrolling";
        
        //Initiate chase if player withing vision and not too high above
        if(Vector3.Distance(transform.position, player.transform.position) < visionDistance && player.transform.position.y <= transform.position.y + 2){
            state = State.Chasing;
        }
        if(groundInfo.collider == false || wallInfo.collider == true){
            state = State.Resting;
        }

    }

    //Chase player
    void Chase(){

        transform.Translate(Vector2.right * chaseSpeed * Time.deltaTime);

        stateText.text = "Chasing";

        //Turning towards player
        if(player.transform.position.x > transform.position.x){
            transform.eulerAngles = new Vector3(0,0,0);
        } else {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        //Start attacking player if withing attack range
        if(Vector3.Distance(transform.position, player.transform.position) < attackDistance){
            state = State.Attacking;
        }

        //Go back to rest and patrol if player goes too far or too high
        //if(Vector3.Distance(transform.position, player.transform.position) > visionDistance || player.transform.position.y >= transform.position.y + 3){
       //     state = State.Resting;
        //}

    }

    //Attack player
    void Attack(){
        stateText.text = "Attacking";
        if(!isAttacking){
            StartCoroutine(Attacking());
        }
    }

    //A very hacky function for resting at ledges and walls before turning
    IEnumerator ledgeTurn(){
        
        isWaiting = true;

        float waitTime = Random.Range(1,4);

        yield return new WaitForSeconds(waitTime);

        if(movingRight == true ){
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
            state =  State.Patrolling;
            isWaiting = false;
        } else {
            transform.eulerAngles = new Vector3(0,0,0);
            movingRight = true;
            state =  State.Patrolling;
            isWaiting = false;
        }
    }

    IEnumerator Attacking(){
        isAttacking = true;
        anim.SetBool("Attacking", true);
        float animTime = 1f;
        yield  return new WaitForSeconds(animTime);
        if(Vector3.Distance(transform.position, player.transform.position) > attackDistance){
            anim.SetBool("Attacking", false);
            state =  State.Chasing;
            isAttacking = false;
        } else {
            isAttacking = false;
            anim.SetBool("Attacking", false);
        }
    }
}
