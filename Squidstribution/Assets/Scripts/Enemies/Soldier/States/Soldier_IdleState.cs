using Systems.FSM;
using UnityEngine;

namespace Enemies.Soldier.States
{
    public class Soldier_IdleState : IState
    {
        private Soldier _soldier;

        public Soldier_IdleState(Soldier owner)
        {
            _soldier = owner;
        }

        public void OnStateEnter() { Debug.Log("<color=orange>Entering Soldier idle state</color>"); }
        public void OnStateUpdate() { Debug.Log("<color=orange>Executing Soldier idle state</color>"); }
        public void OnStateExit() { Debug.Log("<color=orange>Exiting Soldier idle state</color>"); }
    }
}