using UnityEngine;

[CreateAssetMenu(fileName = "New book", menuName = "Item/Create new book", order = 51)]
public class Book : Item
{
    [SerializeField] private int _knowledgeBonus;

    public override void Use()
    {
        PlayerEvent.KnowledgeChanged?.Invoke(_knowledgeBonus);
    }
}
