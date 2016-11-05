using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    Transform sword;
    Animation swordAnim;

	// Use this for initialization
	void Start ()
	{
	    sword = transform.FindChild("FirstPersonCharacter/Sword");
	    swordAnim = sword.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Attack"))
        {
            if(!swordAnim.isPlaying)
	            swordAnim.Play("Sword_Swing");
        }
	}

    public void Attack()
    {
       // Debug.Log("Attack!");
    }

 



}
