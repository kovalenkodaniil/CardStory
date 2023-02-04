using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerStat
{
    public string Name { get; private set; }
    public int CurrentValue { get; private set; }
    public int MinValue { get; private set; }
    public int MaxValue { get; private set; }

    public event UnityAction ValueChanged;
    public event UnityAction MinValueAchieved;

    public void Init(string name, int currentValue, int minValue, int maxValue)
    {
        Name= name;
        CurrentValue= currentValue;
        MinValue= minValue;
        MaxValue= maxValue;

        ValueChanged += OnValueChanged;
        Player.PlayerDied += OnPlayerDied;
    }

    public void Increase(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        CurrentValue += value;

        ValueChanged?.Invoke();
    }

    public void Decrease(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        CurrentValue -= value;

        ValueChanged?.Invoke();
    }

    private void OnPlayerDied()
    {
        ValueChanged -= OnValueChanged;
        Player.PlayerDied -= OnPlayerDied;
    }

    private void OnValueChanged()
    {
        if (CurrentValue <= MinValue)
        {
            CurrentValue = 0;

            MinValueAchieved?.Invoke();
        }
    }
}
