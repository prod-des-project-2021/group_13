using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{

    public float health = 100f;
    public float currentHealth;

    public HealthBar healthBar;

    private TextMesh healthText;


    // Start is called before the first frame update

    void Awake() {
        
        healthText = this.transform.Find("HealthDisplay").GetComponent<TextMesh>();

    }

    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
        healthText.text = health.ToString();

        currentHealth = health;
        healthBar.SetHealth(currentHealth);



    }
}
