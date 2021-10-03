using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("MoveLevel");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveLevel()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.transform.parent.position = new Vector3(0, 0, gameObject.transform.position.z + 20);
    }
}
