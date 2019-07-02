using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Reset : MonoBehaviour
{
    bool next = false;
	// Use this for initialization
	void Start ()
    {
        EventsManager.SubscribeToEvent(EventType.GP_NextLVL, NextLVL);
    }

    private void NextLVL(object[] parameter)
    {
        next = (bool)parameter[0];
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Menu");
        }
        if(next)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

   
}
