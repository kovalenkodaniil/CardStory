using System.IO;
using UnityEngine;

public class TextLoader
{
    public string EventText;
    public string ChallengeText;
    public string Choice1Name;
    public string Choice2Name;
    public string Choice3Name;
    public string Choice1Text;
    public string Choice2Text;
    public string Choice3Text;

    public TextLoader Load(string path)
    {
        return JsonUtility.FromJson<TextLoader>(File.ReadAllText(Application.streamingAssetsPath +"/"+path));
    }
}
