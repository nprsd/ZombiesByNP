using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    [Header("Audio")]
    public AudioSource audio;
    public AudioClip laugh;
    
    [Header("Level")]
    public string levelToLoad;

    [Header("Animators")]
    public Animator cameraAnim;
    public Animator anim;

    [Header("Bools")]
    public bool inputCheck = false;
    public bool homePosR = false;
    public bool homePosL = false;

    [Header("GameObjects")]
    public GameObject rStick;
    public GameObject lStick;
    public GameObject text;
    void Update () {
        if (!inputCheck)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Start"))
            {
                inputCheck = true;
                anim.SetBool("started", true);
                Debug.Log("ANIM");
                audio.PlayOneShot(laugh);
                StartCoroutine(loadLevel());
            }
        }

        if(Input.GetButtonDown("rsClick"))
        {
            homePosR = !homePosR;
            if (homePosR)
            {
                cameraAnim.SetBool("rank", true);
                lStick.SetActive(false);
            }
            else
            {
                cameraAnim.SetBool("rank", false);
                lStick.SetActive(true);

            }
        }

        if (Input.GetButtonDown("lsClick"))
        {
            homePosL = !homePosL;
            if (homePosL)
            {
                cameraAnim.SetBool("credits", true);
                rStick.SetActive(false);

            }
            else
            {
                cameraAnim.SetBool("credits", false);
                rStick.SetActive(true);
            }
        }
    }

    IEnumerator loadLevel()
    {
        text.SetActive(false);
        yield return new WaitForSeconds(3f);
        Initiate.Fade(levelToLoad, Color.black, 10.0f);
        yield return new WaitForSeconds(0.1f);
    }


}
