using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : Event
{
    [SerializeField] private int _willChallengeComplexity;
    [SerializeField] private int _knowledgegeChallengeComplexity;
    [SerializeField] private int _ghostMoneyReward;

    public override void Active(Player player)
    {
        base.Active(player);

        _eventText.text = $"�� ����� ������� ����� ����� ��������� ��������. " +
            $"������� �������, ��� ��� �������� � ������ ������� �������� ��� ���������� ��������." +
            $"\n������, ��� ��� �������, ��� ������� ��� ����� ������ ������ ������ � ������� ��� ���-�� �� ����� ��������. " +
            $"�� �� ������, ���� ����� ������ ������� ����, � ��������� �������� �� ������ ��������, ���� �������������." +
            $"\n���� ������ ���������� ������ ��������, �� � �� �� ������ ��������� ��� �����, ���� �� ��������� ����������� � ��� ����������." +
            $"\n����� ����� �������� ������ ��������, ���� ������ ���.";

        _button1.name = "Brave";
        _button1Text.text = $"��������� ����������� {WillChallenge}";

        _button2.name = "Ritual";
        _button2Text.text = $"�������� ������ {KnowledgeChallenge}";

        _button3.gameObject.SetActive(false);
    }

    protected override void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "Brave":
                Brave();
                break;

            case "Ritual":
                Ritual();
                break;
        }
    }

    private void Brave()
    {
        _challengeText = "�� ��������� ��� �������� ���� ��������� �������, ���������� ����. ����� �������� ��������� �������������.";
        SelectChallenge(WillChallenge, _willChallengeComplexity, _ghostMoneyReward);
    }

    private void Ritual()
    {
        _challengeText = "�� �������� �� ������� ����� � ����������, ����������� ��� �������, �� ��������� ����� �� ������� �����, ����������� ��� �������, ���� �� ����������.";
        SelectChallenge(KnowledgeChallenge, _knowledgegeChallengeComplexity, _ghostMoneyReward);
    }
}
