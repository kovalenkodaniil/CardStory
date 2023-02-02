using UnityEngine;

public class CardRemover : DeckUpgrader
{
    [SerializeField] protected Deck _deck;

    protected override void Awake()
    {
        base.Awake();
        _cards = _deck.GetAllCard();
    }

    protected override void ShowCard()
    {
        _currentCardCost = _cards[_currentCardIndex].RemoveCost;

        base.ShowCard();
    }

    protected override void OnActionButtonClicked()
    {
        GameEventManager.RemoveCardCalled?.Invoke(_cards[_currentCardIndex]);
        _cards.RemoveAt(_currentCardIndex);
    }
}
