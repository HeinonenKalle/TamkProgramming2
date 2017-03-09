using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TamkRunner
{
    public class Game_In : StateBase
    {
        public FloorManager FloorManager;
        public Text Coins;
        public Text HighScore;
        public Text Score;
        public Text GameOverPrompt;

        private CharacterBehavior _characterBehavior;

        public void Start()
        {
            State = StateType.Game;
            Debug.Log("Welcome to the Game_In state, commander.");
            GameGlobals.Instance.SetGameDefaults();
            _characterBehavior = GameObject.Find("Player Character").GetComponent<CharacterBehavior>();
            GameGlobals.Instance.SetGameStateStuff();
        }

        public void Update()
        {
            if (!GameGlobals.Instance.IsPlayerAlive)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    GameGlobals.Instance.GameOverPrompts(false);
                    GameGlobals.Instance.StateManager.LoadState(StateType.Game);
                }
            }
        }
    }
}
