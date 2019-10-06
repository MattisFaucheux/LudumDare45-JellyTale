using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public bool shaking = false;

    void Update()
    {
        if (shaking == true)
        {
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * 10f);
            newPos.y += 0.5f;
            newPos.z = transform.position.z;
            newPos.x -= 4.5f;

            transform.position = newPos;
        }
    }

    public void ShakeMe()
    {
        StartCoroutine(ShakeObject());
    }

    IEnumerator ShakeObject()
    {
        Vector3 originPos = transform.position;

        if (shaking == false)
        {
            shaking = true;
        }

        yield return new WaitForSeconds(0.75f);

        shaking = false;
        transform.position = originPos;
    }
}

