using Systems.FSM;
using UnityEngine;

namespace Enemies.Soldier.States
{
    public class Soldier_GuardState : IState
    {
        private Soldier _soldier;

        public Soldier_GuardState(Soldier owner)
        {
            _soldier = owner;
        }

        public void OnStateEnter()
        {
            //_soldier.SetNavAgentSpeed(0.0f);
        }

        public void OnStateUpdate()
        {
            if (Vector3.Distance(_soldier.transform.position, _soldier.Player.position) < _soldier.DistanceFromPlayer)
            {
                _soldier.StateMachineFsm.ChangeState(_soldier.States[typeof(Soldier_AttackState)]);
            }
        }

        public void OnStateExit()
        {
            
        }
    }
}