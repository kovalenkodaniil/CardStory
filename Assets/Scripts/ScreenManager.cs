using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _challengeScreen;
    [SerializeField] private GameObject _mapScreen;
    [SerializeField] private GameObject _eventScreen;
    [SerializeField] private GameObject _pickHeroScreen;
    [SerializeField] private GameObject _inventoryScreen;
    [SerializeField] private GameObject _upgradeScreen;
    [SerializeField] private GameObject _dieScreen;

    private GameObject _currentScreen;

    private void Start()
    {
        _challengeScreen.SetActive(false);
        _mapScreen.SetActive(false);
        _eventScreen.SetActive(false);
        _inventoryScreen.SetActive(false);
        _upgradeScreen.SetActive(false);
        _dieScreen.SetActive(false);

        _currentScreen = _pickHeroScreen;

        ShowScreen(_pickHeroScreen);
    }

    private void ShowScreen(GameObject screenForShow)
    {
        _currentScreen.SetActive(false);

        screenForShow.SetActive(true);

        _currentScreen = screenForShow;
    }

    public void ShowEvenScreen()
    {
        ShowScreen(_eventScreen);
    }

    public void ShowUpgradeScreen()
    {
        _upgradeScreen.SetActive(true);
    }

    public void ShowChallangeScreen() 
    {
        ShowScreen(_challengeScreen);
    }

    public void ShowMapScreen()
    {
        ShowScreen(_mapScreen);
    }

    public void ShowInventoryScreen()
    {
        _inventoryScreen.SetActive(true);
    }

    public void ShowDieScreen()
    {
        ShowScreen(_pickHeroScreen);
        _dieScreen.SetActive(true);
    }
}
