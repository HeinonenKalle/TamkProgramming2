using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class SplashScreen_In : StateBase
    {
        public SplashScreen_In() : base()
        {
            State = StateType.SplashScreen;
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
