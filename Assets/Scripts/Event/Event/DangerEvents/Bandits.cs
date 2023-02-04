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

        TextLoader = TextLoader.Load("Bandits/Active.json");

        EventText.text = TextLoader.EventText;

        Choice1.name = TextLoader.Choice1Name;
        Choice1Text.text = TextLoader.Choice1Text + StrenghtChallenge;

        Choice2.name = TextLoader.Choice2Name;
        Choice2Text.text = TextLoader.Choice2Text + WillChallenge;

        Choice3.name = TextLoader.Choice3Name;
        Choice3Text.text = TextLoader.Choice3Text;

        if (Player.Money.CurrentValue < _banditsDealSum)
            Choice3.interactable= false;
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
        Player.Money.Decrease(_banditsDealSum);

        TextLoader = TextLoader.Load("Bandits/Deal.json");

        EventText.text = TextLoader.EventText + _banditsDealSum;

        Choice1.name = TextLoader.Choice1Name;
        Choice1Text.text = TextLoader.Choice1Text;

        Choice2.gameObject.SetActive(false);
        Choice3.gameObject.SetActive(false);
    }

    private void Fight()
    {
        TextLoader = TextLoader.Load("Bandits/Fight.json");

        _challengeText = TextLoader.ChallengeText;
        SelectChallenge(StrenghtChallenge, _strenghtChallengeComplexity, _banditsMoneyReward);
    }

    private void Talk()
    {
        TextLoader = TextLoader.Load("Bandits/Talk.json");

        _challengeText = TextLoader.ChallengeText;
        SelectChallenge(WillChallenge, _willChallengeComplexity, _banditsMoneyReward);
    }
}
