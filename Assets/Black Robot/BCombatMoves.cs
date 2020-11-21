using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCombatMoves : MonoBehaviour
{
    public int Health = 1000;
    public int LaserAmount = 20;
    public GameObject Laser = null;
    public Transform Socket = null;
    public GameObject Explosion = null;
    public GameObject Damage = null;
    private Animator myAnimator;


    void Start()
    {
        myAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        Shoot();
        StartCoroutine (Launch ());
        Punch();

    }



    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (LaserAmount > 0)
            {
                myAnimator.Play("LaserLaunching");

            

            }
        }
    }

    
    IEnumerator Launch ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            yield return new WaitForSeconds(0.4f);
            LaserAmount--;

            GameObject obj = Instantiate(Laser, Socket.position, Socket.rotation) as GameObject;

            obj.name = "LaserLight Red";
        }


    }
    

	void Punch ()
	{
		if (Input.GetButtonDown ("Fire2")) 
		{
			myAnimator.Play ("Punch");

		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WPunchHand")
        {
            int hp = other.GetComponent<Punch>().HitPoint;
            HealthState (hp);
            myAnimator.Play("LightDamage");
        }

        if (other.name == "LaserLight Blue")
        {
            int hp = other.GetComponent<BlueLaserLight>().HitPoint;
            HealthState(hp);
            myAnimator.Play("HeavyDamage");
            GameObject obj = Instantiate (Damage, this.transform.position, this.transform.rotation) as GameObject;
            obj.name = "Exploson6";
        }
    }

    void HealthState(int hp)
    {
        if (Health > 0)
        {
            Health -= hp;
        }
        else
        {
            Debug.Log("GAME OVER");
            myAnimator.Play("HeavyDamage");
            Destroy(this.gameObject);
            GameObject obj = Instantiate (Explosion, this.transform.position, this.transform.rotation) as GameObject;
            obj.name = "Exploson1";
        }
    }

}
