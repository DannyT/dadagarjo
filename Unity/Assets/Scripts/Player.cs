using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float MaxHP = 100f;
    public float HP;

    public float Damage = 1f;

    public Slider HealthSlider;

    Transform hand;
    Animator swordAnim;
    Rigidbody rb;
    public int RoomsCompleted;

    public Dictionary<string, AudioSource> Sounds = new Dictionary<string, AudioSource>();


    // Use this for initialization
    void Start ()
	{
	    Instance = this;

        foreach (AudioSource a in GetComponents<AudioSource>())
        {
            if(a.clip!=null)
                Sounds.Add(a.clip.name, a);
        }

        HP = MaxHP;
	    hand = transform.FindChild("FirstPersonCharacter/Hand");
	    swordAnim = hand.GetComponent<Animator>();
	    rb = GetComponent<Rigidbody>();

        InvokeRepeating("SendStatus", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Attack"))
        {
	        swordAnim.Play("attack",0);
            if (!Sounds["whoosh_2"].isPlaying)
            {
                Sounds["whoosh_2"].pitch = Random.Range(0.9f, 1.1f);
                Sounds["whoosh_2"].Play();
            }
        }

	    HP = Mathf.Clamp(HP, 0f, MaxHP);

	    HealthSlider.value = HP;
	}

    public void Attack()
    {
       // Debug.Log("Attack!");
    }

    public void Hit(Enemy e)
    {
        
    }

    void SendStatus()
    {
        SocketController.Instance.proxy.Invoke("SetGameState", new PlayerDto() {Health = HP});
    }

    void OnTriggerEnter(Collider col)
    {
        var e = col.GetComponentInParent<Enemy>();
        if (e != null && e.IsAttacking && col.name=="EnemyAttack")
        {
            Debug.Log("player is attacked!");
            //rb.AddForce((transform.position-e.transform.position).normalized * 100f, ForceMode.Impulse);
            HP -= e.Damage;
        }
    }

}

public class PlayerDto
{
    public float Health;
}
