using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    int sceneIndex = 3;

    public Slider slider;

    void Start()
    {
        _LoadLevel(sceneIndex);
    }
    public void _LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
    yield return new WaitForSeconds(5.0f);

    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    while (!operation.isDone)
    {
        float progress = Mathf.Clamp01(operation.progress / .9f);
        slider.value = progress;
        yield return null;
    }
        yield return new WaitForSeconds(2.0f);
    }

}
