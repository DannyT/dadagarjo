using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Player Player;

    public float MaxHP = 10f;
    public float HP = 10f;

    public float Damage = 10f;

    float chargeTime = 0f;

    public bool IsAttacking = false;

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

        

        if (!IsAttacking)
	    {
	        if (rb.velocity.magnitude > 0.1f) anim.Play("walk");
	        else anim.Play("idle");

            if (Vector3.Distance(transform.position, Player.transform.position) < 2f)
            {
                IsAttacking = true;
                anim.Play("attack");
            }
        }
        else 
	    {
            AnimatorClipInfo[] ainfo = anim.GetCurrentAnimatorClipInfo(0);
            if (ainfo.Length ==1)
            {
                if (ainfo[0].clip.name != "attack") IsAttacking = false;
            }
        }

	    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation( Player.transform.position - transform.position, Vector3.up), 0.1f);
        transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y,0f);

	    if (chargeTime <= 0f && Random.Range(0, 50) == 0)
	    {
	        chargeTime = Random.Range(0.5f, 5f);
	    }

	    if (chargeTime > 0f && !IsAttacking)
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
