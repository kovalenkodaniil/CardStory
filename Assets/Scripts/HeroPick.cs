using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HeroPick : MonoBehaviour
{
    [SerializeField] private int _strenght;
    [SerializeField] private int _knowledge;
    [SerializeField] private int _will;
    [SerializeField] private int _money;
    [SerializeField] private string _name;
    [SerializeField] private Player _player;
    [SerializeField] private Button _pickButton;

    [SerializeField] private TMP_Text _strenghtView;
    [SerializeField] private TMP_Text _knowledgeView;
    [SerializeField] private TMP_Text _willView;
    [SerializeField] private TMP_Text _moneyView;
    [SerializeField] private TMP_Text _nameView;

    public event UnityAction HeroPicked;
    private void OnEnable()
    {
        _pickButton.onClick.AddListener(OnButtonClicked);
    }

    private void Start()
    {
        _strenghtView.text = _strenght.ToString();
        _knowledgeView.text = _knowledge.ToString();
        _willView.text = _will.ToString();
        _moneyView.text = _money.ToString();
        _nameView.text = _name;
    }

    private void OnDisable()
    {
        _pickButton.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _player.Init(_strenght, _knowledge, _will, _money);
        HeroPicked?.Invoke();
    }
}
