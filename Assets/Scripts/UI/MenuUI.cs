using UnityEngine;

public class MenuUI : MonoBehaviour {

    GameObject pausePanel, resumeButton;

    void Start()
    {
        SubscribeEvents();
        pausePanel = GameObject.Find("PausePanel");
        resumeButton = GameObject.Find("Resume");
        pausePanel.SetActive(false);
    }

    private void GameOverPanel()
    {
        pausePanel.SetActive(true);
        resumeButton.SetActive(false);
    }

    private void Pause()
    {
        pausePanel.SetActive(true);
        resumeButton.SetActive(true);
    }

    private void Resume()
    {
        pausePanel.SetActive(false);
    }

    private void SubscribeEvents()
    {
        GameProcessHandler.OnPaused += Pause;
        ButtonActions.OnResumed += Resume;
        Controller.OnGameOver += GameOverPanel;
    }

    private void UnsubscribeEvents()
    {
        Controller.OnGameOver -= GameOverPanel;
        GameProcessHandler.OnPaused -= Pause;
        ButtonActions.OnResumed -= Resume;
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}
