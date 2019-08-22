using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public int restTime;
    public int restCheckRange;
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;

    private int restCheck = 0;
    private float restTimer = 0;
    private bool restTimerReached = true;

    void Update()
    {
        if (!restTimerReached)
        {
            //increment timer
            restTimer += Time.deltaTime;
        }

        if (!restTimerReached && restTimer > restTime)
        {
            //time to stop resting
            restTimerReached = true;
        }

        if (restTimerReached)
        {
            //move character and check if it should rest
            MoveCharacter(); 

            restCheck = Random.Range(0, 300);

            if(restCheck == 5)
            {
                //if time for rest... reset timer to 0 and set timer reached flag to false
                restTimerReached = false;
                restTimer = 0;
            }
        }
    }

    void MoveCharacter()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);


        if (groundCheck.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }



}
