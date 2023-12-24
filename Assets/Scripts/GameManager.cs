using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool LevelWin;

    public GameObject gameOverPannal;
    public GameObject levelWinPannal;

    public static int CurrentLevelIndex;
    public static int noOfPassingRings;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public Slider ProgressBar;

    public void Awake()
    {
        CurrentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    private void Start()
    {
        Time.timeScale = 1;
        noOfPassingRings = 0;
        gameOver = false;
        LevelWin = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPannal.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        currentLevelText.text = CurrentLevelIndex.ToString();
        nextLevelText.text = (CurrentLevelIndex + 1).ToString();
        int progress = noOfPassingRings * 100 / FindObjectOfType<HelixManager>().noOfRings;
        ProgressBar.value = progress;

        if (LevelWin)
        {
            levelWinPannal.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", CurrentLevelIndex + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
