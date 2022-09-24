using System;
using System.Collections.Generic;
using Enemies.Soldier.States;
using Systems.FSM;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.Soldier
{
    public class Soldier : Enemy
    {
        #region Getters
        public float ViewDistance => viewDistance;
        public Dictionary<Type, IState> States => _cachedStatesDict;
        #endregion

        [SerializeField] private float health;
        [SerializeField] private float viewDistance;
        
        private Dictionary<Type, IState> _cachedStatesDict;

        private void Start()
        {
            // TODO: Data-driven design using Reflection and remote services, for tool development
            // Look into Reflection (Jason Weimann 'Reflection' video)
            // Define states outside of code
            // Load in data from a data source/store / remote service / SQL server? / JSON / EntityFramework?
            // To be able to setup advanced ai that is customisable by designers
            
            _cachedStatesDict = new Dictionary<Type, IState>
            {
                { typeof(Soldier_IdleState), new Soldier_IdleState(this)},
                { typeof(Soldier_WalkState), new Soldier_WalkState(this)},
                { typeof(Soldier_RunState), new Soldier_RunState(this)},
            };
            
            StateMachineFsm.ChangeState(_cachedStatesDict[typeof(Soldier_IdleState)]);

            CurrentHealth = health;
        }
    }
}