using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WRobotTrigger : MonoBehaviour
{
	
	private float lastTime = 1.0f;
	private float delayTime = 2.0f;
	private Animator myAnimator;
    private Rigidbody rigid;

    public int health = 2000;
	public GameObject Laser = null;
    public GameObject Damage = null;
    public GameObject Explosion = null;
	public Transform Lens = null;
    public float JumpSpeed = 5;
    public float JumpForce = 18;
    public LayerMask groudLayer;
    public CapsuleCollider cap;
    public enum MoveSet { none, Punch, Jump};
    public MoveSet moveSet = MoveSet.none;


	void Start()
	{
		myAnimator = GetComponent<Animator> ();
        rigid = GetComponent<Rigidbody>();
        cap = GetComponent<CapsuleCollider>();


    }


	void Update()
	{
        switch(moveSet)
        {
            case MoveSet.none: break;

            case MoveSet.Jump: Jump();
                break;
            case MoveSet.Punch: Punch();
                break;
        }
        
		Shoot ();
    }





    void Shoot()
    {

        if (Time.time > lastTime + delayTime)
        {
            lastTime = Time.time;
            delayTime = lastTime;
            myAnimator.Play("Laser");

            StartCoroutine(Blast());

        }
    }


        IEnumerator Blast()
        {
          
            
                yield return new WaitForSeconds(1);
                GameObject obj = Instantiate(Laser, Lens.position, Lens.rotation) as GameObject;
                obj.name = "LaserLight Blue";
		 

	}

   void Punch()
    {
        myAnimator.Play("Fist");
    }

    void Jump()
    {
        if (IsGounded())
        {
            myAnimator.Play("Jump");
            rigid.AddForce (Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }


        private bool IsGounded()
        {
        return Physics.CheckCapsule(cap.bounds.center, new Vector3(cap.bounds.center.x, cap.bounds.min.y, cap.bounds.center.z), cap.radius * .9f, groudLayer);
        }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BPunchHand")
        {
            int hp = other.GetComponent<Punch>().HitPoint;
            myAnimator.Play("LightDamage");
            HealthState(hp);
        }

        if (other.name == "LaserLight Red")
        {
            int hp = other.GetComponent<RedLaserLight>().hitPoint;
            myAnimator.Play("HeavyDamage");
            HealthState(hp);
            GameObject obj = Instantiate(Damage, this.transform.position, this.transform.rotation) as GameObject;
            obj.name = "Exploson8";
        }
    }

    void HealthState(int hp)
    {
        if (health > 0 )
        {
            health -= hp;
        }
        else
        {
            Debug.Log("You win!!!");
            myAnimator.Play("HeavyDamage");

            Destroy(this.gameObject);
            GameObject obj = Instantiate(Explosion, this.transform.position, this.transform.rotation) as GameObject;
            obj.name = "Exploson2";
            

        }
    }
}

