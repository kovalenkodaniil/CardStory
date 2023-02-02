using UnityEngine;
using UnityEngine.UI;

public class Poison : Event
{
    [SerializeField] private int _strenghtChallengeComplexity;
    [SerializeField] private int _knowledgeChallengeComplexity;
    [SerializeField] private int _moneyFound;
    [SerializeField] private Item _itemReward;


    public override void Active(Player player)
    {
        base.Active(player);

        _eventText.text = $"����� ������� ��� � �������� ������ �������� �����. " +
            $"��� ����� ��������� ����������� ����������, � ��������� ���������� ������ ������ ��������� ������� � �������� ��������." +
            $"\n�������, �� ��� �� �������� ���������� ���, ���� �� ����� ������� ������, � ������� ������ ��������� ���-�� ������.\n����� �� ���� ������ ������, �� ��������� ���� � ������������� ������� � ����������� ��� ��������." +
            $"���, ��� ������� ������ � �� ����������, ���-�� ������ ��� �� ������." +
            $"\n� �������� �������������� ������, � ����������� ����� � ��������� ������ �����. ��� ������ ������� �� ������� �������� �� ������������� ���� � ���� � ��������, ����������� �� ����� ����." +
            $"��� ��������, ��� �������� ����������� ��, ���������� � ���� ���� ��� �����. ����� ���������, �������, ��� ���� ���� ��������� � ����, � ����� ����������� �����������." +
            $"\n\n������: ������ ������ �������� � ���������, {_moneyFound} ������� ��������";

        _button1.name = "Wait";
        _button1Text.text = $"����� {StrenghtChallenge}";

        _button2.name = "Antidote";
        _button2Text.text = $"����������� {WillChallenge}";

        _player.TakeReward( _moneyFound );

        GameEventManager.DestinyStoneChangeCount?.Invoke(1);
        GameEventManager.ItemTaked?.Invoke(_itemReward);

        _button3.gameObject.SetActive(false);
    }
    protected override void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "Wait":
                Wait();
                break;

            case "Antidote":
                Antidote();
                break;
        }
    }

    private void Wait()
    {
        _challengeText = "���������� ��� ���������� ��� � ���� � ���� ���������� �����������";
        SelectChallenge(StrenghtChallenge, _strenghtChallengeComplexity, 0);
    }

    private void Antidote()
    {
        _challengeText = "������� �� ��� ������ ����������� ��� ������������ �������� ��������, �� ��� ���� ����� �����";
        SelectChallenge(KnowledgeChallenge, _knowledgeChallengeComplexity, 0);
    }
}
