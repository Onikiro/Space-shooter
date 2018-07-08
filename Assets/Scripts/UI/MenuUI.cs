using UnityEngine;

namespace UI
{
    /// <inheritdoc />
    /// <summary>
    /// Handle pause and game-over menus
    /// </summary>
    public class MenuUi : MonoBehaviour
    {
        private GameObject _pausePanel, _resumeButton;

        private void Start()
        {
            SubscribeEvents();
            _pausePanel = GameObject.Find("PausePanel");
            _resumeButton = GameObject.Find("Resume");
            _pausePanel.SetActive(false);
        }

        private void GameOverPanel()
        {
            _pausePanel.SetActive(true);
            _resumeButton.SetActive(false);
        }

        private void Pause()
        {
            _pausePanel.SetActive(true);
            _resumeButton.SetActive(true);
        }

        private void Resume()
        {
            _pausePanel.SetActive(false);
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
}
