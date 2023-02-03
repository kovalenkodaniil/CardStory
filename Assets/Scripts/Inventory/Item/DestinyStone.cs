using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/Create new destiny stone", order = 51)]
public class DestinyStone : Item
{
    private const string ProgressType = "";

    [SerializeField] private int _progressBonus;

    public override void Use()
    {
        PlayerEvent.DestinyStoneChangeCount?.Invoke(-1);
        ChallengeScreen.ProgressChanged?.Invoke(_progressBonus, ProgressType);
    }
}
