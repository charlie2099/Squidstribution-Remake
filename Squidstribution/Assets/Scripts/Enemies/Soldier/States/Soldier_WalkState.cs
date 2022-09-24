using Systems.FSM;
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

        public void OnStateEnter()
        {
            //_soldier.SetNavAgentSpeed(0.5f);
        }

        public void OnStateUpdate()
        {
            _soldier.SetNavAgentTarget(_soldier.Player.position);
        }

        public void OnStateExit()
        {
            
        }
    }
}