using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traider : Event
{
    [SerializeField] private List<Item> _items;

    private Item _itemForTrade;

    public override void Active(Player player)
    {
        base.Active(player);

        _itemForTrade = _items[Random.Range(0, _items.Count)];

        _eventText.text = $"-����������, ����! ���� ����� ����, � - ������������� ��������. � ��������� ����� ���� ���� �������, " +
            $"- ���������� �������, ������ ����� � ����� �������, - �� �����, � ���� ����, ��� ���� ����������." +
            $"\n�������� ������� �� ������ ������������ ������� '{_itemForTrade.Name}'";

        _button1.name = "Buy";
        _button1Text.text = $"������ ({_itemForTrade.Cost})";

        _button2.name = "Exit";
        _button2Text.text = $"����������";

        _button3.gameObject.SetActive(false);

        if (_player.Money < _itemForTrade.Cost)
            _button1.interactable = false;
    }

    protected override void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "Buy":
                Buy();
                break;

            case "Exit":
                Exit();
                break;
        }
    }

    private void Buy()
    {
        _player.Pay(_itemForTrade.Cost);

        _eventText.text = "-������� ������, ����. ������� �� ��� ��������, - �������� ���������� ��������.\n\n ������: ������� �������";

        _button1.name = "Exit";
        _button1Text.text = $"���������� ����";

        _button2.gameObject.SetActive(false);
        _button3.gameObject.SetActive(false);

        GameEventManager.ItemTaked?.Invoke(_itemForTrade);
    }
}
