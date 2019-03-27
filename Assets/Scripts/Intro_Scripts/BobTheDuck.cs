﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class BobTheDuck : MonoBehaviour
{
    public string duckName = "Bob";
    [HideInInspector]
    public bool dead;
    public Color duckColor;
    public int[] someNumbers;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            gameObject.SetActive(false);
        }
    }
}
