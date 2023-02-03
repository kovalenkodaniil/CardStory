using TMPro;
using UnityEngine;

public class EventUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _eventText;

    [SerializeField] private EventButton _eventButton1;
    [SerializeField] private EventButton _eventButton2;
    [SerializeField] private EventButton _eventButton3;

    public TMP_Text EventText => _eventText;
    public EventButton Button1 => _eventButton1;
    public EventButton Button2 => _eventButton2;
    public EventButton Button3 => _eventButton3;
}
