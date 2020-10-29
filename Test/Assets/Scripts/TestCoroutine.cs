using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using AT = Tools.AnimationTools;

public class TestCoroutine : MonoBehaviour
{

    [SerializeField] float TranslateDuration;
    [SerializeField] float TranslateCoef;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(AT.TranslateCoroutine(transform, transform.position + Random.insideUnitSphere * 3, 1));
        StartCoroutine(RandomTranslationCoroutine(10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,100,40),"Rescale"))
        {
            //StartCoroutine(AT.ScaleCoroutine(transform, scaleCoef, scaleDuration));
        }
    }

    IEnumerator RandomTranslationCoroutine(int nMaxTranslation)
    {
        int n = 0;
        while(n++<nMaxTranslation)
        {
            yield return StartCoroutine(AT.TranslateCoroutine(transform, transform.position + Random.insideUnitSphere * 3, 1));
        }
    }

    //IEnumerator InOutActionCoroutine(IEnumerator coroutine, )
    //{

    //}

    IEnumerator FetchDataFromWeb(string url)
    {
        byte[] bytes;
        UnityWebRequest request = new UnityWebRequest(url);
        AsyncOperation async = request.SendWebRequest();
        yield return async;
        if (string.IsNullOrEmpty(request.error))
        {
            bytes = request.uploadHandler.data;
        }
    }
}
