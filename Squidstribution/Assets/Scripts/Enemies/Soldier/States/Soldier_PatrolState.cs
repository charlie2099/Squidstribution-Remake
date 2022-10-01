using Systems.FSM;
using UnityEngine;

namespace Enemies.Soldier.States
{
    public class Soldier_PatrolState : IState
    {
        private Soldier _soldier;

        public Soldier_PatrolState(Soldier owner)
        {
            _soldier = owner;
        }

        public void OnStateEnter()
        {
            
        }

        public void OnStateUpdate()
        {
            
        }

        public void OnStateExit()
        {
            
        }
    }
}