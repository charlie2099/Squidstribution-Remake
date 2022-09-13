using FSM;
using UnityEngine;

namespace Enemies.Soldier.States
{
    public class Soldier_RunState : IState
    {
        private Soldier _soldier;

        public Soldier_RunState(Soldier owner)
        {
            _soldier = owner;
        }

        public void OnStateEnter() { Debug.Log("<color=orange>Entering Soldier run state</color>"); }
        public void OnStateUpdate() { Debug.Log("<color=orange>Executing Soldier run state</color>"); }
        public void OnStateExit() { Debug.Log("<color=orange>Exiting Soldier run state</color>"); }
    }
}