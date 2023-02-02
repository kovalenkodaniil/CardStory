using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private string _bonus;
    [SerializeField] private int _removeCost;
    [SerializeField] private int _buyCost;
    [SerializeField] private List<CardEffect> _effects;

    public string Name => _name;
    public string Desscription => _description;
    public string Bonus => _bonus;
    public int BuyCost => _buyCost;
    public int RemoveCost => _removeCost;

    public event UnityAction<int, string> EffectActiveted;

    private void OnEnable()
    {
        foreach (var effect in _effects)
        {
            effect.BonusAdded += OnBonusAdded;
        }
    }

    private void OnDisable()
    {
        foreach (var effect in _effects)
        {
            effect.BonusAdded -= OnBonusAdded;
        }
    }

    public void ActiveEffect()
    {
        foreach (var effect in _effects)
        {
            effect.Active();
        }
    }

    private void OnBonusAdded(int bonus, string challengeType)
    {
        EffectActiveted?.Invoke(bonus, challengeType);
    }
}
