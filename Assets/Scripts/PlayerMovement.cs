using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public int playerEnergy = 30;
    int currentEnergy;

    public Rigidbody2D rb;
    public Camera camera;

    public GameObject playerEnergyUI;
    TextMeshProUGUI playerEnergyText;

    Vector2 movement;
    Vector2 mousePosition;

    PlayerStatus playerStatus;

    public GameObject playerStatusTextObject;
    TextMeshProUGUI playerText;

    bool pickupRange = false;
    bool pickedItem = false;




    // Update is called once per frame

    private void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerEnergyText = playerEnergyUI.GetComponent<TextMeshProUGUI>();
        currentEnergy = playerEnergy;
        playerText = playerStatusTextObject.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        if (playerStatus.currentHealth > 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

            
            {

            }

            if (Input.GetKeyDown("f"))
            {
                moveSpeed = 1f;
            }
            else if (Input.GetKeyUp("f"))
            {
                moveSpeed = 5f;
            } else
            {
                if (Input.GetKeyDown("space") && playerEnergy > 0)
                {
                    moveSpeed = 10f;
                } else if (Input.GetKeyUp("space"))
                {
                    moveSpeed = 5f;
                }
            }
            
        } else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        //Item pickup

        if (pickupRange == true && Input.GetKeyDown("e") && !GetComponent<Shooting>().isPlayerReloading())
        {
            pickedItem = true;
        }
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePosition - rb.position;
        float directionAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = directionAngle;

        if (moveSpeed > 5f)
        {
            currentEnergy--;
            if (currentEnergy <= 0)
            {
                moveSpeed = 5f;
            }
        }
        else
        {
            currentEnergy++;
        }
        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }
        else if (currentEnergy > playerEnergy)
        {
            currentEnergy = playerEnergy;
        }
        playerEnergyText.SetText("Energy: " + currentEnergy + "/" + playerEnergy);

        // Item pickup

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickups" && !GetComponent<Shooting>().isPlayerReloading())
        {
            playerText.text = "Press E to pick the item up";
            playerText.enabled = true;
            pickupRange = true;
        }

        if (collision.gameObject.tag == "BoostPickups")
        {
            var boostPickup = collision.gameObject.GetComponent<ItemPickUpManager>().getPickedItem() as Pickup;
            if (boostPickup)
            {
                if (boostPickup.itemName == "Medkit")
                {
                    Debug.Log("Medkit pickup");
                    if (playerStatus.currentHealth < playerStatus.maxHealth)
                    {
                        playerStatus.currentHealth += boostPickup.boostAmount;
                        if (playerStatus.currentHealth > playerStatus.maxHealth)
                        {
                            playerStatus.currentHealth = playerStatus.maxHealth;
                        }
                        Destroy(collision.gameObject);
                    }
                } else if (boostPickup.itemName == "Ammo")
                {
                    gameObject.GetComponent<Shooting>().Ammunition += boostPickup.boostAmount;
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Pickups" && pickedItem && !GetComponent<Shooting>().isPlayerReloading())
        {
            Destroy(collision.gameObject);
            pickedItem = false;
            //Pick item up
            var groundItem = collision.gameObject.GetComponent<ItemPickUpManager>().getPickedItem() as Weapon;
            if (groundItem)
            {
                GetComponent<PlayerEquipment>().equipWeapon(groundItem);
            } else
            {
                var groundArmor = collision.gameObject.GetComponent<ItemPickUpManager>().getPickedItem() as Armor;
                GetComponent<PlayerEquipment>().equipArmor(groundArmor);
            }
            // Update UI , Shooting & Sound
            GameObject.Find("EquippedWeapon").GetComponent<EquippedWeaponManager>().updateEquippedWeapon();
            GameObject.Find("Player").GetComponent<Shooting>().updateEquippedWeapon();
            GameObject.Find("PlayerAudioSource").GetComponent<GunSoundManager>().ChangeWeaponSound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickups" && !GetComponent<Shooting>().isPlayerReloading())
        {
            playerText.enabled = false;
            pickupRange = false;
        }
    }

}