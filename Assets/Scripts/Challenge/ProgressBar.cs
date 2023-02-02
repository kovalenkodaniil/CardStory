using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private List<Image> _progressPoints;
    [SerializeField] private DeckManager _deckManager;
    [SerializeField] private Sprite _progressSprite;
    [SerializeField] private Sprite _defultSprite;
    [SerializeField] private TMP_Text _challengeType;

    [SerializeField] private int _currentProgressIndex;
    private List<Image> _curentChallengeProgress;
    private bool _isFull;

    public int CurrentProgress => _currentProgressIndex;
    public bool IsFull => _isFull;

    public event UnityAction ProgressBarFilled;

    private void Awake()
    {
        _curentChallengeProgress = new List<Image>();
    }

    public void Init(int complexity, int startProgress, string challengeType)
    {
        Image progressPoint;
        _isFull = false;
        _currentProgressIndex = 0;
        _challengeType.text = challengeType;

        for (int i = 0; i < complexity; i++)
        {
            progressPoint = _progressPoints[i];

            progressPoint.gameObject.SetActive(true);
            _curentChallengeProgress.Add(progressPoint);
        }

        OnProgressChanged(startProgress, challengeType);
    }

    private void OnEnable()
    {
        GameEventManager.ProgressChanged += OnProgressChanged;
    }

    private void OnDisable()
    {
        GameEventManager.ProgressChanged -= OnProgressChanged;
    }

    public void Reset()
    {
        _curentChallengeProgress.Clear();

        _isFull = false;

        foreach (var point in _progressPoints)
        {
            point.sprite = _defultSprite;
            point.color = Color.white;
            point.gameObject.SetActive(false);
        }
    }

    private void OnProgressChanged(int progress, string progressType)
    {
        if (progressType == _challengeType.text || progressType == "")
        {
            int progressIndex = _currentProgressIndex + progress;

            if (progress > 0)
            {
                for (int i = _currentProgressIndex; i < progressIndex; i++)
                {
                    if (i < _curentChallengeProgress.Count)
                    {
                        _curentChallengeProgress[i].sprite = _progressSprite;
                        _curentChallengeProgress[i].color = Color.green;

                        _currentProgressIndex = i+1;

                        if (_currentProgressIndex == _curentChallengeProgress.Count)
                            _isFull = true;
                    }
                }
            }
            else
            {
                for (int i = _currentProgressIndex - 1; i >= progressIndex; i--)
                {
                    if (i >= 0)
                    {
                        _curentChallengeProgress[i].sprite = _defultSprite;
                        _curentChallengeProgress[i].color = Color.white;
                        _currentProgressIndex = i;
                    }
                }
            }

            if (_isFull)
                ProgressBarFilled?.Invoke();
        }
    }
}
