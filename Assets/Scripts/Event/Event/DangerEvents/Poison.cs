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

        _eventText.text = $"Карта привела Вас к заросшим руинам древнего храма. " +
            $"Его стены испещрены незнакомыми письменами, а несколько оставшихся целыми статую изображаю существ с змеиными головами." +
            $"\nВпрочем, всё это не особенно интересует Вас, ведь на карте отмечен тайник, в котором должно находится что-то ценное.\nВынув из пола нужный камень, вы опускаете руку в образоввшуюся полость и нащупываете там шкатулку." +
            $"Увы, без проблем вынуть её не получается, кто-то кусает Вас за ладонь." +
            $"\nВ шкатулке обнаруживается камень, с причудливой руной и несколько стопок монет. Вот только радость от находки омрачает всё усиливающаяся боль в руке и слабость, растекающая по всему телу." +
            $"Без сомнения, это начинает действовать яд, занесенный в ваше тело при укусе. Можно подождать, надяесь, что тело само справится с ядом, а можно приготовить противоядие." +
            $"\n\nЭффект: Камень судьбы добавлен в инвентарь, {_moneyFound} золотых получено";

        _button1.name = "Wait";
        _button1Text.text = $"Ждать {StrenghtChallenge}";

        _button2.name = "Antidote";
        _button2Text.text = $"Противоядие {WillChallenge}";

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
        _challengeText = "Постепенно Вас охватывает жар и боль в руке становится нестерпимой";
        SelectChallenge(StrenghtChallenge, _strenghtChallengeComplexity, 0);
    }

    private void Antidote()
    {
        _challengeText = "Однажды вы уже делали противоядие под руководством опытного алхимика, но это было очень давно";
        SelectChallenge(KnowledgeChallenge, _knowledgeChallengeComplexity, 0);
    }
}
