using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public RawImage parallaxImage;
    [Range(0.001f,0.1f)]
    public float speed;
    private void Start()
    {
        StartCoroutine(parallax());
    }
    IEnumerator parallax()
    {
        yield return new WaitForSeconds(0.05f);
        parallaxImage.uvRect = new Rect(parallaxImage.uvRect.x + speed, 0, 1, 1);
        StartCoroutine(parallax());
    }
}
