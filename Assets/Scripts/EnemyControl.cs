using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    private Animator animator;
    public int[] movementVector = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        movementVector[0] = -1;
        movementVector[1] = 0;
        movementVector[2] = 1;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;

        // int randomVectorX = Random.Range(0, 3);
        // int randomVectorY = Random.Range(0, 3);

        Vector3 playerCoordinates = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 enemyCoordinates = GameObject.FindGameObjectWithTag("Enemy").transform.position;

        float playerXCoor = playerCoordinates.x;
        float playerYCoor = playerCoordinates.y;

        float enemyXCoor = enemyCoordinates.x;
        float enemyYCoor = enemyCoordinates.y;

        float playerDeltaX = playerXCoor - enemyXCoor;
        float playerDeltaY = playerYCoor - enemyYCoor;

        
        if (playerDeltaY > 0)
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);

            if (Mathf.Abs(playerDeltaX) > Mathf.Abs(playerDeltaY))
            {
                if (playerDeltaX < 0)
                {
                    dir.x = -1;
                    animator.SetInteger("Direction", 3);
                }
                else if (playerDeltaX > 0)
                {
                    dir.x = 1;
                    animator.SetInteger("Direction", 2);
                }
            }
        }
        else if (playerDeltaY < 0)
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);

            if (Mathf.Abs(playerDeltaX) > Mathf.Abs(playerDeltaY))
            {
                if (playerDeltaX < 0)
                {
                    dir.x = -1;
                    animator.SetInteger("Direction", 3);
                }
                else if (playerDeltaX > 0)
                {
                    dir.x = 1;
                    animator.SetInteger("Direction", 2);
                }
            }
        }

        dir.Normalize();
        // animator.SetBool("IsMoving", dir.magnitude > 0);

        // GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}