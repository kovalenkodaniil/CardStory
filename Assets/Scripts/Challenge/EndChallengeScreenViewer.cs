using TMPro;
using UnityEngine;

public class EndChallengeScreenViewer : MonoBehaviour
{
    private const string Win = "������";
    private const string Escape = "�� �������";
    private const string Money = "������: +";

    [SerializeField] private TMP_Text _reward;
    [SerializeField] private TMP_Text _sreenHead;
    [SerializeField] private TMP_Text _rewardHead;

    public void Init(bool isWining, string reward)
    {
        if (isWining)
        {
            _sreenHead.text = Win;
            _rewardHead.enabled= true;
            _reward.text = Money + reward;
        }
        else
        {
            _sreenHead.text = Escape;
            _rewardHead.enabled = false;
            _rewardHead.enabled = false;
        }
    }
}
