using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestinyStoneView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countValue;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _countValue.text = _player.DestinyStone.CurrentValue.ToString();
    }
}
