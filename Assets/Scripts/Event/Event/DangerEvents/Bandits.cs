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

        _eventText.text = "На лесной дороге виднеется повозка. Подойдя ближе, " +
            "Вы видете рядом с ней несколько человек тщательно обшаривающих повозку и лежащее рядом с ней тело мужчины." +
            "\n-Так, так, так, - произносит одна из фигур, заметив Вас. - Сегодня у нас удачный день - добыча идет одна за другой." +
            "\nБандит хищно улыбается, доставая из-за пояса окровавленный топор. " +
            "Сегодня они успели поживиться нерадивым путником, возможно у Вас получится избежать драки.";

        _button1.name = "Fight";
        _button1Text.text =  $"Сражаться {StrenghtChallenge}";

        _button2.name = "Talk";
        _button2Text.text = $"Договориться {WillChallenge}";

        _button3.name = "Deal";
        _button3Text.text = $"Откупиться";

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

        _eventText.text = $"Бандиты забируют твои монеты, и скрываются в чащи леса. Вы надетесь, что больше их никогда не увидите.\n\n Эффект: Потеряно {_banditsDealSum} золота";

        _button1.name = "Exit";
        _button1Text.text = $"Продолжить путь";

        _button1.gameObject.SetActive(false);
        _button2.gameObject.SetActive(false);
    }

    private void Fight()
    {
        _challengeText = "Бандиты обнажают своё оружие и бросаются в бой. Пусть им и не хватает мастерства, численное преимущество на их стороне" ;
        SelectChallenge(StrenghtChallenge, _strenghtChallengeComplexity, _banditsMoneyReward);
    }

    private void Talk()
    {
        _challengeText = "Бандиты сегодня уже поживились добычей, и их главарь, кажется в хорошем настроении. Он согласен тебя выслушать";
        SelectChallenge(WillChallenge, _willChallengeComplexity, _banditsMoneyReward);
    }
}
