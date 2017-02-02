using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class MainMenu_In : StateBase
    {
        // TODO: Stop being lazy and change this to work with the press of a button instead
        // The time the main menu will be shown
        private float StateTime = 1f;

        public void Start()
        {
            State = StateType.MainMenu;
            Debug.Log("Welcome to the MainMenu_In state, commander.");
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
