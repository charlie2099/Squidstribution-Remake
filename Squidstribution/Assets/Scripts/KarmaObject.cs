using System;
using UnityEngine;

public class KarmaObject : MonoBehaviour
{
    [SerializeField] private float karma;
    public Action<float> OnDestroyed;

    private void OnDestroy() => OnDestroyed?.Invoke(karma);
}

