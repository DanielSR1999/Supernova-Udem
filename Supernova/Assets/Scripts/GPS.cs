using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    string urlMap = "";
    public RawImage imageMap;
    public Text latitudeText;
    public Text longitudeText;
    public int zoom = 20;

    private void Start()
    {
        StartCoroutine("GetMap");
    }
    public void ZoomIn()
    {
        zoom++;
        StartCoroutine("GetMap");
    }
    public void ZoomOut()
    {
        if(zoom>=0)
        {
            zoom--;
        }
        StartCoroutine("GetMap");
    }
    IEnumerator GetMap()
    {
        Input.location.Start();
        float latitud = Input.location.lastData.latitude;
        yield return latitud;
        float longitud = Input.location.lastData.longitude;
        yield return longitud;

        urlMap = "http://maps.google.com/maps/api/staticmap?center=" + latitud + "," + longitud + "&markers=color:red%7Clabel:S%" + latitud + "," + longitud + "&zoom=" + zoom + "&size=512x512" + "&maptype=hybrid&markers=color:red|label:P|" + latitud + "," + longitud + "&type=hybrid&sensor=true?a.jpg";

        WWW www = new WWW(urlMap);
        yield return www;

        imageMap.texture = www.texture;
        latitudeText.text = "" + latitud;
        longitudeText.text = "" + longitud;
    }
}
