using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour
{
    public ParticleSystem Particles;

    Animator anim;

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Hit()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        Enemy e = col.transform.GetComponent<Enemy>();
        if (e != null)
        {
            AnimatorClipInfo[] ainfo =anim.GetCurrentAnimatorClipInfo(0);


            if (ainfo.Length>0)
            {
                for (int idx = 0; idx < ainfo.Length; idx++)
                {
                    //ebug.Log(ainfo[idx].clip.name);
                    if (ainfo[idx].clip.name == "attack_idle")
                    {
                        e.Hit();
                        Particles.Emit(50);
                    }
                }
            }

            
        }
    }
}
