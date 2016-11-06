using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float MaxHP = 100f;
    public float HP;

    public float Damage = 1f;
   
    Transform hand;
    Animator swordAnim;

	// Use this for initialization
	void Start ()
	{
	    HP = MaxHP;
	    hand = transform.FindChild("FirstPersonCharacter/Hand");
	    swordAnim = hand.GetComponent<Animator>();

        InvokeRepeating("SendStatus", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Attack"))
        {
	            swordAnim.Play("attack",0);
        }
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
        SocketController.Instance.proxy.Invoke("PlayerStatus", new PlayerDto() {Health = HP});
    }



}

public class PlayerDto
{
    public float Health;
}
