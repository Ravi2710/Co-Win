using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioClip buttonsound;
    public GameObject pausemenu;
    public bool gameIsPaused = false;

    private GameObject gamecamera;
    private GameObject playerobject;
    public Transform cameratransform;
   // public Vector3 Camerarotation;
    public int playerobjectspeed;
    public GameObject hide;
    public GameObject settingMenu;

    // Start is called before the first frame update
    void Start()
    {
        gamecamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerobject = GameObject.FindGameObjectWithTag("Player");
        // Destroy(gameObject, 2f);
        //Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        AudioSource buttonsfx = GetComponent<AudioSource>();
        buttonsfx.PlayOneShot(buttonsound);
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        hide.SetActive(true);
    }

    public void Setting()
    {
        AudioSource buttonsfx = GetComponent<AudioSource>();
        buttonsfx.PlayOneShot(buttonsound);
        pausemenu.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        hide.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void SettingmenuClose()
    {
        AudioSource buttonsfx = GetComponent<AudioSource>();
        buttonsfx.PlayOneShot(buttonsound);
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        hide.SetActive(false);
        settingMenu.SetActive(false);
    }

    public void Pause()
    {
        AudioSource buttonsfx = GetComponent<AudioSource>();
        buttonsfx.PlayOneShot(buttonsound);
        pausemenu.SetActive(true);
        
        Time.timeScale = 0f;
        gameIsPaused = true;
        hide.SetActive(false);
    }

    public void home()
    {
        SceneManager.LoadScene("mainMenu");
        AudioSource buttonsfx = GetComponent<AudioSource>();
        buttonsfx.PlayOneShot(buttonsound);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Time.timeScale = 1f;
    }

    public void camerabtn()
    {
        // gamecamera.transform = cameratransform;
        gamecamera.GetComponent<Transform>().position = cameratransform.position;
        gamecamera.GetComponent<Transform>().rotation = cameratransform.rotation;
        Resume();
        settingMenu.SetActive(false);
    }

    public void ballspeed10fbtn()
    {
        playerobject.GetComponent<player>().speed = 12f;
        Resume();
        settingMenu.SetActive(false);
    }

    public void ballspeed15fbtn()
    {
        playerobject.GetComponent<player>().speed = 17f;
        Resume();
        settingMenu.SetActive(false);
    }

    public void ballspeed25fbtn()
    {
        playerobject.GetComponent<player>().speed = 22f;
        Resume();
        settingMenu.SetActive(false);
    }
}
