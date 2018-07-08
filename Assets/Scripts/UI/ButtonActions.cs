using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <inheritdoc />
    /// <summary>
    /// Actions for buttons in menu
    /// </summary>
    public class ButtonActions : MonoBehaviour
    {

        public static event Action OnResumed;

        public void Resume()
        {
            if (OnResumed != null) OnResumed();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
