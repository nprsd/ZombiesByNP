using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelManager : MonoBehaviour
{
    public Sprite[] pLevels;
    public Image currentImage;
    public GameObject promotionText;
    public Animator anim;
    AudioSource audio;
    public AudioClip promotionSFX;

    void Start()
    {
        audio = this.GetComponent<AudioSource>();    
    }

    void Update ()
    {
        if (LevelSystem.level >= 7)
        {
            currentImage.sprite = pLevels[6];
        }
        else
        {
            currentImage.sprite = pLevels[LevelSystem.level - 1];
        } 
    }

    public void promotePlayer()
    {
        StartCoroutine(promotion());
    }

    IEnumerator promotion()
    {
        //Set player pref (level)..
        promotionText.SetActive(true);
        anim.SetBool("isPromoted", true);
        audio.PlayOneShot(promotionSFX);
        yield return new WaitForSeconds(2.0f);
        promotionText.SetActive(false);
    }
}
