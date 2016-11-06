using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Player Player;

    public float MaxHP = 10f;
    public float HP = 10f;

    public float Damage = 10f;

    float chargeTime = 0f;

    Rigidbody rb;

    Animator anim;

    // Use this for initialization
    void Start ()
	{
	    Player = FindObjectOfType<Player>();
	    HP = MaxHP;

	    rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(HP<=0f)
            Destroy(gameObject);

        if(rb.velocity.magnitude>0.1f) anim.Play("walk");
        else anim.Play("idle");

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation( Player.transform.position - transform.position, Vector3.up), 0.1f);
        transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y,0f);

	    if (chargeTime <= 0f && Random.Range(0, 50) == 0)
	    {
	        chargeTime = Random.Range(0.5f, 5f);
	    }

	    if (chargeTime > 0f)
	    {
	        chargeTime -= Time.deltaTime;
            rb.AddForce((Player.transform.position - transform.position).normalized * 10f, ForceMode.Acceleration);
        }
	}

    public void Hit()
    {
        rb.AddForce((transform.position - Player.transform.position).normalized * 100f, ForceMode.Impulse);
        HP-=Player.Damage;
    }
}
