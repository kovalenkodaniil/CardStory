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

        TextLoader = TextLoader.Load("Traider/Active.json");

        EventText.text = TextLoader.EventText + _itemForTrade.Name;

        Choice1.name = TextLoader.Choice1Name;
        Choice1Text.text = TextLoader.Choice1Text + $"({_itemForTrade.Cost})";

        Choice2.name = TextLoader.Choice2Name;
        Choice2Text.text = TextLoader.Choice2Text;

        Choice3.gameObject.SetActive(false);

        if (Player.Money < _itemForTrade.Cost)
            Choice1.interactable = false;
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
        Player.Pay(_itemForTrade.Cost);

        TextLoader = TextLoader.Load("Traider/Buy.json");

        EventText.text = TextLoader.EventText + _itemForTrade.Name;

        Choice1.name = TextLoader.Choice1Name;
        Choice1Text.text = TextLoader.Choice1Text;

        Choice2.gameObject.SetActive(false);
        Choice3.gameObject.SetActive(false);

        PlayerEvent.ItemTaked?.Invoke(_itemForTrade);
    }
}
