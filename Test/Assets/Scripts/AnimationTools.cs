using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
    public static class AnimationTools
    {
        public static IEnumerator ScaleCoroutine(Transform transform, float scaleCoef, float scaleDuration)
        {
            float elapsedTime = 0;
            Vector3 startScale = transform.localScale;
            Vector3 targetScale = startScale * scaleCoef;


            while(elapsedTime<scaleDuration)
            {
                float k = elapsedTime / scaleDuration;
                transform.localScale = Vector3.Lerp(startScale, targetScale, k);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = targetScale;

        }

        public static IEnumerator TranslateCoroutine(Transform transform, Vector3 targetPosition, float translateDuration)
        {
            float elapsedTime = 0;
            Vector3 startTranslation = transform.position;
            //Vector3 targetTranslation = startTranslation * distanceTranslation;

            //Yield break permet de sortir d'une coroutine
            while (elapsedTime < translateDuration)
            {
                float k = elapsedTime / translateDuration;
                transform.position = Vector3.Lerp(startTranslation, targetPosition, Mathf.Sin(k*Mathf.PI*0.5f)); //Accéleration -->  Décelation  (Easing  Methods)
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
        }
    }
}