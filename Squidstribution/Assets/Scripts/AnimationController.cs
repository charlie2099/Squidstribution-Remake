using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    [SerializeField] private float maxSpeed = 5.0f;

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
