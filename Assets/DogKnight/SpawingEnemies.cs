using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawingAliens : MonoBehaviour
{

    private float timing = 3f;
    public GameObject[] spawners;
    public GameObject spawn;
    void Start()
    {
        Invoke(nameof(randomSpawning),2f);
        // randomSpawning(spawners);
    }

    void randomSpawning()
    {
        var index = Random.Range (0, spawners.Length);
        GameObject ball = (GameObject)Instantiate(spawn, spawners[index].transform.position, spawners[index].transform.rotation);
        
        Invoke(nameof(randomSpawning),timing);
    }

    void Update()
    {
        timing -= 0.00001f;
    }
}
