using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip buttonsound;
    public GameObject optionMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void optionsMenu()
    {
        
        AudioSource buttonsfx = GetComponent<AudioSource>();
        buttonsfx.PlayOneShot(buttonsound);
        optionMenu.SetActive(true);
    }

    public void optionMenuClose()
    {
        AudioSource buttonsfx = GetComponent<AudioSource>();
        buttonsfx.PlayOneShot(buttonsound);
        optionMenu.SetActive(false);
    }
}
