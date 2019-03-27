using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckSpawn : MonoBehaviour
{
    public Text ducksCount;
    private int ducks = 0;

    public GameObject duckGO;

    // Start is called before the first frame update
    void Start()
    {
        ducksCount.text = "10 ducks";
        var i = 0;
        while (i < 10)
        {
            var duck = Instantiate(duckGO) as GameObject;
            duck.transform.position = new Vector2(Random.Range(-3, 3), 5);
            duck.transform.parent = transform;
            GameEvents.OnDucksUpdated(1);
            i++;
        }

        GameEvents.DucksUpdated += HandleDuckUpdate;
    }

    private void HandleDuckUpdate(int cnt)
    {
        ducks += cnt;
        ducksCount.text = "" + ducks;
    }
}
