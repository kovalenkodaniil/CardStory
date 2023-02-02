using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _button;

    public Button Button => _button;
    public TMP_Text ButtonText => _buttonText;

    public event UnityAction<Button> ButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        ButtonClicked?.Invoke(_button);
    }
}
