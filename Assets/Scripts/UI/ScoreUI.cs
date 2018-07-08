using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <inheritdoc />
    /// <summary>
    /// Handles the score ui-element
    /// </summary>
    public class ScoreUi : MonoBehaviour
    {

        [SerializeField]
        private Text _scoreCounter;
        private GameProcessHandler _gameProcess;

        private void OnEnable()
        {
            GameProcessHandler.OnScoreChanged += GetScore;
        }

        private void Start()
        {
            _gameProcess = GameObject.Find("GameProcess").GetComponent<GameProcessHandler>();
        }

        private void GetScore()
        {
            _scoreCounter.text = "Score: " + _gameProcess.Score;
        }

        private void OnDestroy()
        {
            GameProcessHandler.OnScoreChanged -= GetScore;
        }
    }
}
