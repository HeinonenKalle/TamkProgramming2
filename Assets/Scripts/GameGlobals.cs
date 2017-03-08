using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
        public float Score { get; private set; }
        public int CoinsCollected { get; private set; }
        public float HighScore { get; private set; }

        public enum TextName
        {
            Score,
            HighScore,
            Coins
        }

        private Text _scoreText;
        private Text _coinText;
        private Text _highScoreText;
        private Text _firstHighScore;
        private Text _secondHighScore;
        private Text _thirdHighScore;
        private Text _gameOverPrompt;

        private List<float> _highScores;

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
            _highScores = new List<float>();

            _highScores.Add(0);
            _highScores.Add(0);
            _highScores.Add(0);
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
            if (IsPlayerAlive)
            {
                Score += FloorManager.m_fMovementSpeed * Time.deltaTime * CoinsCollected;
                _scoreText.text = Score.ToString();
            }
        }

        public void SetGameStateStuff(FloorManager floorManager)
        {
            FloorManager = GameObject.Find("Floor Manager").GetComponent<FloorManager>();

            UICanvas = GameObject.Find("Canvas");
            _coinText = UICanvas.transform.GetChild(0).GetComponent<Text>();
            _scoreText = UICanvas.transform.GetChild(1).GetComponent<Text>();
            _highScoreText = UICanvas.transform.GetChild(2).GetComponent<Text>();
            _firstHighScore = UICanvas.transform.GetChild(3).GetComponent<Text>();
            _secondHighScore = UICanvas.transform.GetChild(4).GetComponent<Text>();
            _thirdHighScore = UICanvas.transform.GetChild(5).GetComponent<Text>();
            _gameOverPrompt = UICanvas.transform.GetChild(6).GetComponent<Text>();
        }

        public void ChangeCoins(int newValue)
        {
            CoinsCollected += newValue;
            _coinText.text = CoinsCollected.ToString();
        }

        public void ChangeHighScore()
        {


                _highScores.OrderByDescending(s => s);

                foreach (float score in _highScores)
                {
                    if (Score > score)
                    {
                        _highScores.Remove(score);
                        _highScores.Add(Score);
                        _highScores.OrderByDescending(s => s);
                        break;
                    }
                }

            _firstHighScore.text = _highScores[0].ToString();
            _secondHighScore.text = _highScores[1].ToString();
            _thirdHighScore.text = _highScores[2].ToString();
        }

        public void GameOverPrompts(bool IsGameOver)
        {
            if (IsGameOver)
            {
                _highScoreText.gameObject.SetActive(true);
                _firstHighScore.gameObject.SetActive(true);
                _secondHighScore.gameObject.SetActive(true);
                _thirdHighScore.gameObject.SetActive(true);
                _gameOverPrompt.gameObject.SetActive(true);
                //_highScoreText.enabled = true;
                //_firstHighScore.enabled = true;
                //_secondHighScore.enabled = true;
                //_thirdHighScore.enabled = true;
                //_gameOverPrompt.enabled = true;
            }
            else if (!IsGameOver)
            {
                _highScoreText.gameObject.SetActive(false);
                _firstHighScore.gameObject.SetActive(false);
                _secondHighScore.gameObject.SetActive(false);
                _thirdHighScore.gameObject.SetActive(false);
                _gameOverPrompt.gameObject.SetActive(false);
                //_highScoreText.enabled = false;
                //_firstHighScore.enabled = false;
                //_secondHighScore.enabled = false;
                //_thirdHighScore.enabled = false;
                //_gameOverPrompt.enabled = false;
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
