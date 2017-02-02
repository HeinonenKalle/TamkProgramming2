using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TamkRunner
{
    public class GameStateManager : MonoBehaviour
    {
        public void LoadNextState(StateType currentState)
        {
            if (currentState == StateType.SplashScreen)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else if (currentState == StateType.MainMenu)
            {
                SceneManager.LoadScene("Level1");
            }
            else if (currentState == StateType.Game)
            {
                // Do something here, possibly. ...Maybe?
            }
        }
    }
}
