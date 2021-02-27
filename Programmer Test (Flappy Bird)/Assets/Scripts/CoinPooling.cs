using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPooling : MonoBehaviour
{
    public GameObject coinPrefab;
    private GameObject[] coins;
    public Transform coinTransform;

    public int coinPoolingSize = 5;
    private int currentCoin = 0;

    private float spawnTimer;
    public float spawnRate = 5f;
    public float coinMin = 2f;
    public float coinMax = 5f;

    public float spawnXPosition = 0;

    private Vector3 objectPoolingPosition = new Vector3(-15f, -30f, -25f);

    void Start()
    {
        coins = new GameObject[coinPoolingSize];

        for (int i = 0; i < coinPoolingSize; i++)
        {
            coins[i] = GameObject.Instantiate(coinPrefab, objectPoolingPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (GameControl.instance.isGameOver == false && spawnTimer >= spawnRate)
        {
            spawnTimer = 0;
            float spawnYPosition = Random.Range(coinMin, coinMax);

            coins[currentCoin].transform.position = new Vector3(spawnXPosition, spawnYPosition, 0);
            currentCoin++;

            if (currentCoin >= coinPoolingSize)
            {
                currentCoin = 0;
            }
        }
    }
}
