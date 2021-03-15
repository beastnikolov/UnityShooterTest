using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieStatus : MonoBehaviour
{
    // Start is called before the first frame update

    public int zombieHealth;
    public int zombieMaxHealth;
    int randomDropChance;

    public GameObject boostPrefab;
    public Pickup medkitDrop;
    public Pickup ammoDrop;

    GameObject zombieKillCounter;

    public GameObject deathEffectPrefab;

    public GameObject bloodEffect;

    public GameObject hpBarTest;

    GameObject HealthBarPrefab;

    public GameObject damagePopup;


    void Start()
    { 
        zombieKillCounter = GameObject.Find("ZombieCounter");
        zombieHealth = zombieMaxHealth;
        HealthBarPrefab = Instantiate(hpBarTest, transform.position, Quaternion.identity);
        HealthBarPrefab.transform.SetParent(GameObject.Find("HealthbarCanvas").transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHealth <= 0)
        {
            Die();
        }
        HealthBarPrefab.transform.position = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
        if (GetComponentInChildren<ZombieAI>().isFollowingPlayer())
        {
            HealthBarPrefab.SetActive(true);
        } else
        {
            HealthBarPrefab.SetActive(false);
        }
    }

    public void takeDamage(int damage)
    {
        zombieHealth -= damage;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        HealthBarPrefab.GetComponent<HealthBarEnemyScript>().UpdateHealthBar(zombieHealth, zombieMaxHealth);
        GameObject damagePopupObject = Instantiate(damagePopup, transform.position, Quaternion.identity);
        damagePopupObject.GetComponent<TextMeshPro>().text = damage.ToString();
        damagePopupObject.transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
        Destroy(damagePopupObject, 0.4f);
    }

    void Die()
    {
        //Debug.Log("Zombie has died");
        randomDropChance = Random.Range(0, 2);
        if (randomDropChance == 1)
        {
            GameObject boostDrop = Instantiate(boostPrefab, transform.position, Quaternion.identity);
            if (Random.value > 0.5f)
            {
                
                boostDrop.GetComponent<ItemPickUpManager>().pickupItem = medkitDrop;
            } else
            {
                boostDrop.GetComponent<ItemPickUpManager>().pickupItem = ammoDrop;
                
            }
            boostDrop.GetComponent<ItemPickUpManager>().updateItemSprite();
        }
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        zombieKillCounter.GetComponent<ZombieKillCounterScript>().addKill();
        GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(HealthBarPrefab, 1f);
        Destroy(deathEffect, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            zombieHealth -= collision.gameObject.GetComponent<BulletManager>().getWeaponDamage();
        }
    }
}
