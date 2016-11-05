using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    float HP = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(HP<=0f)
            Destroy(gameObject);
	}

    public void HitBySword()
    {
        HP--;

    }
}
