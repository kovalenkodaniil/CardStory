using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CardView))]
public class DeckUpgrader : MonoBehaviour
{
    [SerializeField] protected List<Card> _cards;
    [SerializeField] protected Button _actionButton;
    [SerializeField] protected Button _previousCardButton;
    [SerializeField] protected Button _nextCardButton;
    [SerializeField] protected TMP_Text _cardCost;
    [SerializeField] protected Player _player;

    protected int _currentCardIndex;
    protected int _currentCardCost;
    protected CardView _cardViewer;

    protected virtual void Awake()
    {
        _cardViewer = GetComponent<CardView>();
    }

    protected void OnEnable()
    {
        _currentCardIndex = 0;
        ShowCard();

        _previousCardButton.onClick.AddListener(OnPreviousCardButtonClicked);
        _nextCardButton.onClick.AddListener(OnNextCardButtonClicked);
        _actionButton.onClick.AddListener(OnActionButtonClicked);
    }

    protected void OnDisable()
    {
        _previousCardButton.onClick.RemoveListener(OnPreviousCardButtonClicked);
        _nextCardButton.onClick.RemoveListener(OnNextCardButtonClicked);
        _actionButton.onClick.RemoveListener(OnActionButtonClicked);
    }

    protected virtual void ShowCard()
    {
        _cardCost.text = _currentCardCost.ToString();

        if (_currentCardCost > _player.DestinyStone)
            _actionButton.interactable = false;
        else
            _actionButton.interactable = true;

        _cardViewer.ShowCard(_cards[_currentCardIndex]);
    }

    protected void OnNextCardButtonClicked()
    {
        if (_currentCardIndex < _cards.Count - 1)
            _currentCardIndex++;

        ShowCard();
    }

    protected void OnPreviousCardButtonClicked()
    {
        if (_currentCardIndex > 0)
            _currentCardIndex--;

        ShowCard();
    }

    protected virtual void OnActionButtonClicked()
    {}
}

