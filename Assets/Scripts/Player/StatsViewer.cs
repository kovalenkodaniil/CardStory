using TMPro;
using UnityEngine;

public class StatsViewer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _strenghtCount;
    [SerializeField] private TMP_Text _willCount;
    [SerializeField] private TMP_Text _knowledgeCount;
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private TMP_Text _woundCount;

    private void OnEnable()
    {
        _strenghtCount.text = _player.Strenght.ToString();
        _willCount.text = _player.Will.ToString();
        _knowledgeCount.text = _player.Knowledge.ToString();
        _moneyCount.text = _player.Money.ToString();
        _woundCount.text = _player.Health.ToString();

        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged()
    {
        _moneyCount.text = _player.Money.ToString();
    }
}
