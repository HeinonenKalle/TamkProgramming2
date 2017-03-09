using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TamkRunner
{
	public class DevModeCheck : MonoBehaviour {
        
		public string CurrentSceneName { get; private set; }

		// Use this for initialization
		void Awake () {
			GameObject persistentObjects = GameObject.Find ("PersistentObjects");
            CurrentSceneName = SceneManager.GetActiveScene().name;

			if (persistentObjects == null)
			{
				Debug.Log ("Persistent Objects gameobject not found. Entering DMC.");
				DontDestroyOnLoad (gameObject);
				SceneManager.LoadScene ("SplashScreen");
			}
		}
	}
}
