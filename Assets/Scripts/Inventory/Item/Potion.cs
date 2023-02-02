using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/Create new potion", order = 51)]
public class Potion : Item
{
    public override void Use()
    {
        GameEventManager.RestoreCardCalled?.Invoke();
    }
}