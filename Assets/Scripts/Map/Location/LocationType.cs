using UnityEngine;

[CreateAssetMenu(fileName = "New type", menuName ="Location/Create location type", order = 51)]
public class LocationType : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _tag;

    public Sprite Icon => _icon;
    public string Tag => _tag;
}
