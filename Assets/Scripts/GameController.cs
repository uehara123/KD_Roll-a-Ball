using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Panel
    [SerializeField] GameObject PlayPanel;
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject GameClearPanel;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject SerchPanel;
    [SerializeField] GameObject TimerPanel;

    // Button
    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject PauseButton;

    public ButtonColorController buttonColorController;
    public FollowPlayer followPlayer;
    public CameraController cameraController;
    public TimeController timeController;

    int CameraChanging = 3;


    private void Start()
    {
        Time.timeScale = 1.0f;

        PlayPanel.SetActive(true);
        TimerPanel.SetActive(true);
        MenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameClearPanel.SetActive(false);
        SettingPanel.SetActive(false);
        SerchPanel.SetActive(false);
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
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
        StartButton.SetActive(true);
    }

    public void OnStartButtonClicked()
    {
        Time.timeScale = 1f;
        PauseButton.SetActive(true);
        StartButton.SetActive(false);

    }

    public void OnSerchButtonClicked()
    {
        Time.timeScale = 0f;
        SerchPanel.SetActive(true);
        MenuPanel.SetActive(false);
        cameraController.SetMapCamera();
    }

    public void OnNotSerchButtonClicked()
    {
        Time.timeScale = 1f;
        SerchPanel.SetActive(false);
        MenuPanel.SetActive(true);
        cameraController.SetPlayerCamera();
    }

    // ピンチイン・アウト実装によりお払い箱にぽーん
   　/* public void OnExtensionButtonClicked()
    {
        if(CameraChanging > 1)
        {
            CameraChanging--;
            if (CameraChanging == 1)
            {
                buttonColorController.ButtonHide("ExtensionButton");
            }
            else if(CameraChanging == 5)
            {
                buttonColorController.ButtonAppear("ReductionButton");
            }
            // followPlayer.CameraInOut(followPlayer.CameraChanging);
            followPlayer.CameraIn(CameraChanging);
        }
    }

    public void OnReductionButtonClicked()
    {
        if (CameraChanging < 6)
        {
            CameraChanging++;
            if(CameraChanging == 2)
            {
                buttonColorController.ButtonAppear("ExtensionButton");
            }
            else if (CameraChanging == 6)
            {
                buttonColorController.ButtonHide("ReductionButton");
            }
            // followPlayer.CameraInOut(followPlayer.CameraChanging);
            followPlayer.CameraOut(CameraChanging);
        }
    } */

    public void OnSettingButtonClicked()
    {
        Time.timeScale = 0f;
        SettingPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void OnReMenuBottonClicked()
    {
        Time.timeScale = 1f;
        SettingPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void SelectGameOverDescription()
    {
        GameOverPanel.SetActive(true);
        PlayPanel.SetActive(false);
        MenuPanel.SetActive(false);
        TimerPanel.SetActive(false);

        timeController.timerflag = false;
    }

    public void SelectGameClearDescription()
    {
        GameClearPanel.SetActive(true);
        TimerPanel.SetActive(false);
        PlayPanel.SetActive(false);
        MenuPanel.SetActive(false);
    }

    public void ReturnTittle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ReturnStart()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }
}
