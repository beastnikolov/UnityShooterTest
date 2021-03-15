using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public int maxHealth;
    [HideInInspector]
    public int currentHealth;

    public GameObject healthTextObject;
    TextMeshProUGUI hpText;

    public GameObject deathTextObject;
    TextMeshProUGUI deathText;

    public Image damageGraphic;

    public GameObject deathEffectPrefab;


    private void Start()
    {
        currentHealth = maxHealth;
        hpText = healthTextObject.GetComponent<TextMeshProUGUI>();
        deathText = deathTextObject.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        if (gameObject != null)
        {
            hpText.SetText("Health: " + currentHealth.ToString() + "/" + maxHealth.ToString());
            if (currentHealth <= 0)
            {
                StartCoroutine(GameOver());
            }
        }
    }

    IEnumerator GameOver()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        deathText.enabled = true;
        damageGraphic.enabled = true;
        GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4);
        Destroy(deathEffect);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.SetActive(true);
        deathText.enabled = false;
        damageGraphic.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            //Debug.Log("Took zombie damage");
            currentHealth -= 10;
            StartCoroutine(ShowDamageScreen());
        }
    }

    IEnumerator ShowDamageScreen()
    {
        damageGraphic.enabled = true;
        yield return new WaitForSeconds(1);
        damageGraphic.enabled = false;
    }


   

}
