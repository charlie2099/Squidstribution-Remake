using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _karmaText;
    [SerializeField] private KarmaCalculator karmaCalculator;

    private void OnEnable()
    {
        karmaCalculator.KarmaChanged += UpdateKarmaUi;
    }

    private void OnDisable()
    {
        karmaCalculator.KarmaChanged -= UpdateKarmaUi;
    }

    private void UpdateKarmaUi(float karma)
    {
        _karmaText.text = "Karma: " + karmaCalculator.Karma;
    }
}
