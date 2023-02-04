using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerStat))]
public class Player : MonoBehaviour
{
    public static UnityAction PlayerDied;
    public static UnityAction<Item> ItemTaked;

    [SerializeField] private int _maxHealth;

    public PlayerStat Health { get; private set; }
    public PlayerStat Money { get; private set; }
    public PlayerStat Knowledge { get; private set; }
    public PlayerStat Strenght { get; private set; }
    public PlayerStat Will { get; private set; }
    public PlayerStat DestinyStone { get; private set; }

    public event UnityAction MoneyChanged;

    private void Awake()
    {
        Health = new PlayerStat();
        Money = new PlayerStat();
        Knowledge = new PlayerStat();
        Strenght = new PlayerStat();
        Will = new PlayerStat();
        DestinyStone = new PlayerStat();
    }

    private void OnEnable()
    {
        Health.MinValueAchieved += PlayerDieing;
    }

    private void OnDisable()
    {
        Health.MinValueAchieved += PlayerDieing;
    }

    public void Init(int strenght, int knowledge, int will, int money)
    {
        Health.Init("Health", _maxHealth, 0, _maxHealth);
        Money.Init("Money", money, 0, int.MaxValue);
        Knowledge.Init("Knowledge", knowledge, 0, int.MaxValue);
        Strenght.Init("Strenght", strenght, 0, int.MaxValue);
        Will.Init("Will", will, 0, int.MaxValue);
        DestinyStone.Init("DestinyStone", 0, 0, int.MaxValue);

        Debug.Log(Money.CurrentValue);
    }

    private void PlayerDieing()
    {
        PlayerDied?.Invoke();
    }
}
