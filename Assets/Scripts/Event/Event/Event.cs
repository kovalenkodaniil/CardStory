using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(EventUI))]

public class Event : MonoBehaviour
{
    protected const string StrenghtChallenge = "(Испытание силы)";
    protected const string KnowledgeChallenge = "(Испытание знаний)";
    protected const string WillChallenge = "(Испытание воли)";

    protected EventUI EventUI;
    protected TextLoader TextLoader = new TextLoader();
    protected TMP_Text EventText;

    protected EventButton EventButton1;
    protected Button Choice1;
    protected TMP_Text Choice1Text;

    protected EventButton EventButton2;
    protected Button Choice2;
    protected TMP_Text Choice2Text;

    protected EventButton EventButton3;
    protected Button Choice3;
    protected TMP_Text Choice3Text;

    protected Player Player;
    protected string _challengeType;
    protected string _challengeText;
    protected int _challengeComplexity;
    private int _moneyReward;

    public string ChallengeType => _challengeType;
    public string ChallengeText => _challengeText;
    public int ChallengeComplexity => _challengeComplexity;
    public int MoneyReward => _moneyReward;

    public event UnityAction ChallengeSelected;

    protected void Awake()
    {
        EventUI = GetComponent<EventUI>();
        EventText  = EventUI.EventText;

        EventButton1 = EventUI.Button1;
        Choice1 = EventButton1.Button;
        Choice1Text = EventButton1.ButtonText;

        EventButton2 = EventUI.Button2;
        Choice2 = EventButton2.Button;
        Choice2Text = EventButton2.ButtonText;

        EventButton3 = EventUI.Button3;
        Choice3 = EventButton3.Button;
        Choice3Text = EventButton3.ButtonText;
    }

    protected void OnEnable()
    {
        EventButton1.ButtonClicked += OnButtonClick;
        EventButton2.ButtonClicked += OnButtonClick;
        EventButton3.ButtonClicked += OnButtonClick;
    }

    public virtual void Active( Player player)
    {
        EventButton1.gameObject.SetActive(true);
        EventButton2.gameObject.SetActive(true);
        EventButton3.gameObject.SetActive(true);

        Choice1.interactable= true;
        Choice2.interactable = true;
        Choice3.interactable = true;

        Player = player;
    }

    protected void OnDisable()
    {
        EventButton1.ButtonClicked -= OnButtonClick;
        EventButton2.ButtonClicked -= OnButtonClick;
        EventButton3.ButtonClicked -= OnButtonClick;
    }

    protected virtual void OnButtonClick(Button button) 
    {}

    protected void SelectChallenge(string type, int complexity, int moneyReward)
    {
        _challengeComplexity = complexity;
        _challengeType = type;
        _moneyReward= moneyReward;

        ChallengeSelected?.Invoke();

        enabled= false;
    }

    protected void Exit()
    {
        enabled= false;
        GameEventManager.EventFinished?.Invoke();
    }
}
