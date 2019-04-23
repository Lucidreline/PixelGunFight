using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] float coinDropFrequency;
    [SerializeField] List<GameObject> coinPrefabs;
    [SerializeField] float maxFreq = 5f;
    [SerializeField] float minFreq = 2f;
    float dropXPos;
    
    
    bool coinLoop = true;
    
    void Update()
    {
        if (coinLoop) StartCoroutine(DropRandomCoin());
    }

    IEnumerator DropRandomCoin()
    {
        coinLoop = false;
        coinDropFrequency = Random.Range(minFreq, maxFreq);

        yield return new WaitForSeconds(coinDropFrequency);

        Vector2 dropPos = new Vector2 (Random.Range(-5f, 5f), transform.position.y );
        int RandomIndex = Random.Range(0, coinPrefabs.Count);
        GameObject coinPrefab = coinPrefabs[RandomIndex];
        Instantiate(coinPrefab, dropPos, Quaternion.identity);
        coinLoop = true;
    }

}
