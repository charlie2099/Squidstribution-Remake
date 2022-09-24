using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerGrowthCalculator))]
public class KarmaCalculator : MonoBehaviour
{
    public Action<float> KarmaChanged;
    public float Karma { private set; get; }

    private PlayerGrowthCalculator _playerGrowthCalculator;
    private List<KarmaObject> _karmaObjects = new();

    private void Awake()
    {
        _playerGrowthCalculator = GetComponent<PlayerGrowthCalculator>();

        // Find a more efficient way for the calculator to automatically find karma objects
        foreach (var karmaObject in FindObjectsOfType<KarmaObject>())
        {
            _karmaObjects.Add(karmaObject);
        }
    }

    private void OnEnable()
    {
        foreach (var karmaObject in _karmaObjects)
        {
            karmaObject.OnDestroyed += ApplyKarma;
        }
    }
    
    private void OnDisable()
    {
        foreach (var karmaObject in _karmaObjects)
        {
            karmaObject.OnDestroyed -= ApplyKarma;
        }
    }

    private void ApplyKarma(float karma)
    {
        //Karma += buildingStats.karma * buildingStats.maxHealth * _playerGrowthCalculator.PlayerGrowthFactor;
        Karma += karma * _playerGrowthCalculator.GrowthFactor;
        KarmaChanged?.Invoke(Karma);
    }
}
