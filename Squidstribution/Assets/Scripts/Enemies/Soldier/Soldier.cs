using System;
using Enemies.Soldier.States;
using FSM;
using UnityEngine;

namespace Enemies.Soldier
{
    public class Soldier : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            _stateMachine.ChangeState(new Soldier_IdleState(this));
        }
    }
}