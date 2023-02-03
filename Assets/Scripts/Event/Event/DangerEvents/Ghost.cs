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

        TextLoader = TextLoader.Load("Ghost/Active.json");

        EventText.text = TextLoader.EventText;

        Choice1.name = TextLoader.Choice1Name;
        Choice1Text.text = TextLoader.Choice1Text + WillChallenge;

        Choice2.name = TextLoader.Choice2Name;
        Choice2Text.text = TextLoader.Choice2Text + KnowledgeChallenge;

        Choice3.gameObject.SetActive(false);
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
        TextLoader = TextLoader.Load("Ghost/Brave.json");

        _challengeText = TextLoader.ChallengeText;
        SelectChallenge(WillChallenge, _willChallengeComplexity, _ghostMoneyReward);
    }

    private void Ritual()
    {
        TextLoader = TextLoader.Load("Ghost/Ritual.json");

        _challengeText = TextLoader.ChallengeText;
        SelectChallenge(KnowledgeChallenge, _knowledgegeChallengeComplexity, _ghostMoneyReward);
    }
}
