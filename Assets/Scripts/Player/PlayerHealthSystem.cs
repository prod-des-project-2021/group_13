using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{

    public float maxhealth = 100f;
    public float health = 100f;

    public HealthBar healthBar;

    private TextMesh healthText;


    // Start is called before the first frame update

    void Awake() {

        healthBar = GameObject.Find("Health bar").GetComponent<HealthBar>();
    }

    void Start()
    {
        healthBar.SetMaxHealth(maxhealth);
        healthBar.SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
        healthBar.SetHealth(health);

        if(health <= 0){
            SceneManager.LoadScene("GameOver");
        }

    }
}
