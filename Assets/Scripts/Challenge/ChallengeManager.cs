using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    private const string StrenghtChallenge = "(Испытание силы)";
    private const string KnowledgeChallenge = "(Испытание знаний)";
    private const string WillChallenge = "(Испытание воли)";

    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private Button _escapeButton;
    [SerializeField] private Button _finishButton;
    [SerializeField] private TMP_Text _challengeText;
    [SerializeField] private EndChallengeScreenViewer _finishScreen;

    private int _moneyReward;
    private bool _isWining;
    private Player _player;

    public event UnityAction ChallengeFinished;
    private void OnEnable()
    {
        _escapeButton.onClick.AddListener(OnEscaped);
        _finishButton.onClick.AddListener(FinishChallenge);
        _progressBar.ProgressBarFilled += OnProgressBarFilled;
    }

    private void OnDisable()
    {
        _escapeButton.onClick.RemoveListener(OnEscaped);
        _finishButton.onClick.RemoveListener(FinishChallenge);
        _progressBar.ProgressBarFilled -= OnProgressBarFilled;
    }

    public void Init(int complexity, string challengeType, int moneyReward,string challengeText, Player player)
    {
        int startProgress = 0;
        _isWining = false;
        _moneyReward = moneyReward;
        _player = player;
        _challengeText.text = challengeText;

        switch (challengeType)
        {
            case StrenghtChallenge:
                startProgress = player.Strenght;
                break;

            case KnowledgeChallenge:
                startProgress = player.Knowledge;
                break;

            case WillChallenge:
                startProgress = player.Will;
                break;
        }

        _progressBar.Init(complexity, startProgress, challengeType);
    }

    private void OnEscaped()
    {
        _player.TakeWound();
        ShowFinishCsreen();
    }

    private void OnProgressBarFilled()
    {
        _isWining = true;
        _player.TakeReward(_moneyReward);
        ShowFinishCsreen();
    }

    private void ShowFinishCsreen()
    {
        _finishScreen.gameObject.SetActive(true);
        _finishScreen.Init(_isWining, _moneyReward.ToString());
    }

    private void FinishChallenge()
    {
        _progressBar.Reset();
        ChallengeFinished?.Invoke();
    }
}
