using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public enum StateType
    {
        SplashScreen,
        MainMenu,
        Game
    }

    public abstract class StateBase : MonoBehaviour
    {
        public StateType State { get; protected set; }

        public virtual void StateActivated() { }
        public virtual void StateDeactivated() { }
    }
}
