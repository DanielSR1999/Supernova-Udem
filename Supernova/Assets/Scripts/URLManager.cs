using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLManager : MonoBehaviour
{
    public void OpenURL(string http)
    {
        Application.OpenURL(http);
    }
}
