using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System;

public class GoogleMapInterface : MonoBehaviour
{
    private const string BASE_URL = "https://maps.googleapis.com/maps/api/staticmap?";
    private const string API_KEY = "AIzaSyB_zq1ZhPJaBMIw0F-aXW6ggYJ_32Ofw0w";
    private Texture2D _cashedTexture;


    public void LoadMap(float latitude, float longitude, float zoom, Vector2 size, Action<Texture2D> onComplete)
    {
        StartCoroutine(C_LoadMap(latitude, longitude, zoom, size, onComplete));
    }
    
    IEnumerator C_LoadMap(float latitude, float longitude, float zoom, Vector2 size, Action<Texture2D> onComplete)
    {
        string url = 
            BASE_URL + 
            "center=" + latitude + "," + longitude +
            "&zoom=" + zoom.ToString() + 
            "&size=" + size.x.ToString() + "x" + size.y.ToString() +
            "&key=" + API_KEY;

        Debug.Log($"[{nameof(GoogleMapInterface)}] : Request map texture ... {url}");

        url = UnityWebRequest.UnEscapeURL(url); //Url�� ����  Web ��û
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url); //Texture�� ���� ��û 

        yield return req.SendWebRequest();  //��û ����

        _cashedTexture = DownloadHandlerTexture.GetContent(req); // ���� Texture�� RAW �̹����� ����
        onComplete.Invoke(_cashedTexture);
    }

}
