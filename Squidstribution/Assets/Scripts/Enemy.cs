using System;
using Interfaces;
using Systems.FSM;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public event Action OnDamaged;
    public event Action OnDestroyed;
    
    public float CurrentHealth { get; set; }
    public StateMachine StateMachineFsm; // should this be public?
    public Transform Player => _player;
    
    // private List<WayPoint> waypoints; // Use a Queue so waypoints are followed in order?
    private NavMeshAgent _navMeshAgent; 
    private Animator _animator;
    private Transform _player;

    protected virtual void Awake()
    {
        StateMachineFsm = new StateMachine();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player").transform; // hmm
    }

    private void Update()
    {
        StateMachineFsm.Update();
        _animator.SetFloat("vertical", _navMeshAgent.velocity.magnitude / _navMeshAgent.speed, 0, Time.deltaTime);
        
        Debug.Log("Speed: " + _navMeshAgent.speed);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        
        if (CurrentHealth <= 0)
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }
        OnDamaged?.Invoke();
    }

    public void SetNavAgentVelocity(Vector3 velocity)
    {
        _navMeshAgent.velocity = velocity;
    }

    public void SetNavAgentSpeed(float speed)
    {
        _navMeshAgent.speed = speed;
    }

    public void SetNavAgentTarget(Vector3 target)
    {
        _navMeshAgent.SetDestination(target);
    }

    public void ShootAtTarget(Vector3 position) {}
    
    /*public void FollowTarget() {}
    public void AttackTarget() {}*/
}