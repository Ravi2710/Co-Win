using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 70 * Time.deltaTime);
    }

    public void Spawner()
    {
        Instantiate(obstacles[Random.Range(0, 2)], new Vector3(Random.Range(-1.67f, 1.67f), transform.position.y, transform.position.z), Quaternion.identity);
    }
}
