using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawners;
    [SerializeField] float interval = 5f;
    [SerializeField] GameObject enemyPrefab;

    private bool isGameStart = true;

    private void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    private IEnumerator InstantiateEnemy()
    {
        while (isGameStart)
        {
            yield return new WaitForSeconds(interval);
            interval -= 0.0001f;
            int _spawnIndex = Random.Range(0, spawners.Length);
            Instantiate(enemyPrefab, spawners[_spawnIndex].transform);
        }
    }
}
