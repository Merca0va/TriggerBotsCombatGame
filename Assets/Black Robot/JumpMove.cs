using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMove : MonoBehaviour 
{
	private Animator myAnimator;
	public float Speed = 5;
	private Rigidbody rigid;
	public LayerMask groundLayer;
	public CapsuleCollider col;
    public float jumpForce = 10;

	void Start()
	{
		myAnimator = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody> ();
		col = GetComponent<CapsuleCollider> ();
	}

	void Update ()
	{

		if (IsGrounded() && Input.GetKeyDown (KeyCode.Space)) 
		{
			myAnimator.Play ("JumpMode");
			rigid.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}


	private bool IsGrounded()
	{
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), 9f, groundLayer) ;
	}

}
