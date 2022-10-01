using Systems.FSM;
using UnityEngine;

namespace Enemies.Soldier.States
{
    public class Soldier_AttackState : IState
    {
        private Soldier _soldier;

        public Soldier_AttackState(Soldier owner)
        {
            _soldier = owner;
        }

        public void OnStateEnter()
        {
            
        }

        public void OnStateUpdate()
        {
            _soldier.SetNavAgentTarget(_soldier.Player.position);
            
            if (Vector3.Distance(_soldier.transform.position, _soldier.Player.position) < _soldier.DistanceFromPlayer/3)
            {
                _soldier.Anims.SetBool("shoot", true);
            }
            else
            {
                _soldier.Anims.SetBool("shoot", false);
            }
        }

        public void OnStateExit()
        {
            
        }
    }
}