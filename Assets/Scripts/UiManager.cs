using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField] private Button multiplyButton;
    [SerializeField] private Button enlargeButton;
    [SerializeField] private Button shootButton;

    [SerializeField] private Button startGameButton;
    [SerializeField] private Button pauseGameButton;
    [SerializeField] private Button quitGameButton;
    void Start()
    {
        multiplyButton.onClick.AddListener(MultiplyButonOnPressed);
        enlargeButton.onClick.AddListener(EnlargeButonOnPressed);
        shootButton.onClick.AddListener(ShootButonOnPressed);

        startGameButton.onClick.AddListener(StartButtonAction);
        pauseGameButton.onClick.AddListener(PauseButtonAction);
        quitGameButton.onClick.AddListener(QuitButtonAction);
    }

    public void MultiplyButonOnPressed()
    {
        GameManager.Instance.interactCircle.circleEffect = EffectType.Multiply;
    }
    
    public void EnlargeButonOnPressed()
    {
        GameManager.Instance.interactCircle.circleEffect = EffectType.Enlarge;
    }
    
    public void ShootButonOnPressed()
    {
        GameManager.Instance.interactCircle.circleEffect = EffectType.Shoot;
    }

    void StartButtonAction()
    {
        GameManager.Instance.StartGame();
        mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }

    void PauseButtonAction()
    {
        GameManager.Instance.PauseGame();
    }

    void QuitButtonAction()
    {
        GameManager.Instance.QuitGame();
    }
}
