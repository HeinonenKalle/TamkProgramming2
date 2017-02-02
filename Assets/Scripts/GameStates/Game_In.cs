using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class Game_In : StateBase
    {
        public Game_In() : base()
        {
            State = StateType.Game;
        }

        public override void StateActivated()
        {
            //GameStateManager.LoadScene(State);
        }

        public override void StateDeactivated()
        {

        }
    }
}
