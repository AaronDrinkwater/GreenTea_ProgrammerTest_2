using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePooling : MonoBehaviour
{
    public GameObject pipePrefab;
    private GameObject[] pipes;
    public Transform pipeTransform;

    public int pipePoolingSize = 15;
    private int currentPipe = 0;
    private int maxNumOfPipes = 100;

    private float spawnTimer;
    public float spawnRate = 5f;
    public float pipeMin = 2f;
    public float pipeMax = 5f;
    //private float spawnZPos = 10f;
    //private float spawnXPos = 10f;

    public float spawnXPosition = 0;
    public float spawnZPosition = 5;

    private float test = 10f;

    private Vector3 objectPoolingPosition = new Vector3(-20f, -25f,-20f);

    void Start()
    {
        pipes = new GameObject[pipePoolingSize];

        for (int i = 0; i < pipePoolingSize; i++)
        {
            pipes[i] = GameObject.Instantiate(pipePrefab, objectPoolingPosition, Quaternion.identity);
            //pipes[i] = GameObject.Instantiate(pipePrefab, objectPoolingPosition + pipeTransform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(GameControl.instance.isGameOver == false && spawnTimer >= spawnRate)
        {
            spawnTimer = 0;
            float spawnYPosition = Random.Range(pipeMin, pipeMax);

            pipes[currentPipe].transform.position = new Vector3(spawnXPosition, spawnYPosition, 0 + 1);
            currentPipe++;

            if(currentPipe >= pipePoolingSize)
            {
                currentPipe = 0;
            }
        }
    }

    Vector3 GeneratePipesPosition()
    {
        return new Vector3(0, 0, 0);
    }
}
