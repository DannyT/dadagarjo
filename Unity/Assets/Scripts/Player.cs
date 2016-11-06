using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float MaxHP = 100f;
    public float HP;

    public float Damage = 1f;

    public Slider HealthSlider;

    Transform hand;
    Animator swordAnim;
    Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
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
