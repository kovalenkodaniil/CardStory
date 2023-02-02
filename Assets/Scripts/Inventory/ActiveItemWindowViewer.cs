using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveItemWindowViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private Button _useButton;
    [SerializeField] private Button _dropButton;

    private InventoryCell _inventoryCell;
    private Item _item;

    private void OnEnable()
    {
        _useButton.onClick.AddListener(OnUseButtonClicked);
        _dropButton.onClick.AddListener(OnDropButtonClicked);
    }

    private void OnDisable()
    {
        _useButton.onClick.RemoveListener(OnUseButtonClicked);
        _dropButton.onClick.RemoveListener(OnDropButtonClicked);
    }

    public void Show(InventoryCell cell)
    {
        _inventoryCell = cell;
        _item = cell.Item;

        gameObject.SetActive(true);

        _itemName.text = _item.Name;
        _itemDescription.text = _item.Description;
    }

    private void OnUseButtonClicked()
    {
        _item.Use();
        _inventoryCell.Reset();
    }

    private void OnDropButtonClicked()
    {
        _inventoryCell.Reset();
    }
}
