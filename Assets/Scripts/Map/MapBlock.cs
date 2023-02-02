using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapBlock : MonoBehaviour
{
    [SerializeField] private List<Location> _locations;
    [SerializeField] private MapGenerator _generator;

    public event UnityAction<string> BlockDisabled;
    private void OnEnable()
    {
        foreach(var location in _locations) 
        {
            location.LocationPicked += OnLocationPecked;
        }
    }

    public void Init()
    {
        foreach (var location in _locations)
        {
            location.Init(_generator.GetLocationType());
        }
    }

    private void OnDisable()
    {
        foreach (var location in _locations)
        {
            location.LocationPicked -= OnLocationPecked;
        }
    }

    public void ActiveLocation()
    {
        foreach (var location in _locations)
        {
            location.ActiveButton();
        }
    }

    private void OnLocationPecked(string tag)
    {
        gameObject.SetActive(false);
        BlockDisabled?.Invoke(tag);
    }
}
