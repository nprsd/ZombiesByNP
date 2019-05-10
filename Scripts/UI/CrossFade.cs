using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossFade : MonoBehaviour {

    public Text text;

	void Update ()
    {

        StartCoroutine(crossfade());
	}

    IEnumerator crossfade()
    {
        text.CrossFadeAlpha(0.0f, 1.0f, false);
        yield return new WaitForSeconds(1.0f);
        text.CrossFadeAlpha(255.0f, 1.0f, false);
        yield return new WaitForSeconds(0.5f);
    }

}
