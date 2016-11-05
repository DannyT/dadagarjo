using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Hit()
    {
        transform.GetComponentInParent<Player>().Attack();
    }

    void OnCollisionEnter(Collision col)
    {
        Enemy e = col.transform.GetComponent<Enemy>();
        if (e != null && GetComponent<Animation>().isPlaying)
        {
            e.HitBySword();
        }
    }
}
