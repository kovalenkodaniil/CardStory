using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    protected const string StrenghtChallenge = "(Испытание силы)";
    protected const string KnowledgeChallenge = "(Испытание знаний)";
    protected const string WillChallenge = "(Испытание воли)";

    [SerializeField] protected EventUI _eventUI;
    protected TMP_Text _eventText;

    protected EventButton _eventButton1;
    protected Button _button1;
    protected TMP_Text _button1Text;

    protected EventButton _eventButton2;
    protected Button _button2;
    protected TMP_Text _button2Text;

    protected EventButton _eventButton3;
    protected Button _button3;
    protected TMP_Text _button3Text;

    protected Player _player;
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
        _eventUI= GetComponent<EventUI>();
        _eventText  = _eventUI.EventText;

        _eventButton1 = _eventUI.Button1;
        _button1 = _eventButton1.Button;
        _button1Text = _eventButton1.ButtonText;

        _eventButton2 = _eventUI.Button2;
        _button2 = _eventButton2.Button;
        _button2Text = _eventButton2.ButtonText;

        _eventButton3 = _eventUI.Button3;
        _button3 = _eventButton3.Button;
        _button3Text = _eventButton3.ButtonText;
    }

    protected void OnEnable()
    {
        _eventButton1.ButtonClicked += OnButtonClick;
        _eventButton2.ButtonClicked += OnButtonClick;
        _eventButton3.ButtonClicked += OnButtonClick;
    }

    public virtual void Active( Player player)
    {
        _eventButton1.gameObject.SetActive(true);
        _eventButton2.gameObject.SetActive(true);
        _eventButton3.gameObject.SetActive(true);

        _button1.interactable= true;
        _button2.interactable = true;
        _button3.interactable = true;

        _player = player;
    }

    protected void OnDisable()
    {
        _eventButton1.ButtonClicked -= OnButtonClick;
        _eventButton2.ButtonClicked -= OnButtonClick;
        _eventButton3.ButtonClicked -= OnButtonClick;
    }

    protected virtual void OnButtonClick(Button button) 
    {}

    protected void SelectChallenge(string type, int complexity, int moneyReward)
    {
        _challengeComplexity = complexity;
        _challengeType = type;
        _moneyReward= moneyReward;

        ChallengeSelected?.Invoke();
    }

    protected void Exit()
    {
        enabled= false;
        GameEventManager.EventFinished?.Invoke();
    }
}
