using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutSpawnerScript : MonoBehaviour
{

    public GameObject Doughnut;
    public float spawnRate = 3;
    private float timer = 0;
    private float spawnTime = 0;
    public float heightOffset = 7;

    // Start is called before the first frame update
    void Start()
    {
        spawnDoughnut();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
            spawnTime += Time.deltaTime;
        }
        else
        {
            if (spawnRate > 0.7)
            {
                spawnRate -= (float)0.1;
            }
            spawnDoughnut();
            timer = 0;
        }

    }

    void spawnDoughnut()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(Doughnut, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            
    }
}
