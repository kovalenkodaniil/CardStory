using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/Create new destiny stone", order = 51)]
public class DestinyStone : Item
{
    private const string ProgressType = "";

    [SerializeField] private int _progressBonus;

    public override void Use()
    {
        GameEventManager.DestinyStoneChangeCount?.Invoke(-1);
        GameEventManager.ProgressChanged?.Invoke(_progressBonus, ProgressType);
    }
}
