using FSM;
using UnityEngine;

namespace Enemies.Soldier.States
{
    public class Soldier_WalkState : IState
    {
        private Soldier _soldier;

        public Soldier_WalkState(Soldier owner)
        {
            _soldier = owner;
        }

        public void OnStateEnter() { Debug.Log("<color=orange>Entering Soldier walk state</color>"); }
        public void OnStateUpdate() { Debug.Log("<color=orange>Executing Soldier walk state</color>"); }
        public void OnStateExit() { Debug.Log("<color=orange>Exiting Soldier walk state</color>"); }
    }
}