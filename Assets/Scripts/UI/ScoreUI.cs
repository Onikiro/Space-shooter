using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    [SerializeField]
    private Text scoreCounter;
    private GameProcessHandler gameProcess;

    void OnEnable () {
        GameProcessHandler.OnScoreChanged += GetScore;
	}

    void Start()
    {
        gameProcess = GameObject.Find("GameProcess").GetComponent<GameProcessHandler>();
    }

    void GetScore()
    {
        scoreCounter.text = "Score: " + gameProcess.Score;
    }

    void OnDestroy()
    {
        GameProcessHandler.OnScoreChanged -= GetScore;
    }
}
