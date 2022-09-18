using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Tooltip("Should match the maxSpeed of the PlayerController")]
    [SerializeField] private float maxSpeed = 5.0f;
    
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _animator.SetFloat("speed", _rigidbody.velocity.magnitude / maxSpeed);
    }
}
