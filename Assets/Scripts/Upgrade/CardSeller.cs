public class CardSeller : DeckUpgrader
{
    protected override void ShowCard()
    {
        _currentCardCost = _cards[_currentCardIndex].BuyCost;

        base.ShowCard();
    }

    protected override void OnActionButtonClicked()
    {
        GameEventManager.AddCardCalled?.Invoke(_cards[_currentCardIndex]);
    }
}
