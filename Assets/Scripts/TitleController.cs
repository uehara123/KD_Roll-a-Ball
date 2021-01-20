using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] GameObject TitlePanel;
    [SerializeField] GameObject CourseSelectPanel;
    [SerializeField] GameObject StageSelectPanel;

    private void Start()
    {
        TitlePanel.SetActive(true);
        CourseSelectPanel.SetActive(false);
        StageSelectPanel.SetActive(false);
    }

    public void OnCourseSelectButtonClicked()
    {
        TitlePanel.SetActive(false);
        CourseSelectPanel.SetActive(true);
        StageSelectPanel.SetActive(false);
    }

    public void OnStage1StartButtonClicked()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void OnDevelopStageStartButtonClicked()
    {
        SceneManager.LoadScene("DevelopScene");
    }

    public void OnPresentationStageStartButtonClicked()
    {
        SceneManager.LoadScene("PresentationStage");
    }

    public void OnReTitleButtonClicked()
    {
        TitlePanel.SetActive(true);
        CourseSelectPanel.SetActive(false);
        StageSelectPanel.SetActive(false);
    }
}
