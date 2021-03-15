using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemyScript : MonoBehaviour
{
    public Image healthbarBar;
    void Start()
    {
        //healthbarBar = GetComponentInChildren<Image>();
        //Debug.Log(healthbarBar);
    }

    public void UpdateHealthBar(float currentHealth, float maxZombieHealth)
    {
        //Debug.Log("Health bar percent : " + currentHealth / maxZombieHealth);
        healthbarBar.fillAmount = currentHealth / maxZombieHealth;
        //Debug.Log("Fucking turkshit");
    }
}
