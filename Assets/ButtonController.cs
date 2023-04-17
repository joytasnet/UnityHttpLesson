using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ButtonController : MonoBehaviour
{
    public InputField et1;
    public InputField et2;
    public Text result;

    public void btClick(){
        string x=et1.text;
        string y=et2.text;
        StartCoroutine(HttpConnect(x,y));
    }
    IEnumerator HttpConnect(string x,string y){
        WWWForm form = new WWWForm();
        form.AddField("x",x);
        form.AddField("y",y);
        string url="https://joytas.net/php/calc.php";
        UnityWebRequest uwr= UnityWebRequest.Post(url,form);
        yield return uwr.SendWebRequest();
        if(uwr.isHttpError || uwr.isNetworkError){
            Debug.Log(uwr.error);
        }else{
            result.text=uwr.downloadHandler.text;
        }

    }
}
