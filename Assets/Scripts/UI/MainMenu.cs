using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private Button _optionsBtn;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _quitBtn;

    private void Awake()
    {
        _optionsBtn.onClick.AddListener(ShowOptions);
        _closeBtn.onClick.AddListener(ShowMenu);
        _startBtn.onClick.AddListener(StartGame);
        _quitBtn.onClick.AddListener(QuitGame);
    }

    private void ShowOptions()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }
    
    private void ShowMenu()
    {
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
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
