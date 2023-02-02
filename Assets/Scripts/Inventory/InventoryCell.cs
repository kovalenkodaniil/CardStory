using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _itemIcon;
    
    private Item _item;
    private bool _isEmpty = true;

    public Item Item => _item;
    public bool IsEmpty => _isEmpty;

    public event UnityAction<InventoryCell> CellClicked;
    public void Init(Item item)
    {
        _item= item;
        _itemIcon.gameObject.SetActive(true);
        _itemIcon.sprite = _item.Icon;
        _isEmpty = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsEmpty == false)
            CellClicked?.Invoke(this);
    }

    public void Reset()
    {
        _item=null;
        _isEmpty = true;
        _itemIcon.gameObject.SetActive(false);
    }
}
