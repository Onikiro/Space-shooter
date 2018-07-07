using UnityEngine;

public class MenuUI : MonoBehaviour {

    GameObject pausePanel, resumeButton;
    [SerializeField]
    RectTransform restartButtonRect;
    Vector2 buttonPosCenter = new Vector2(0.5f, 0.5f);
    Vector2 buttonPosBottom = new Vector2(0.5f, 0.35f); 

    void Start()
    {
        SubscribeEvents();
        pausePanel = GameObject.Find("PausePanel");
        resumeButton = GameObject.Find("Resume");
        restartButtonRect = GameObject.Find("Restart").GetComponent<RectTransform>();
        pausePanel.SetActive(false);
    }

    private void GameOverPanel()
    {
        pausePanel.SetActive(true);
        resumeButton.SetActive(false);
        SetButtonRectOnRestart();
    }

    private void SetButtonRectOnPause()
    {
        restartButtonRect.anchorMin = buttonPosBottom;
        restartButtonRect.anchorMax = buttonPosBottom;
        restartButtonRect.anchoredPosition = Vector2.zero;
    }

    private void SetButtonRectOnRestart()
    {
        restartButtonRect.anchorMin = buttonPosCenter;
        restartButtonRect.anchorMax = buttonPosCenter;
        restartButtonRect.anchoredPosition = Vector2.zero;
    }

    private void Pause()
    {
        pausePanel.SetActive(true);
        resumeButton.SetActive(true);
        SetButtonRectOnPause();
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
