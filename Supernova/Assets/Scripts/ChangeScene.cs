using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class ChangeScene : MonoBehaviour
{
    public bool FirstScene = false;
    public VideoPlayer video;
   public void changeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    private void Start()
    {
        if(FirstScene)
        {
            float time = (float)video.clip.length;
            StartCoroutine(LoadNextScene(time));
        }
    }

    IEnumerator LoadNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }
}
