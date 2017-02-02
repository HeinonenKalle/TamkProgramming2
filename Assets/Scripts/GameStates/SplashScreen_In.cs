using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class SplashScreen_In : StateBase
    {
        // The time the splash screen will be shown
        private float StateTime = 1f;

        public void Start()
        {
            State = StateType.SplashScreen;
            Debug.Log("Welcome to the SplashScreen_In state, commander.");
        }

        private void Update()
        {
            if (StateTime <= 0f)
            {
                GameGlobals.Instance.StateManager.LoadState(State);
            }
            else
            {
                StateTime -= Time.deltaTime;
            }
        }
    }
}
