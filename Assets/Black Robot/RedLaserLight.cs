using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserLight : MonoBehaviour 
{
	public int hitPoint = 50;
	public ParticleSystem particle = null;
	public int lifeTime = 1 ;

	void Start ()
	{
		Destroy (this.gameObject, lifeTime);
	}


	void OnTriggerEnter (Collider other)
	{
		this.GetComponent<Renderer> ().enabled = false;
		this.GetComponent<Collider> ().enabled = false;

	}
		
}