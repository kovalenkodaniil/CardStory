using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/Create new item", order =51)]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _cost;

    public Sprite Icon => _icon;
    public string Name => _name;
    public string Description => _description;
    public int Cost => _cost;

    public virtual void Use()
    {

    }
}
