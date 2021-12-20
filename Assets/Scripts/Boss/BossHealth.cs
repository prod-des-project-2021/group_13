using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health = 100;

	private GameObject enemytotal;

	private void Start() {
		enemytotal = GameObject.Find("EnemyCount");
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		enemytotal.GetComponent<EnemyCount>().total -= 1;

		Destroy(gameObject);
	}
}
