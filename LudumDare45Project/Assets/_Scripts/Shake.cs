using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float time_shake = 0.5f;
    public float force_shake = 5f;

    public bool shaking = false;

    void Update()
    {
        if (shaking == true)
        {
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * force_shake);
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

        yield return new WaitForSeconds(time_shake);

        shaking = false;
        transform.position = originPos;
    }
}

