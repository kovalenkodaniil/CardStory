using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(EventSelecter))]
[RequireComponent(typeof(ChallengeScreen))]
[RequireComponent(typeof(ScreenViewer))]

public class ScreenEvent : MonoBehaviour
{
    public static UnityAction EventFinished;
    public static UnityAction UpgradeSreenCalled;

    [SerializeField] private HeroPick _heroPick;
    [SerializeField] private List<Button> _inventoryButtons;
    [SerializeField] private Player _player;

    private ScreenViewer _screenManager;
    private EventSelecter _eventManager;
    private ChallengeScreen _challengeManager;

    private void Awake()
    {
        _eventManager = GetComponent<EventSelecter>();
        _challengeManager = GetComponent<ChallengeScreen>();
        _screenManager= GetComponent<ScreenViewer>();
    }

    private void OnEnable()
    {
        UpgradeSreenCalled += NeedShowUgradeScreen;
        EventFinished += NeedShowMapScreen;
        Player.PlayerDied += OnPlayerDied;
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
        UpgradeSreenCalled -= NeedShowUgradeScreen;
        EventFinished -= NeedShowMapScreen;
        Player.PlayerDied -= OnPlayerDied;
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
}
