using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _cellsCountMax;
    [SerializeField] private List<InventoryCell> _cells;
    [SerializeField] private ActiveItemWindowViewer _activeItemWindowViewer;

    private void Awake()
    {
        Player.ItemTaked += AddItem;
    }

    private void OnEnable()
    {
        foreach (var cell in _cells)
        {
            cell.CellClicked += OnCellClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var cell in _cells)
        {
            cell.CellClicked -= OnCellClicked;
        }
    }

    private void OnDestroy()
    {
        Player.ItemTaked -= AddItem;
    }

    private void AddItem(Item item)
    {
        foreach (var cell in _cells) 
        {
            if (cell.IsEmpty)
            {
                cell.Init(item);
                break;
            }
        }
    }

    private void OnCellClicked(InventoryCell cell)
    {
        _activeItemWindowViewer.Show(cell);
    }
}
