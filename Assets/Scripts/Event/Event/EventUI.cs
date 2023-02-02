using TMPro;
using UnityEngine;

public class EventUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _eventText;

    [SerializeField] private EventButton _button1;
    [SerializeField] private EventButton _button2;
    [SerializeField] private EventButton _button3;

    public TMP_Text EventText => _eventText;
    public EventButton Button1 => _button1;
    public EventButton Button2 => _button2;
    public EventButton Button3 => _button3;
}
