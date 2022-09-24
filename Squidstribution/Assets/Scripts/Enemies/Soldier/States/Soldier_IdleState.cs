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

        public void OnStateEnter()
        {
            //_soldier.SetNavAgentSpeed(0.0f);
        }

        public void OnStateUpdate()
        {
            if (Vector3.Distance(_soldier.transform.position, _soldier.Player.position) < _soldier.ViewDistance)
            {
                _soldier.StateMachineFsm.ChangeState(_soldier.States[typeof(Soldier_WalkState)]);
            }
        }

        public void OnStateExit()
        {
            
        }
        
        // Idle
        // Patrol / Wander
        // Search
        // Chase
        // Attack
    }
}