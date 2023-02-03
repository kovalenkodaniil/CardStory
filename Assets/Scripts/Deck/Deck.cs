using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Deck : MonoBehaviour, IPointerClickHandler
{
    public static UnityAction RestoreCardCalled;
    public static UnityAction<Card> RemoveCardCalled;
    public static UnityAction<Card> AddCardCalled;

    [SerializeField] private List<Card> _cards;
    [SerializeField] private List<Card> _trashedCard;

    [SerializeField] private TMP_Text _cardName;
    [SerializeField] private TMP_Text _cardDescription;
    [SerializeField] private TMP_Text _cardBonus;
    [SerializeField] private Image _cardFace;
    [SerializeField] private Image _cardShirt;

    private int _clickCount;
    private Card _currentCard;

    private void Awake()
    {
        RestoreCardCalled += OnRestoreCardCalled;
        AddCardCalled += OnAddCardCalled;
        RemoveCardCalled += OnRemoveCardCalled;
    }

    private void OnEnable()
    {
        if (_cards.Count != 0)
            _cardShirt.gameObject.SetActive(true);

        foreach (var card in _cards)
        {
            card.EffectActiveted += OnEffectActiveted;
        }
    }

    private void OnDisable()
    {
        foreach (var card in _cards)
        {
            card.EffectActiveted -= OnEffectActiveted;
        }
    }

    private void OnDestroy()
    {
        RestoreCardCalled -= OnRestoreCardCalled;
        AddCardCalled -= OnAddCardCalled;
        RemoveCardCalled -= OnRemoveCardCalled;
    }

    private void OnRestoreCardCalled()
    {
        if (_trashedCard.Count != 0)
        {
            Card card = _trashedCard[Random.Range(0,_trashedCard.Count)];

            _trashedCard.Remove(card);
            _cards.Add(card);
        }
    }

    private void DiscardCard(Card card)
    {
        _cardFace.gameObject.SetActive(false);
        _cards.Remove(card);
        _trashedCard.Add(card);

        if (_cards.Count == 0)
        {
            _cardShirt.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_cards.Count == 0)
            return;

        _clickCount++;

        if (_clickCount > 1)
        {
            _currentCard.ActiveEffect();
            DiscardCard(_currentCard);
            _clickCount = 0;
        }
        else
        {
            _currentCard = PickCard();
            ShowCard(_currentCard);
        }
    }

    public List<Card> GetAllCard()
    {
        List<Card> cardfForTrancfer = new List<Card>();

        for (int i = 0; i < _cards.Count; i++)
        {
            cardfForTrancfer.Add(_cards[i]);
        }

        return cardfForTrancfer;
    }

    private Card PickCard()
    {
        int randomIndex = Random.Range(0, _cards.Count);

        return _cards[randomIndex];
    }

    private void ShowCard(Card card)
    {
        _cardFace.gameObject.SetActive(true);
        _cardName.text = card.Name;
        _cardDescription.text = card.Desscription;
        _cardBonus.text = card.Bonus;
    }

    private void OnEffectActiveted(int bonus, string challengeType)
    {
        ChallengeScreen.ProgressChanged?.Invoke(bonus, challengeType);
    }

    private void OnAddCardCalled(Card card)
    {
        _cards.Add(card);
    }

    private void OnRemoveCardCalled(Card card)
    {
        _cards.Remove(card);
    }
}
