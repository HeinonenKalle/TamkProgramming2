using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
