using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float currentHealth;
    public float maxHealth;
    public Slider HealthSlider;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthSlider.value = currentHealth;
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = maxHealth;
    }//start

    // Update is called once per frame
    void Update()
    {
        if(currentHealth < 0){
            Destroy(gameObject);
        }
    }//update

    public void SendHeal(float heal){
        currentHealth += heal;
        HealthSlider.value = currentHealth;
    }
}
