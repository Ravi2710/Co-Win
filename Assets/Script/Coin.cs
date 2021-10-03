using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource capsuleCollectSound;
    void Start()
    {
        capsuleCollectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(72 * Time.deltaTime, 0, 72 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //gameObject.GetComponent<AudioSource>().Play();
            player.numberOfCapsules += 5f;
            //Debug.Log("Coins: " + player.numberOfCapsules);
            capsuleCollectSound.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            //Destroy(gameObject);

            StartCoroutine(waitforsound());
        }
    }



    IEnumerator waitforsound()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
