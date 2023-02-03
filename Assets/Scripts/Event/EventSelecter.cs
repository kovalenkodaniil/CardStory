using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSelecter : MonoBehaviour
{
    const string DangerType = "Danger";
    const string OpportunityType = "Opportunity";
    const string RestType = "Rest";

    [SerializeField] private List<Event> _dangerEvents;
    [SerializeField] private List<Event> _finishedDangerEvents;

    [SerializeField] private List<Event> _opportunityEvents;
    [SerializeField] private List<Event> _finishedOpportunityEvent;

    [SerializeField] private List<Event> _restEvents;
    [SerializeField] private List<Event> _finishedRestEvent;

    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private Player _player;

    private Event _curentEvent;

    public event UnityAction EventSelected;
    public event UnityAction<Event> ChallengePicked;

    private void OnEnable()
    {
        _mapGenerator.EventTypeSelected += OnEventTypeSelected;

        foreach (var dangerEvent in _dangerEvents)
        {
            dangerEvent.ChallengeSelected += OnChallangeSelected;
        }
    }

    private void OnDisable()
    {
        _mapGenerator.EventTypeSelected -= OnEventTypeSelected;

        foreach (var danger in _dangerEvents)
        {
            danger.ChallengeSelected -= OnChallangeSelected;
        }
    }

    private void OnEventTypeSelected(string type)
    {
        switch (type) 
        {
            case DangerType:
                SelectEvent(_dangerEvents, _finishedDangerEvents);
                break;

            case OpportunityType:
                SelectEvent(_opportunityEvents, _finishedOpportunityEvent);
                break;

            case RestType:
                SelectEvent(_restEvents, _finishedRestEvent);
                break;
        }

    }

    private void SelectEvent(List<Event> events, List<Event> finishedEvents)
    {
        if (events.Count == 0)
        {
            RefreshEvents(events, finishedEvents);
        }

        _curentEvent = events[Random.Range(0, events.Count)];

        EventSelected?.Invoke();
        _curentEvent.enabled = true;
        _curentEvent.Active(_player);

        events.Remove(_curentEvent);
        finishedEvents.Add(_curentEvent);
    }

    private void RefreshEvents(List<Event> events, List<Event> finishedEvents)
    {
        for (int i = 0; i < finishedEvents.Count; i++)
        {
            events.Add(finishedEvents[i]);
            finishedEvents.Remove(finishedEvents[i]);
        }
    }

    private void OnChallangeSelected()
    {
        ChallengePicked?.Invoke(_curentEvent);
    }
}
