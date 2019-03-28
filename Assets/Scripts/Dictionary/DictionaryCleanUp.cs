﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    IEnumerator LoadWordList()
    {
        string filePath = Path.Combine(
            Application.streamingAssetsPath, inputFile);
        string result = null;
        if (filePath.Contains("://"))
        {
            WWW www = new WWW(filePath);
            yield return www;
            result = www.text;
        }
        else
        {
            result = File.ReadAllText(filePath);
        }

        var words = result.Split('\n');
        var allWords = new HashSet<string>();
        foreach (var w in words)
        {
            var word = w.TrimEnd();
            if (string.IsNullOrEmpty(word))
                continue;

            if (word.Length < minLength)
                continue;

            if (word.IndexOfAny(badChars) != -1)
                continue;

            if (!allWords.Contains(word.ToLower()))
                allWords.Add(word.ToLower());
        }

        var sr = File.CreateText(
            Path.Combine(Application.streamingAssetsPath, outputFile));
        foreach (var w in allWords)
        {
            sr.WriteLine(w);
        }

        sr.Close();
    }
}
