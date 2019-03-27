using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordListLoader : MonoBehaviour
{
    public string fileName = "words/1k.txt";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadWordList");
    }

    IEnumerator LoadWordList()
    {
        string filePath = Path.Combine(
            Application.streamingAssetsPath, fileName);

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
            var words = result.Split('\n');

            foreach (var w in words)
            {
                var word = w.TrimEnd();
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }
                Debug.Log(word);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
