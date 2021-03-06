using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float damage = 20;
    public LayerMask enemyLayers;


    public Animator anim;
    private GameObject weapon;

    private float startAttackTimer = 0.4f;
    private float currentAttackTimer;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && currentAttackTimer <= 0) // left control
        {
            Attack();
        }

        currentAttackTimer -= Time.deltaTime;
    }

    void Attack()
    {

        //Animate the attack
        anim.SetTrigger("Attack");
        
        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("enemy hit");
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        currentAttackTimer = startAttackTimer;
    }

    //show the attack hitbox, for testing purpose

  
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
