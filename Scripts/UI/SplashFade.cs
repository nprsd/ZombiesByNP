using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashFade : MonoBehaviour 
{

    public Image splash;
    public string level;
    public ParticleSystem explosion;
    public AudioSource aud;
    public AudioClip boom;

	IEnumerator Start ()
    {
        aud.PlayOneShot(boom);
        splash.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
        explosion.Play();
        yield return new WaitForSeconds(2.5f);
        explosion.Stop();
        fadeOut();
        yield return new WaitForSeconds(2.5f);
        Initiate.Fade(level, Color.black, 2.0f);

    }

    void fadeIn()
    {
        splash.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void fadeOut()
    {
        splash.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
