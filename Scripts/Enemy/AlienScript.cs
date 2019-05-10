using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    
    Animator anim;
    public bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    public void deathAnim()
    {
        anim.SetBool("isDead", true);
        this.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 2.0f);
    }

}
