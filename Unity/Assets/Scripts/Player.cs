using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    Transform hand;
    Animator swordAnim;

	// Use this for initialization
	void Start ()
	{
	    hand = transform.FindChild("FirstPersonCharacter/Hand");
	    swordAnim = hand.GetComponent<Animator>();
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

 



}
