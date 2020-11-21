using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaserLight : MonoBehaviour 
{
	public int HitPoint = 50;
	public ParticleSystem particle = null;
	public int lifeTime = 2;

	void Start()
	{
		Destroy (this.gameObject, lifeTime);
	}


	void OnTriggerEnter (Collider other)
	{
		this.GetComponent<Renderer> ().enabled = false;
		this.GetComponent<Collider> ().enabled = false;
		}

}
