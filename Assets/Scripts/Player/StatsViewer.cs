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
        _strenghtCount.text = _player.Strenght.CurrentValue.ToString();
        _willCount.text = _player.Will.CurrentValue.ToString();
        _knowledgeCount.text = _player.Knowledge.CurrentValue.ToString();
        _moneyCount.text = _player.Money.CurrentValue.ToString();
        _woundCount.text = _player.Health.CurrentValue.ToString();

        _player.Money.ValueChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.Money.ValueChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged()
    {
        _moneyCount.text = _player.Money.CurrentValue.ToString();
    }
}
