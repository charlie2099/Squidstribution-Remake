using FSM;
using UnityEngine;

namespace Player.States
{
    public class Player_IdleState : IState
    {
        private object _player;

        public Player_IdleState(object owner)
        {
            _player = owner;
        }

        public void OnStateEnter() { Debug.Log("<color=orange>Entering Player idle state</color>"); }
        public void OnStateUpdate() { Debug.Log("<color=orange>Executing Player idle state</color>"); }
        public void OnStateExit() { Debug.Log("<color=orange>Exiting Player idle state</color>"); }
    }
}