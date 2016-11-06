using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Player Player;

    public float MaxHP = 10f;
    public float HP = 10f;

    public float Damage = 10f;

    Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
	    Player = FindObjectOfType<Player>();
	    HP = MaxHP;

	    rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(HP<=0f)
            Destroy(gameObject);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation( Player.transform.position - transform.position, Vector3.up), 0.1f);
	}

    public void Hit()
    {
        rb.AddForce((transform.position - Player.transform.position).normalized * 100f, ForceMode.Impulse);
        HP-=Player.Damage;
    }
}
