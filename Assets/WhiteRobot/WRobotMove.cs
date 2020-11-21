using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WRobotMove : MonoBehaviour
{
	public Transform player = null;
	public Transform tracker = null;
	public Vector3 speed = new Vector3 (4.0f, 0.0f, 2.0f);
	public Vector3 nextPosition = Vector3.zero;
	private Animator myAnimator;



	void Start () 
	{
		myAnimator = GetComponent<Animator> ();
	}

    void LateUpdate()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Laser"))
        {
            return;
        }

        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("HeavyDamage"))
        {
            return;
        }

        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightDamage"))
        {
            return;
        }

        if (myAnimator)
        {
            myAnimator.SetFloat("Front", nextPosition.z);
            myAnimator.SetFloat("Lateral", nextPosition.x);
        }

        FollowPosition();
        LookAtPlayer();
    }

    void FollowPosition()
	{
        
		nextPosition.x = Mathf.Lerp (this.transform.position.x, tracker.position.x, speed.x * Time.deltaTime);

		nextPosition.z = Mathf.Lerp (this.transform.position.z, tracker.position.z, speed.z * Time.deltaTime);
        

		this.transform.position = nextPosition;

	}

    void LookAtPlayer()
    {
        this.transform.LookAt(player.position);
    }
    
}
