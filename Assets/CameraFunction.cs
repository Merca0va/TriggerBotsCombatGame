using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunction : MonoBehaviour 
{

	public Transform player = null;
	public Transform target = null;
	public Vector3 speed = new Vector3 (4.0f, 2.0f, 1.0f);
	public Vector3 nextPosition = Vector3.zero;
	public enum CameraState {none, LookAtPlayer, FollowPosition, Both};
	public CameraState cameraState = CameraState.none;



	void LateUpdate ()
	{
		switch (cameraState)
		{
		case 
			CameraState.none:
			break;

		case
			CameraState.FollowPosition:
			FollowPosition ();
			break;

		case 
			CameraState.LookAtPlayer:
			LookAtPlayer ();
			break;

		case
			CameraState.Both:
			FollowPosition ();
			LookAtPlayer ();
			break;
		}

	}


	void FollowPosition()
	{

		nextPosition.x = Mathf.Lerp (this.transform.position.x, target.position.x, speed.x * Time.deltaTime);

		nextPosition.y = Mathf.Lerp (this.transform.position.y, target.position.y, speed.x * Time.deltaTime);

		nextPosition.z = Mathf.Lerp (this.transform.position.z, target.position.z, speed.z * Time.deltaTime);

		this.transform.position = nextPosition;

	}


	void LookAtPlayer ()
	{
		this.transform.LookAt (player.position);

	}
}
