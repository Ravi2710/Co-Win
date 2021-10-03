using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerObstacles : MonoBehaviour
{
    public float speed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
