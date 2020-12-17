using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject PlayPanel;
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject PauseButton;
    bool pausing;

    public bool Pausing()
    {
        return pausing;
    }

    private void Start()
    {
        PlayPanel.SetActive(true);
        MenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void OnMenuButtonClicked()
    {
        PlayPanel.SetActive(true);
        MenuPanel.SetActive(false);

    }

    public void OnPlayButtonClicked()
    {
        PlayPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void OnPauseButtonClicked()
    {
        pausing = true;
        PauseButton.SetActive(false);
        StartButton.SetActive(true);
    }

    public void OnStartButtonClicked()
    {
        pausing = false;
        PauseButton.SetActive(true);
        StartButton.SetActive(false);

    }
    public void SelectGameOverDescription()
    {
        GameOverPanel.SetActive(true);
        PlayPanel.SetActive(false);
        MenuPanel.SetActive(false);
    }
}
