using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
    public bool IsOpen = false;

    Animator anim;

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Player>() != null)
        {
            anim.Play("open", 0);
            IsOpen = true;
        }
    }
}
