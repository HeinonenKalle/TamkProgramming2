using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class Game_In : StateBase
    {
        public void Start()
        {
            State = StateType.Game;
            Debug.Log("Welcome to the Game_In state, commander.");
        }
    }
}
