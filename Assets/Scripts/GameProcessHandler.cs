using SciptableObjects;
using System;
using System.Collections;
using UI;
using UnityEngine;

/// <inheritdoc />
/// <summary>
/// Handles game process (Score, Ui, pause/resume, 
/// </summary>
public class GameProcessHandler : MonoBehaviour
{

    public static event Action OnScoreChanged; //ScoreUI
    public static event Action OnPaused;       //MenuUI

    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            if (OnScoreChanged != null) OnScoreChanged();
        }
    }
    private int _points;
    private float _period;
    private bool _isPaused;
    private bool _inGame;
    [SerializeField]
    private GeneralSettings _settings;

    private void OnEnable()
    {
        Controller.OnGameOver += GameOver;
        ButtonActions.OnResumed += Resume;
    }

    private void Start()
    {
        _inGame = true;
        Time.timeScale = 1;
        _points = _settings.PointsPerPeriod;
        _period = _settings.ScorePeriod;

        StartCoroutine(AddScore());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _inGame)
        {
            if (!_isPaused)
            {
                Pause();
                _isPaused = true;
            }
        }
    }

    private void GameOver()
    {
        _inGame = false;
        Time.timeScale = 0;
    }

    private IEnumerator AddScore()
    {
        yield return null;
        yield return new WaitForSeconds(_period);
        yield return new WaitUntil(() => !_isPaused);
        Score += _points;
        yield return AddScore();
    }

    private static void Pause()
    {
        if (OnPaused != null) OnPaused();
        Time.timeScale = 0;
    }

    private void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        Controller.OnGameOver -= GameOver;
        ButtonActions.OnResumed -= Resume;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            if (!_isPaused)
            {
                Pause();
                _isPaused = true;
            }
        }
    }
}
