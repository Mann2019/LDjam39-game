using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    public GameObject loadPanel;
    public Slider loader;
    public float waitTime;

	public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadStatus(sceneIndex));
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator LoadStatus(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadPanel.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loader.value = progress;
            yield return waitTime;
        }
    }
}
