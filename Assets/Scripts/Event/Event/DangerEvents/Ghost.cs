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

        _eventText.text = $"На холме чернеет остов давно сгоревшей мельницы. " +
            $"Местные уверены, что она проклята и внутри обитает яростный дух сгоревшего мельника." +
            $"\nВрочем, ещё они говорят, что мельник при жизни скопил немало золото и спрятал его где-то на своей мельнице. " +
            $"Вы не первый, кого жажда наживы привела сюда, и несколько белеющих на солнце скелетов, тому подтверждение." +
            $"\nВаше оружие бесполезно против призрака, но и он не сможет причинить Вам вреда, если ты сохранишь спокойствие в его присутсвии." +
            $"\nТакже можно провести ритуал очищения, если знаешь как.";

        _button1.name = "Brave";
        _button1Text.text = $"Сохранять спокойствие {WillChallenge}";

        _button2.name = "Ritual";
        _button2Text.text = $"Провести ритуал {KnowledgeChallenge}";

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
        _challengeText = "От истошного воя призрака веет зогробным холодом, тревожащим душу. Будет непросто сохранить самообладание.";
        SelectChallenge(WillChallenge, _willChallengeComplexity, _ghostMoneyReward);
    }

    private void Ritual()
    {
        _challengeText = "Вы достаете из рюкзака свечи и благовония, необходимые для ритуала, но вспомнить слова на древнем языке, необходимые для ритуала, пока не получается.";
        SelectChallenge(KnowledgeChallenge, _knowledgegeChallengeComplexity, _ghostMoneyReward);
    }
}
