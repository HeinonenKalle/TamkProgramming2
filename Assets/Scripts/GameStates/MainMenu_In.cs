using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class MainMenu_In : StateBase
    {
        public MainMenu_In() : base()
        {
            State = StateType.MainMenu;
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
