using Systems.FSM;
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

        public void OnStateEnter()
        {
            //_soldier.SetNavAgentSpeed(1.0f);
        }

        public void OnStateUpdate()
        {
            
        }

        public void OnStateExit()
        {
           
        }
    }
}