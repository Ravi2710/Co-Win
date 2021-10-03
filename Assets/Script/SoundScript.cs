using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
	private Music music;
	public Button musictogglebutton;
	public Sprite musiconsprite;
	public Sprite musicoffsprite;
	//public AudioClip buttonsound;
	//public AudioClip closebuttonsound;

	// Use this for initialization
	void Start()
	{
		music = GameObject.FindObjectOfType<Music>();
		UpdateIconandVolume();
	}

	public void PauseMusic()
	{
		music.ToggleSound();
		UpdateIconandVolume();
	}

	void UpdateIconandVolume()
	{
		if (PlayerPrefs.GetInt("muted", 0) == 0)
		{
			//AudioSource buttonsfx = GetComponent<AudioSource> ();
			//buttonsfx.PlayOneShot (buttonsound);
			AudioListener.volume = 1;
			musictogglebutton.GetComponent<Image>().sprite = musiconsprite;
		}
		else
		{

			AudioListener.volume = 0;
			//AudioSource buttonsfx = GetComponent<AudioSource> ();
			//buttonsfx.PlayOneShot (buttonsound);
			//AudioSource closebuttonsfx = GetComponent<AudioSource> ();
			//closebuttonsfx.PlayOneShot (closebuttonsound);
			musictogglebutton.GetComponent<Image>().sprite = musicoffsprite;
		}
	}
}
