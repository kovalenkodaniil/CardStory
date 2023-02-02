using UnityEngine;
using UnityEngine.Events;

public class CardEffect : MonoBehaviour
{
    [SerializeField] protected int _bonus;
    [SerializeField] protected string _challengeType;

    public event UnityAction<int, string> BonusAdded;
    public virtual void Active()
    {
        BonusAdded?.Invoke(_bonus, _challengeType);
    }
}
