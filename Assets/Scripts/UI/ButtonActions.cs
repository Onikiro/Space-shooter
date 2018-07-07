using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour {

    public static event Action OnResumed;

    public void Resume()
    {
        OnResumed();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
