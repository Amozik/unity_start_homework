using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _quitBtn;

    private void Awake()
    {
        _gameMenu.SetActive(false);
        _closeBtn.onClick.AddListener(ResumeGame);
        _restartBtn.onClick.AddListener(StartGame);
        _quitBtn.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    
    
    private void PauseGame ()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        AudioListener.pause = gameIsPaused;
        _gameMenu.SetActive(gameIsPaused);
        
    }

    private void ResumeGame ()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        AudioListener.pause = gameIsPaused;
        _gameMenu.SetActive(gameIsPaused);
    }
    
    private void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
