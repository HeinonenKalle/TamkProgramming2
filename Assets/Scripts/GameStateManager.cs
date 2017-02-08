using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TamkRunner
{
    public class GameStateManager : MonoBehaviour
    {
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
				LoadState (StateType.MainMenu);
				_devModeSceneToLoad = "";
			}
		}

        public void LoadState(StateType currentState)
        {
            if (currentState == StateType.SplashScreen)
            {
				Debug.Log ("Loading MainMenu");
                SceneManager.LoadScene("MainMenu");
            }
            else if (currentState == StateType.MainMenu)
            {
				Debug.Log ("Loading Level1");
                SceneManager.LoadScene("Level1");
            }
            else
            {
                Debug.Log("No load of that type supported as of now.");
            }
        }
    }
}
