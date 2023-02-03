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

        TextLoader = TextLoader.Load("Poison/Active.json");

        EventText.text = TextLoader.EventText + _moneyFound;

        Choice1.name = TextLoader.Choice1Name;
        Choice1Text.text = TextLoader.Choice1Text + StrenghtChallenge;

        Choice2.name = TextLoader.Choice2Name;
        Choice2Text.text = TextLoader.Choice2Text + KnowledgeChallenge;

        Player.TakeReward( _moneyFound );

        PlayerEvent.DestinyStoneChangeCount?.Invoke(1);
        PlayerEvent.ItemTaked?.Invoke(_itemReward);

        Choice3.gameObject.SetActive(false);
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
        TextLoader = TextLoader.Load("Poison/Wait.json");

        _challengeText = TextLoader.ChallengeText;
        SelectChallenge(StrenghtChallenge, _strenghtChallengeComplexity, 0);
    }

    private void Antidote()
    {
        TextLoader = TextLoader.Load("Poison/Antidote.json");

        _challengeText = TextLoader.ChallengeText;
        SelectChallenge(KnowledgeChallenge, _knowledgeChallengeComplexity, 0);
    }
}
