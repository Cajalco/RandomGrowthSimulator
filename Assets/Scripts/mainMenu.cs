using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainMenu : MonoBehaviour
{
    public GameObject boardWidthSliderText;
    public GameObject boardHeightSliderText;
    public GameObject musicVolumeSliderText;
    public GameObject growthModifierSliderText;
    public GameObject colorChangeModifierSliderText;
    public GameObject configurationManager;
    public ConfigurationManager configuration;

    private void Start() {
        configurationManager = GameObject.Find("ConfigurationManager");
        configuration = configurationManager.GetComponent<ConfigurationManager>();
        configuration.setGrowthModifier(0.0f);
    }

    public void play() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void quit() {
		Application.Quit();
	}

	public void auto() {
        configuration.setGrowthModifier(Random.Range(0, 20)/4.0f);
        if (configuration.getGrowthModifier() == 0) {
            configuration.setBoardWidth(98);
            configuration.setBoardHeight(54);
        }
        else {
            configuration.setBoardWidth(50);
            configuration.setBoardHeight(27);
        }
        configuration.setColorChangeModifier(Random.Range(1, 99)/100.0f);
        Debug.Log(configuration.getColorChangeModifier());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void boardWidthSliderChanged(float newValue) {
        boardWidthSliderText.GetComponent<TMP_Text>().text = newValue.ToString();
        configuration.setBoardWidth((int)newValue);
    }

    public void boardHeightSliderChanged(float newValue) {
        boardHeightSliderText.GetComponent<TMP_Text>().text = newValue.ToString();
        configuration.setBoardHeight((int)newValue);
    }

    public void musicVolumeSliderChanged(float newValue) {
        musicVolumeSliderText.GetComponent<TMP_Text>().text = newValue.ToString();
        configuration.setMusicVolume((int)newValue);
        }

    public void growthModifierSliderChanged(float newValue) {
        growthModifierSliderText.GetComponent<TMP_Text>().text = (newValue/4).ToString();
        configuration.setGrowthModifier(newValue/4);
    }

    public void colorChangeModifierSliderChanged(float newValue) {
        colorChangeModifierSliderText.GetComponent<TMP_Text>().text = (newValue/100).ToString();
        configuration.setColorChangeModifier(newValue/100);
    }
}
