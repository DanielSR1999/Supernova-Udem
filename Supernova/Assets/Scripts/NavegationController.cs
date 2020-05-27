using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavegationController : MonoBehaviour
{
    public void EnableDisable(GameObject objectToEnable)
    {
        if(objectToEnable.activeSelf)
        {
            objectToEnable.SetActive(false);
        }
        else
        {
            objectToEnable.SetActive(true);
        }
    }
    public void ChangeScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
