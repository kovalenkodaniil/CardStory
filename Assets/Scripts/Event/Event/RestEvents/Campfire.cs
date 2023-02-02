using UnityEngine.UI;

public class Campfire : Event
{
    public override void Active(Player player)
    {
        base.Active(player);

        _eventText.text = "�� ���������� ������ � ���� ������� ��������, ��������� ������ � ���������� � ������." +
            " �����������, �� �� ����� ���������� ������ �� ������ ����, ����� �� ��������� ���.";

        _button1.name = "Rest";
        _button1Text.text = $"���������";

        _button2.name = "UpgradeCard";
        _button2Text.text = $"�������� ������";

        _button3.name = "UpgradeHero";
        _button3Text.text = $"����������";

        _button3.interactable= false;
    }

    protected override void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "Rest":
                Rest();
                break;

            case "UpgradeCard":
                GameEventManager.UpgradeSreenCalled?.Invoke();
                break;

            case "Exit":
                Exit();
                break;
        }
    }

    private void Rest()
    {
        _eventText.text = "�� ������ ��������� � ������������ ����� ���. ���� ���������� ����\n\n ������: 1 ����� �� ������ ���������� � ������";

        _button1.name = "Exit";
        _button1Text.text = $"���������� ����";

        _button2.gameObject.SetActive(false);
        _button3.gameObject.SetActive(false);

        GameEventManager.RestoreCardCalled?.Invoke();
    }
}
