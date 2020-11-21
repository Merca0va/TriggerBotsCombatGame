using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRobotMove : MonoBehaviour
{
    private Animator myAnimator;
    public float moveSpeed = 7.0f;
    public float rotationSpeed = 100.0f;


    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        if (myAnimator)
        {
            myAnimator.SetFloat("Front", Input.GetAxis("Vertical"));

            myAnimator.SetFloat("Side", Input.GetAxis("Horizontal"));

        }

        Move();
        Side();

    }

    void Move()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed;

        this.transform.Translate(0, 0, move * Time.deltaTime);
    }

    void Side()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        this.transform.Rotate(0, rotation * Time.deltaTime, 0);
    }
}
