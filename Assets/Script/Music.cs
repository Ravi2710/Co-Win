using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("muted", 0) == 0)
        {
            PlayerPrefs.SetInt("muted", 1);
            //volume=1
        }
        else
        {

            PlayerPrefs.SetInt("muted", 0);
            //volume=0
        }

    }
}
