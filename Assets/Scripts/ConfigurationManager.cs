using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    public static ConfigurationManager Instance { get; private set; }

    private int boardWidth = 1;
    private int boardHeight = 1;
    private int musicVolume = 0;
    private float colorChangeModifier = 0.01f;
    private float growthModifier;
    private bool colorMode;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Getters:

    public int getBoardWidth() {
        return boardWidth;
    }

    public int getBoardHeight() {
        return boardHeight;
    }

    public int getMusicVolume() {
        return musicVolume;
    }

    public float getColorChangeModifier() {
        return colorChangeModifier;
    }

    public float getGrowthModifier() {
        return growthModifier;
    }

    public bool getColorMode() {
        return colorMode;
    }

    // Setters:

    public void setBoardWidth(int boardWidth) {
        this.boardWidth = boardWidth;
    }

    public void setBoardHeight(int boardHeight) {
        this.boardHeight = boardHeight;
    }

    public void setMusicVolume(int musicVolume) {
        this.musicVolume = musicVolume;
    }

    public void setColorChangeModifier(float colorChangeModifier) {
        this.colorChangeModifier = colorChangeModifier;
    }

    public void setGrowthModifier(float growthModifier) {
        this.growthModifier = growthModifier;
    }

    public void setColorMode(bool colorMode) {
        this.colorMode = colorMode;
    }
}