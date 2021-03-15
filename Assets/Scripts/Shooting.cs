using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;

    public GameObject ammoTextObject;
    TextMeshProUGUI ammoText;

    public GameObject CharacterUIText;
    TextMeshProUGUI characterText;

    public AudioSource gunSound;
    public int Ammunition;
    
    float lastShotTime = 0f;

    bool isReloading = false;

    PlayerStatus playerStatus;
    PlayerEquipment playerInventory;
    public GameObject MuzzleAnimationObject;
    Animator muzzleAnimation;

    int maxRoundsMagazine;
    int currentRounds;
    float bulletForce;
    float shootingDelay;
    float reloadDelay;

    public LineRenderer tracerRenderer;

    public SpriteRenderer muzzleFlashRenderer;


    // Update is called once per frame
    private void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerInventory = GetComponent<PlayerEquipment>();
        //
        maxRoundsMagazine = playerInventory.getEquippedWeapon().maxRoundsPerMag;
        bulletForce = playerInventory.getEquippedWeapon().weaponForce;
        shootingDelay = playerInventory.getEquippedWeapon().weaponDelay;
        reloadDelay = playerInventory.getEquippedWeapon().weaponReloadTime;
        //
        currentRounds = maxRoundsMagazine;
        muzzleAnimation = MuzzleAnimationObject.GetComponent<Animator>();
        ammoText = ammoTextObject.GetComponent<TextMeshProUGUI>();
        characterText = CharacterUIText.GetComponent<TextMeshProUGUI>();
    }

    public void onEquipUpdate()
    {
        maxRoundsMagazine = playerInventory.getEquippedWeapon().maxRoundsPerMag;
        currentRounds = maxRoundsMagazine;
        bulletForce = playerInventory.getEquippedWeapon().weaponForce;
        shootingDelay = playerInventory.getEquippedWeapon().weaponDelay;
        reloadDelay = playerInventory.getEquippedWeapon().weaponReloadTime;
    }

    void Update()
    {
        if (playerStatus.currentHealth > 0)
        {
            ammoText.SetText(currentRounds.ToString() + "/" + Ammunition.ToString());
            if (Input.GetMouseButton(0) && (Time.time > lastShotTime + shootingDelay) && currentRounds > 0 && !isReloading)
            {
                StartCoroutine(Shoot());
                lastShotTime = Time.time;
            }
            if (currentRounds <= 0 && !isReloading)
            {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        characterText.text = "Reloading...";
        characterText.enabled = true;
        yield return new WaitForSeconds(reloadDelay);
        if (Ammunition > 0)
        {
            if (Ammunition >= maxRoundsMagazine)
            {
                currentRounds += maxRoundsMagazine;
                Ammunition -= maxRoundsMagazine;
            } else
            {
                currentRounds += Ammunition;
                Ammunition -= currentRounds;
            }
            characterText.enabled = false;
        }
        isReloading = false;

    }


    IEnumerator Shoot()
    {
        gunSound.Play();
        // muzzleAnimation.SetTrigger("Shot");
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(new Vector3(0, 0, -90)));
        // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        // Destroy(bullet, 0.5f);
         currentRounds--;
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.transform.position, firePoint.transform.right);
       // Debug.DrawRay(firePoint.transform.position, firePoint.transform.right);
        if (hitInfo)
        {
            ZombieStatus zombieStatus = hitInfo.transform.GetComponent<ZombieStatus>();
            if (zombieStatus)
            {
                zombieStatus.takeDamage(playerInventory.getEquippedWeapon().weaponDamage);
                tracerRenderer.SetPosition(0, firePoint.transform.position);
                tracerRenderer.SetPosition(1, hitInfo.point);
            }
        } else
        {
            tracerRenderer.SetPosition(0, firePoint.transform.position);
            tracerRenderer.SetPosition(1, firePoint.transform.position + firePoint.transform.right * 5);
        }
        tracerRenderer.enabled = true;
        muzzleFlashRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        tracerRenderer.enabled = false;
        muzzleFlashRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 
    }

    public bool isPlayerReloading()
    {
        return isReloading;
    }

    public void updateEquippedWeapon()
    {
        maxRoundsMagazine = playerInventory.getEquippedWeapon().maxRoundsPerMag;
        bulletForce = playerInventory.getEquippedWeapon().weaponForce;
        shootingDelay = playerInventory.getEquippedWeapon().weaponDelay;
        reloadDelay = playerInventory.getEquippedWeapon().weaponReloadTime;
        currentRounds = maxRoundsMagazine;
    }
}
