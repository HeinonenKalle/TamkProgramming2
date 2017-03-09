using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TamkRunner
{
    public class GameStateManager : MonoBehaviour
    {
        public StateType CurrentState { get; private set; }

		private string _devModeSceneToLoad = "";

		public void Awake()
		{
			DontDestroyOnLoad(GameObject.Find("PersistentObjects"));
			// Check for Dev Mode
			GameObject obj = GameObject.Find("DevModeCheck");
			if (obj != null) {
				Debug.Log ("Found DMC, entering dev mode...");
				DevModeCheck scene = obj.GetComponent<DevModeCheck> ();
				_devModeSceneToLoad = scene.CurrentSceneName;
				Destroy (obj);
			}
		}

		void Start ()
		{
			// If DMC was activated, skip straight to Level1.
			if (_devModeSceneToLoad != "")
			{
                if (_devModeSceneToLoad.Equals("MainMenu"))
                {
                    LoadState(StateType.SplashScreen);
                    _devModeSceneToLoad = "";
                }
                else if (_devModeSceneToLoad.Equals("Level1"))
                {
                    LoadState(StateType.MainMenu);
                    _devModeSceneToLoad = "";
                }
			}
		}

        // Load the next state based on the current state
        public void LoadState(StateType currentState)
        {
            if (currentState == StateType.SplashScreen)
            {
                CurrentState = currentState;
				Debug.Log ("Loading MainMenu");
                SceneManager.LoadScene("MainMenu");
            }
            else if (currentState == StateType.MainMenu)
            {
                CurrentState = currentState;
                Debug.Log ("Loading Level1");
                SceneManager.LoadScene("Level1");
            }
            else if (currentState == StateType.Game)
            {
                CurrentState = currentState;
                Debug.Log("Reset level initiated.");
                SceneManager.LoadScene("Level1");
            }
            else
            {
                Debug.Log("No load of that type supported as of now.");
            }
        }
    }
}
