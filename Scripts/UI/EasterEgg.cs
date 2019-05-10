using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{

    public static int counter = 0;
    public GameObject spaceShip;
    public static bool isComplete = false;
    AudioSource aud;
    public AudioClip xfiles;
    bool played = false;
	void Start ()
    {
        counter = 0;
        aud = GetComponent<AudioSource>();
	}
	
	void Update ()
    {

        if (counter == 5)
        {
            spaceShip.SetActive(true);
            spaceShip.GetComponent<DissolveSphere>().enabled = true;
            isComplete = true;
            if (!played)
            {
                played = true;
                aud.PlayOneShot(xfiles);
            }
        }
		
	}
}
