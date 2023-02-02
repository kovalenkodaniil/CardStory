using UnityEngine;
using UnityEngine.Events;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private Deck _deck;

    private void OnEnable()
    {
        _deck.CardPlayed += OnCardPlayed;
    }

    private void OnDisable() 
    {
        _deck.CardPlayed -= OnCardPlayed;
    }

    private void OnCardPlayed(int bonus, string progressType)
    {
        GameEventManager.ProgressChanged?.Invoke(bonus, progressType);
    }
}
