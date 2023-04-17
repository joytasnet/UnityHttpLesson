using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageController : MonoBehaviour
{
    Vector2 sd;
    RectTransform rt;
    Sprite defalutSp;
    Sprite sp;
    Image img;
    void Start(){
        rt=GetComponent<RectTransform>();
        img=GetComponent<Image>();
        defalutSp=img.sprite;
        sd=rt.sizeDelta;
        StartCoroutine(HttpConnect());
        StartCoroutine(ChangeSize());
    }
    IEnumerator ChangeSize(){
        //yield return null;
        int count=0;
        while(true){
            count++;
            rt.sizeDelta=sd;
            yield return new WaitForSeconds(1f);
            rt.sizeDelta=sd*2f;
            yield return new WaitForSeconds(2f);
            rt.sizeDelta=sd*0.5f;
            yield return new WaitForSeconds(2f);
            rt.sizeDelta=sd*3f;
            if(count % 2 != 0){
                img.sprite=sp;
            }else{
                img.sprite=defalutSp;
            }
        }
    }
    IEnumerator HttpConnect(){
        string url="https://joytas.net/php/man.jpg";
        UnityWebRequest uwr=UnityWebRequestTexture.GetTexture(url);
        yield return uwr.SendWebRequest();
        if(uwr.isHttpError || uwr.isNetworkError){
            Debug.Log(uwr.error);
        }else{
            Texture texture=DownloadHandlerTexture.GetContent(uwr);

            sp=Sprite.Create(
                (Texture2D)texture,
                new Rect(0,0,texture.width,texture.height),
                new Vector2(0.5f,0.5f)
                );

        }

    }
    

}
