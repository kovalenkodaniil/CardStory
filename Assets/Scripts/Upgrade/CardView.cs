using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text _cardName;
    [SerializeField] private TMP_Text _cardDescription;
    [SerializeField] private TMP_Text _cardBonus;

    private Card _card;

    public void ShowCard(Card card)
    {
        _cardName.text = card.Name;
        _cardDescription.text = card.Desscription;
        _cardBonus.text = card.Bonus;
    }
}
