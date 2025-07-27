using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    private bool isGameOver = false;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        isGameOver = true;
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Go MainScene");
            SceneManager.LoadScene("MainScene");
        }
        
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }
}