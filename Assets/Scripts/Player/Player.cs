using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxWound;
    private int _strenght;
    private int _knowledge;
    private int _will;
    private int _money;
    private int _destinyStone;
    private int _health;

    public int Strenght => _strenght;
    public int Knowledge => _knowledge;
    public int Will => _will;
    public int Money => _money;
    public int DestinyStone => _destinyStone;
    public int Health => _health;

    public event UnityAction MoneyChanged;

    public void Init(int strenght, int knowledge, int will, int money)
    {
        _strenght= strenght;
        _knowledge= knowledge;
        _will=will;
        _money=money;
        _health = _maxWound;
    }

    public void TakeWound()
    {
        _health--;

        if (_health == 0)
            GameEventManager.PlayerDied?.Invoke();
    }

    public void TakeReward(int moneyReward) 
    {
        if (moneyReward > 0)
            _money += moneyReward;

        MoneyChanged?.Invoke();
    }

    public void TakeDestinyStone(int count)
    {
        if (count > 0)
            _destinyStone += count;

        if (_destinyStone < 0)
            _destinyStone = 0;
    }

    public void Pay(int sum)
    {
        if (sum > 0 && sum < _money)
        {
            _money -= sum;
        }

        MoneyChanged?.Invoke();
    }

    public void KnowledgeChange(int bonus)
    {
        _knowledge -= bonus;

        if (_knowledge < 0)
            _knowledge = 0;
    }
}
