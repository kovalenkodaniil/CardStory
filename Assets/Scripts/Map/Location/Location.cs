using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Location : MonoBehaviour
{
    private Image _icon;
    private Button _button;

    public event UnityAction<string> LocationPicked;

    private void Awake()
    {
        _icon = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Init(LocationType type)
    {
        _icon.sprite = type.Icon;
        gameObject.tag = type.Tag;
        _button.interactable= false;
    }

    public void ActiveButton()
    {
        _button.interactable= true;
    }

    private void OnButtonClick()
    {
        LocationPicked?.Invoke(gameObject.tag);
    }
}
