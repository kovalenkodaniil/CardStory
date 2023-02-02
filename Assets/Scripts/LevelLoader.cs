using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const string GameScene = "Game";

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(GameScene);
    }
}
