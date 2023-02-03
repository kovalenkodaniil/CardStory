using UnityEngine.UI;

public class Campfire : Event
{
    public override void Active(Player player)
    {
        base.Active(player);

        TextLoader = TextLoader.Load("Campfire/Active.json");

        EventText.text = TextLoader.EventText;

        Choice1.name = TextLoader.Choice1Name;
        Choice1Text.text = TextLoader.Choice1Text;

        Choice2.name = TextLoader.Choice2Name;
        Choice2Text.text = TextLoader.Choice2Text;

        Choice3.interactable= false;
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
        TextLoader = TextLoader.Load("Campfire/Rest.json");

        EventText.text = TextLoader.EventText;

        Choice1.name = TextLoader.Choice1Name;
        Choice1Text.text = TextLoader.Choice1Text;

        Choice2.gameObject.SetActive(false);
        Choice3.gameObject.SetActive(false);

        GameEventManager.RestoreCardCalled?.Invoke();
    }
}
