using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineCollector : MonoBehaviour
{
    private AudioSource injectionSound;
    public static bool Vaccineon;
    // Start is called before the first frame update
    void Start()
    {
        injectionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(72 * Time.deltaTime,0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //gameObject.GetComponent<AudioSource>().Play();
            //int Vnumber;
            // Vnumber++;
            injectionSound.Play();
            Vaccineon = true;
            //  player.numberOfVaccines += 1;
            //Debug.Log("Coins: " + player.numberOfVaccines);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(WaitforVAccine());
        }
    }

    IEnumerator WaitforVAccine()
    {
        yield return new WaitForSeconds(5.0f);
        Vaccineon = false;
        Destroy(gameObject);
    }
}
