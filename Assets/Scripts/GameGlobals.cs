using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TamkRunner
{
    public class GameGlobals : MonoBehaviour
    {
        private static GameGlobals _instance;

        public static GameGlobals Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject globalObj = new GameObject(typeof(GameGlobals).Name);
                    _instance = globalObj.AddComponent<GameGlobals>();
                    globalObj.AddComponent<GameStateManager>();
                }
                return _instance;
            }
        }

        public GameStateManager StateManager { get; private set; }
        public FloorManager FloorManager { get; private set; }
        public GameObject UICanvas { get; private set; }

        public bool IsPlayerAlive { get; private set; }
        public int Score { get; private set; }
        public int CoinsCollected { get; private set; }
        public int HighScore { get; private set; }

        public enum TextName
        {
            Score,
            HighScore,
            Coins
        }

        private Text _scoreText;
        private Text _coinText;
        private Text _highScoreText;
        private Text _gameOverPrompt;


        // Use this for initialization
        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            if (_instance == this)
            {
                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        private void Initialize()
        {
            DontDestroyOnLoad(gameObject);
            StateManager = GetComponent<GameStateManager>();
        }

        public void ChangeIsPlayerAlive(bool newValue)
        {
            IsPlayerAlive = newValue;
        }

        public void FreezeeMovement()
        {
            FloorManager.ChangeSpeed(0f);
        }

        public void ContinueMovement()
        {
            FloorManager.RestoreSpeedFromBackup();
        }

        public void Update()
        {
            /*if (StateManager.CurrentState == StateType.Game && IsPlayerAlive)
            {

            }*/
        }

        public void SetGameStateStuff(FloorManager floorManager)
        {
            FloorManager = GameObject.Find("Floor Manager").GetComponent<FloorManager>();

            UICanvas = GameObject.Find("Canvas");
            _coinText = UICanvas.transform.GetChild(0).GetComponent<Text>();
            _scoreText = UICanvas.transform.GetChild(1).GetComponent<Text>();
            _highScoreText = UICanvas.transform.GetChild(2).GetComponent<Text>();
            _gameOverPrompt = UICanvas.transform.GetChild(3).GetComponent<Text>();
        }

        public void ChangeTextValue(TextName nameOfTextToChange, int newValue)
        {
            if (nameOfTextToChange == TextName.Coins)
            {
                CoinsCollected += newValue;
                _coinText.text = CoinsCollected.ToString();
            }
            else if (nameOfTextToChange == TextName.Score)
            {

            }
            else if (nameOfTextToChange == TextName.HighScore)
            {

            }
        }

        public void GameOverPrompts(bool IsGameOver)
        {
            if (IsGameOver)
            {
                _highScoreText.enabled = true;
                _gameOverPrompt.enabled = true;
            }
            else if (!IsGameOver)
            {
                _highScoreText.enabled = false;
                _gameOverPrompt.enabled = false;
            }
        }

        public void SetGameDefaults()
        {
            IsPlayerAlive = true;
            Score = 0;
            CoinsCollected = 0;
        }
    }
}
