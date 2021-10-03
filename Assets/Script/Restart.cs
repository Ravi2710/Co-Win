using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //public Text ScoreText;
    //public Text HighScoreText;
    //float highscore;
    //float score;
    public AudioClip buttonSound;

    public Text NumberOfCapsulesText;
    public Text BestText;
    float best;
    float numberofcapsules;

    // Start is called before the first frame update
    void Start()
    {
        //highscore = PlayerPrefs.GetFloat("HighScore");
        //score = PlayerPrefs.GetFloat("score");

        //ScoreText.text = "Score" + score.ToString();
        //HighScoreText.text = "High Score " + highscore.ToString();

        best = PlayerPrefs.GetFloat("Best");
        numberofcapsules = PlayerPrefs.GetFloat("numberofcapsules");

        NumberOfCapsulesText.text = "NumberOfCapsules" + numberofcapsules.ToString();
        BestText.text = "" + best.ToString();
    }

    public void RestartLevel()
    {
        AudioSource buttonsfx = GetComponent<AudioSource>();
        buttonsfx.PlayOneShot(buttonSound);
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
