﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainMenu : MonoBehaviour
{
    public GameObject boardWidthSliderText;
    public GameObject boardHeightSliderText;
    public GameObject musicVolumeSliderText;

    public void play() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void quit() {
		Application.Quit();
	}

	public void auto() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void boardWidthSliderChanged(float newValue) {
        boardWidthSliderText.GetComponent<TMP_Text>().text = newValue.ToString();
    }

    public void boardHeightSliderChanged(float newValue) {
        boardHeightSliderText.GetComponent<TMP_Text>().text = newValue.ToString();
    }

    public void musicVolumeSliderChanged(float newValue) {
        musicVolumeSliderText.GetComponent<TMP_Text>().text = newValue.ToString();
    }
}
