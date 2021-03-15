using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    GameObject PlayerObject;
    ZombieAI zombieAI;
    private Rigidbody2D rb;
    private Vector2 movementVector;


    // Start is called before the first frame update
    void Start()
    {
        zombieAI = gameObject.GetComponentInChildren<ZombieAI>();
        rb = this.GetComponent<Rigidbody2D>();
        PlayerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerObject != null && zombieAI.isFollowingPlayer())
        {
            Vector2 enemyDirection = PlayerObject.transform.position - transform.position;
            float directionAngle = Mathf.Atan2(enemyDirection.y, enemyDirection.x) * Mathf.Rad2Deg;
            rb.rotation = directionAngle;
            transform.position = Vector3.MoveTowards(transform.position, PlayerObject.transform.position, 2f * Time.deltaTime);
        }
    }
}
