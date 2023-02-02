using UnityEngine.UI;

public class Campfire : Event
{
    public override void Active(Player player)
    {
        base.Active(player);

        _eventText.text = "Вы разбиваете лагерь в тени вековых деревьев, разводите костер и готовитесь к отдыху." +
            " Удивительно, но на много километров вокруг ни единой души, никто не потреожит Вас.";

        _button1.name = "Rest";
        _button1Text.text = $"Выспаться";

        _button2.name = "UpgradeCard";
        _button2Text.text = $"Улучшить колоду";

        _button3.name = "UpgradeHero";
        _button3Text.text = $"Недоступно";

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
        _eventText.text = "Вы хорошо отдохнули и восстановили часть сил. Пора продолжить путь\n\n Эффект: 1 карта из сброса возвращена в колоду";

        _button1.name = "Exit";
        _button1Text.text = $"Продолжить путь";

        _button2.gameObject.SetActive(false);
        _button3.gameObject.SetActive(false);

        GameEventManager.RestoreCardCalled?.Invoke();
    }
}
