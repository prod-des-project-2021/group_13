using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    public enum OccilationFuntion { Sine, Cosine }

    private GameObject player;

    public float healStrength;

    private Vector3 startpos;
    private Vector3 endpos;

    public float wiggleSpeed = 5;
    public float wiggleScale = 4;

    public float rotSpeed = 5;
    public float rotScale = 2;

    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        startpos = this.transform.position;
        endpos = startpos + Vector3.right;
        player = GameObject.Find("Player");

        timer = 0;

        
    }

    void FixedUpdate()
    {
        Wiggle();

    }
 


    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D col) {
        
        if(col.gameObject.name == "Player"){

            HealPlayer();
            Destroy(this.gameObject);

        }

    }

    void HealPlayer(){

        player.GetComponent<PlayerHealthSystem>().health += healStrength;

    }


    void Wiggle(){

        timer += Time.deltaTime;
        this.transform.Rotate(0, 0, oscillate(timer, rotSpeed, rotScale));
        this.transform.Translate(Vector2.right * oscillate(timer, wiggleSpeed, wiggleScale /1000));
        
    }

    float oscillate(float time, float speed, float scale){

        return Mathf.Cos(time * speed / Mathf.PI) * scale;

    }

}
