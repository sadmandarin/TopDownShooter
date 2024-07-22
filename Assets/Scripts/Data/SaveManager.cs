using System.IO;
using UnityEngine;

public class SaveManager
{
    private static string filePath = Path.Combine(Application.persistentDataPath, "maxScore.json");

    public static void SaveMaxScore(int maxScore)
    {
        string json = JsonUtility.ToJson(new Data(maxScore));
        File.WriteAllText(filePath, json);
    }

    public static int LoadMaxScore()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Data scoreData = JsonUtility.FromJson<Data>(json);
            return scoreData.Score;
        }
        return 0;
    }

}
