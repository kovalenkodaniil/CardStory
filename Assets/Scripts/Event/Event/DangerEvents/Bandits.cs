using UnityEngine;
using UnityEngine.UI;

public class Bandits : Event
{
    [SerializeField] private int _strenghtChallengeComplexity;
    [SerializeField] private int _willChallengeComplexity;
    [SerializeField] private int _banditsMoneyReward;
    [SerializeField] private int _banditsDealSum;


    public override void Active(Player player)
    {
        base.Active(player);

        _eventText.text = "�� ������ ������ ��������� �������. ������� �����, " +
            "�� ������ ����� � ��� ��������� ������� ��������� ������������ ������� � ������� ����� � ��� ���� �������." +
            "\n-���, ���, ���, - ���������� ���� �� �����, ������� ���. - ������� � ��� ������� ���� - ������ ���� ���� �� ������." +
            "\n������ ����� ���������, �������� ��-�� ����� ������������� �����. " +
            "������� ��� ������ ���������� ��������� ��������, �������� � ��� ��������� �������� �����.";

        _button1.name = "Fight";
        _button1Text.text =  $"��������� {StrenghtChallenge}";

        _button2.name = "Talk";
        _button2Text.text = $"������������ {WillChallenge}";

        _button3.name = "Deal";
        _button3Text.text = $"����������";

        if (_player.Money < _banditsDealSum)
            _button3.interactable= false;
    }

    protected override void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "Fight":
                Fight();
                break;

            case "Talk":
                Talk();
                break;

            case "Deal":
                Deal();
                break;

            case "Exit":
                Exit();
                break;
        }
    }

    private void Deal()
    {
        _player.Pay(_banditsDealSum);

        _eventText.text = $"������� �������� ���� ������, � ���������� � ���� ����. �� ��������, ��� ������ �� ������� �� �������.\n\n ������: �������� {_banditsDealSum} ������";

        _button1.name = "Exit";
        _button1Text.text = $"���������� ����";

        _button1.gameObject.SetActive(false);
        _button2.gameObject.SetActive(false);
    }

    private void Fight()
    {
        _challengeText = "������� �������� ��� ������ � ��������� � ���. ����� �� � �� ������� ����������, ��������� ������������ �� �� �������" ;
        SelectChallenge(StrenghtChallenge, _strenghtChallengeComplexity, _banditsMoneyReward);
    }

    private void Talk()
    {
        _challengeText = "������� ������� ��� ���������� �������, � �� �������, ������� � ������� ����������. �� �������� ���� ���������";
        SelectChallenge(WillChallenge, _willChallengeComplexity, _banditsMoneyReward);
    }
}
