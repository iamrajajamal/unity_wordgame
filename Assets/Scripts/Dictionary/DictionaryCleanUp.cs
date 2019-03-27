using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryCleanUp : MonoBehaviour
{
    public string inputFile;

    public string outputFile;

    public int minLength = 3;

    public char[] badChars = new char[]
    {
        ' ', '.', '-', '\'', '1',
        '2', '3', '4', '5', '6',
        '7', '8', '9', '0', ':'
    };
    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(inputFile))
            throw new Exception("Missing Input File!");

        if (string.IsNullOrEmpty(outputFile))
            throw new Exception("Missing Output File!");

        StartCoroutine("LoadWordList");
    }
    /*
    IEnumerator LoadWordList()
    {

    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
