using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathSpawner : MonoBehaviour
{
    public GameObject building;
    public GameObject building2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 50 * Time.deltaTime);
       
    }

    public void spawn()
    {
        Instantiate(building, new Vector3(-3.5f, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(building2, new Vector3(3.5f, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
