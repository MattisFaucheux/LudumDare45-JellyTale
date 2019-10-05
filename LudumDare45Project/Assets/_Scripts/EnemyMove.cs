﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject _enemyGO;
    Transform _enemyTransform;

    const float moveSpeed = 5.0f;

    public void Awake()
    {
        _enemyGO = GetComponent<GameObject>();
        _enemyTransform = GetComponent<Transform>();
    }

    public void FixedUpdate()
    {
        _enemyTransform.Translate(Vector3.forward * Time.deltaTime);
    }
}
