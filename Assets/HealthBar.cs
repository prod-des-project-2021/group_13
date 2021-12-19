using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float maxhealth)
    {
        slider.maxValue = maxhealth;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        slider.value = GameObject.Find("Player").GetComponent<PlayerHealthSystem>().health;
    }


}
