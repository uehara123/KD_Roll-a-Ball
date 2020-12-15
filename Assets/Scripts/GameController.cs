using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject PlayPanel;
    [SerializeField] GameObject MenuPanel;
    bool pausing;

    public bool Pausing()
    {
        return pausing;
    }

    private void Start()
    {
        BackToMenu();
    }

    public void SelsectMenuDescription()
    {
        pausing = true;
        PlayPanel.SetActive(false);
        MenuPanel.SetActive(true);

    }

    public void BackToMenu()
    {
        pausing = false;
        PlayPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
}
