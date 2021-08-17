using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Image progress;

    // Start is called before the first frame update
    void Start()
    {
        LoadButton();
    }
    private void LoadButton()
    {
        StartCoroutine("LoadLevelAsync");
    }
    IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            progress.fillAmount = asyncOperation.progress;

            if (asyncOperation.progress>=0.9f)
            {
                asyncOperation.allowSceneActivation = true;
                yield return new WaitForEndOfFrame();
            }
        }
        
    }
}
