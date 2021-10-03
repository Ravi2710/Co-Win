using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    //public GameObject rightPosition, leftPosition, midPosition;
    //bool changePosition, startGame;
    public float speed;
    public float maxSpeed;
    public float speedController;
    public Text ScoreText;
    public Text Score2Text;
    public float score;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public static bool isGameOver;

    int desiredLane = 1;//0:left.
    public float laneDistance = 3;
    public static float numberOfCapsules;
    public Text capsulesText;
    public Text capsules2Text;
    public Text capsule3Text;
    //public Text vaccineText;
    //public static int numberOfVaccines;
    public GameObject vaccinefx;
    public GameObject hide;

    public Material vaccinematerial;
    private Material ballmaterial;

    public GameObject showBest;

    private void Awake()
    {
        //Time.timeScale = 0f;
        isGameOver = false;
        score = 0;
        if(PlayerPrefs.GetFloat("HighScore") == 0)
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
        PlayerPrefs.SetFloat("Score:", score);
    }

    // Start is called before the first frame update
    void Start()
    {
        ballmaterial = gameObject.GetComponent<MeshRenderer>().material;
        Time.timeScale = 1f;
        speedController = 0.01f;
        numberOfCapsules = 0;
        if (PlayerPrefs.GetFloat("Best") == 0)
        {
            PlayerPrefs.SetFloat("Best", 0);
        }
        PlayerPrefs.SetFloat("NumberOfCapsules:", numberOfCapsules);
        //numberOfVaccines = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            score++;
        }

        ScoreText.text = " " + score;
        Score2Text.text = "Score: " + score;

        capsulesText.text = "" + numberOfCapsules;
        capsules2Text.text = "" + numberOfCapsules;
        capsule3Text.text = "" + numberOfCapsules;
        //vaccineText.text = "Vaccines: " + numberOfVaccines;

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition,80*Time.deltaTime);

        //if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -1.67f)
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 1.64f)
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        if (speed < maxSpeed)
            speed += 0.1f * Time.deltaTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //if (Input.touchCount > 0 && transform.position.x >= -1.67f && transform.position.x <= 1.64f)
        //{
        //    touch = Input.GetTouch(0);
        //    transform.Translate(touch.deltaPosition.x, speedController, 0, 0);
        //}
        //else if (transform.position.x > 1.67f)
        //{
        //    transform.position = new Vector3(1.67f, transform.position.y, transform.position.z);
        //}
        //else if (transform.position.x < -1.64f)
        //{
        //    transform.position = new Vector3(-1.64f, transform.position.y, transform.position.z);
        //}

        //GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);

        //if(changePosition == true && startGame == true)
        //{
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(rightPosition.transform.position.x, transform.position.y, transform.position.z), 12f * Time.deltaTime);
        //}
        //if(changePosition == false && startGame == true)
        //{
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(leftPosition.transform.position.x, transform.position.y, transform.position.z), 12f * Time.deltaTime);
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    startGame = true;
        //    if(changePosition == false)
        //    {
        //        changePosition = true;
        //    }
        //    else if(changePosition == true)
        //    {
        //        changePosition = false;
        //    }
        //}

        if (VaccineCollector.Vaccineon == true)
        {
            vaccinefx.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().material = vaccinematerial;
        }
        else
        {
            vaccinefx.SetActive(false);
            gameObject.GetComponent<MeshRenderer>().material = ballmaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            //if (numberOfVaccines == 0)
            //{
            //    //transform.gameObject.SetActive(false);
            //    gameOverPanel.SetActive(true);
            //    Time.timeScale = 0f;
            //    isGameOver = true;
            //}
            //else
            //{
            //    numberOfVaccines--;
            //}

            if(VaccineCollector.Vaccineon == false)
            {

                //transform.gameObject.SetActive(false);
                //showBest.SetActive(true);
                gameOverPanel.SetActive(true);
                Time.timeScale = 0f;
                isGameOver = true;
                hide.SetActive(false);
                
            }
            //else { showBest.SetActive(false); }
        }

        if(other.tag == "levelcompleted")
        {
            levelCompletedPanel.SetActive(true);
            Time.timeScale = 0f;
            isGameOver = true;
            hide.SetActive(false);
            //showBest.SetActive(true);
        }
        //else { showBest.SetActive(false);}

        //else if(other.tag != "enemy")
        //{
        //    transform.gameObject.SetActive(true);
        //}

        if (PlayerPrefs.GetFloat("HighScore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.SetFloat("Score", score);
        }
        else
        {
            PlayerPrefs.SetFloat("Score", score);
        }

        if (PlayerPrefs.GetFloat("Best") < numberOfCapsules)
        {
            PlayerPrefs.SetFloat("Best", numberOfCapsules);
            PlayerPrefs.SetFloat("NumberOfCapsules", numberOfCapsules);
        }
        else
        {
            PlayerPrefs.SetFloat("NumberOfCapsules", numberOfCapsules);
        }
    }
}
