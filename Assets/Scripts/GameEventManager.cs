using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(EventManager))]
[RequireComponent(typeof(ChallengeManager))]
[RequireComponent(typeof(ScreenManager))]

public class GameEventManager : MonoBehaviour
{
    public static UnityAction RestoreCardCalled;
    public static UnityAction<Card> RemoveCardCalled;
    public static UnityAction<Card> AddCardCalled;
    public static UnityAction<int, string> ProgressChanged;
    public static UnityAction<int> DestinyStoneChangeCount;
    public static UnityAction EventFinished;
    public static UnityAction UpgradeSreenCalled;
    public static UnityAction PlayerDied;
    public static UnityAction<Item> ItemTaked;
    public static UnityAction<int> KnowledgeChanged;

    [SerializeField] private HeroPick _heroPick;
    [SerializeField] private List<Button> _inventoryButtons;
    [SerializeField] private Player _player;

    private ScreenManager _screenManager;
    private EventManager _eventManager;
    private ChallengeManager _challengeManager;

    private void Awake()
    {
        _eventManager = GetComponent<EventManager>();
        _challengeManager = GetComponent<ChallengeManager>();
        _screenManager= GetComponent<ScreenManager>();
    }

    private void OnEnable()
    {
        DestinyStoneChangeCount += OnDestinyStoneChangeCount;
        UpgradeSreenCalled += NeedShowUgradeScreen;
        EventFinished += NeedShowMapScreen;
        KnowledgeChanged+= OnKnowledgeChange;
        PlayerDied += OnPlayerDied;
        _eventManager.EventSelected += OnEventSelected;
        _eventManager.ChallengePicked += OnChallengeSelected;
        _heroPick.HeroPicked += NeedShowMapScreen;
        _challengeManager.ChallengeFinished += NeedShowMapScreen;

        foreach (var button in _inventoryButtons)
        {
            button.onClick.AddListener(OnInventoryButtonsClicked);
        }
    }

    private void OnDisable()
    {
        DestinyStoneChangeCount -= OnDestinyStoneChangeCount;
        UpgradeSreenCalled -= NeedShowUgradeScreen;
        EventFinished -= NeedShowMapScreen;
        KnowledgeChanged -= OnKnowledgeChange;
        PlayerDied -= OnPlayerDied;
        _eventManager.EventSelected -= OnEventSelected;
        _eventManager.ChallengePicked -= OnChallengeSelected;
        _heroPick.HeroPicked -= NeedShowMapScreen;
        _challengeManager.ChallengeFinished -= NeedShowMapScreen;

        foreach (var button in _inventoryButtons)
        {
            button.onClick.RemoveListener(OnInventoryButtonsClicked);
        }
    }

    private void OnEventSelected()
    {
        _screenManager.ShowEvenScreen();
    }

    private void OnChallengeSelected(Event currentEvent)
    {
        _screenManager.ShowChallangeScreen();
        _challengeManager.Init(currentEvent.ChallengeComplexity, currentEvent.ChallengeType, currentEvent.MoneyReward,currentEvent.ChallengeText, _player);
    }

    private void NeedShowMapScreen()
    {
        _screenManager.ShowMapScreen();
    }

    private void OnPlayerDied()
    {
        _screenManager.ShowDieScreen();
    }

    private void NeedShowUgradeScreen()
    {
        _screenManager.ShowUpgradeScreen();
    }

    private void OnInventoryButtonsClicked()
    {
        _screenManager.ShowInventoryScreen();
    }

    private void OnDestinyStoneChangeCount(int count)
    {
        _player.TakeDestinyStone(count);
    }

    private void OnKnowledgeChange(int bonus)
    {
        _player.KnowledgeChange(bonus);
    }
}
