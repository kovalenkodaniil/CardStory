using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private List<LocationType> _locationsType;
    [SerializeField] private List<MapBlock> MapBlocks;

    public event UnityAction<string> EventTypeSelected;

    private void OnEnable()
    {
        foreach (var mapBlock in MapBlocks)
        {
            mapBlock.BlockDisabled += OnBlockDisabled;
        }
    }

    private void Start()
    {
        CreateMap();
    }

    private void OnDisable()
    {
        foreach (var mapBlock in MapBlocks)
        {
            mapBlock.BlockDisabled -= OnBlockDisabled;
        }
    }

    public LocationType GetLocationType()
    {
        return _locationsType[Random.Range(0, _locationsType.Count)];
    }

    private void CreateMap()
    {
        foreach (var mapBlock in MapBlocks)
        {
            mapBlock.gameObject.SetActive(true);
            mapBlock.Init();
        }

        ActiveLocation();
    }

    private void OnBlockDisabled(string tag)
    {
        ActiveLocation();
        EventTypeSelected?.Invoke(tag);
    }

    private void ActiveLocation()
    {
        for (int i = MapBlocks.Count - 1; i >= 0; i--)
        {
            if (MapBlocks[i].gameObject.activeSelf)
            {
                MapBlocks[i].ActiveLocation();
                break;
            }
        }
    }
}
