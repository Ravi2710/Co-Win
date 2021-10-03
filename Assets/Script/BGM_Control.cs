using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Control : MonoBehaviour
{
	// Start is called before the first frame update
	private AudioSource audiobgm;

	void Start()
	{
		audiobgm = gameObject.GetComponent<AudioSource>();
		audiobgm = gameObject.GetComponent<AudioSource>();
	}

	void Update()
	{
		if (player.isGameOver == true)
		{
			audiobgm.Stop();
		}
		
	}
}
