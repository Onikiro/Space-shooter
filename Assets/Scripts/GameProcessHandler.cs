using System;
using UnityEngine;

public class GameProcessHandler : MonoBehaviour {

    public static event Action OnScoreChanged; //ScoreUI
    public static event Action OnPaused;       //MenuUI

    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            if (OnScoreChanged != null) OnScoreChanged();
        }
    }
    private int points;
    private float period;
    private float nextPeriod;
    bool isPaused;
    bool inGame;
    [SerializeField]
    private GeneralSettings settings;

    void OnEnable()
    {
        Controller.OnGameOver += GameOver;
        ButtonActions.OnResumed += Resume;
    }

    void Start()
    {
        inGame = true;
        Time.timeScale = 1;
        points = settings.PointsPerPeriod;
        period = settings.ScorePeriod;
    }

    void Update()
    {
        if(!isPaused)
        {
        AddScore();
        }
        SetPauseGame();
    }

    private void GameOver()
    {
        inGame = false;
        Time.timeScale = 0;
    }

    void AddScore()
    {
        if (Time.timeSinceLevelLoad > nextPeriod)
        {
            nextPeriod = Time.timeSinceLevelLoad + period;
            Score += points;
        }
    }

    void SetPauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && inGame)
        {
            if(!isPaused)
            {
                Pause();
                isPaused = true;
            }
        }
    }

    void Pause()
    {
        OnPaused();
        Time.timeScale = 0;
    }

    void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        Controller.OnGameOver -= GameOver;
        ButtonActions.OnResumed -= Resume;
    }
}
