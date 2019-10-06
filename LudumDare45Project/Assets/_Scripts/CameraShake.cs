using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public KeyCode dash;

    public float time_shake = .15f;
    public float force_shake = .25f;


    //void CamShake ()
    //{
    //   // if (Input.GetKeyDown(dash))
    //    //{
    //        StartCoroutine(Shake(time_shake, force_shake));
    //    //}
    //}
    
    
    
    
    
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {   
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

}
