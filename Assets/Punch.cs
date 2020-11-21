using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour 
{
	public int HitPoint = 10;


	void OnTriggerEnter (Collider other)
	{
		GetComponent<SphereCollider> ();

	}

}
