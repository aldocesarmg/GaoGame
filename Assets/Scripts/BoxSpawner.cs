using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BoxSpawner : MonoBehaviour
{
    public GameObject obstacle;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn = 4;
    public float decreaseTime = 0.5f;
    public float minTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            timeBtwSpawn = startTimeBtwSpawn;
            if (Random.Range(0, 10) > 0.5f)
            {
                Instantiate(obstacle, transform.position, Quaternion.identity);
            }
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
