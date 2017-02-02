using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TamkRunner
{
    public class GameStateManager : MonoBehaviour
    {
        public void LoadState(StateType currentState)
        {
            if (currentState == StateType.SplashScreen)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else if (currentState == StateType.MainMenu)
            {
                SceneManager.LoadScene("Level1");
            }
            else
            {
                Debug.Log("No load of that type supported.");
            }
        }
    }
}
