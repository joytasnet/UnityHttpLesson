using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageController2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect(){
        string url="https://joytas.net/php/man.jpg";
        UnityWebRequest uwr=UnityWebRequestTexture.GetTexture(url);
        yield return uwr.SendWebRequest();
        if(uwr.isHttpError || uwr.isNetworkError){
            Debug.Log(uwr.error);
        }else{
            Texture texture=DownloadHandlerTexture.GetContent(uwr);

            Sprite sp=Sprite.Create(
                (Texture2D)texture,
                new Rect(0,0,texture.width,texture.height),
                new Vector2(0.5f,0.5f)
                );
            Image image=GetComponent<Image>();
            image.rectTransform.sizeDelta=new Vector2(
                texture.width,texture.height);
            image.sprite=sp;

        }

    }
}
