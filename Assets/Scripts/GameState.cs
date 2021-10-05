using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    private string m_SaveFile;

    public static GameState Instance;
    public string PlayerName;

    public HighScore Record;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Initialize();
    }

    private void Initialize()
    {
        m_SaveFile = System.IO.Path.Combine(Application.persistentDataPath, "saveFile.json");
        LoadHighScore();
    }

    [System.Serializable]
    public class HighScore
    {
        public string Name;
        public int Score;
    }

    public void SetHighScore(int score)
    {
        Record.Name = PlayerName;
        Record.Score = score;
    }

    private void LoadHighScore()
    {
        if (System.IO.File.Exists(m_SaveFile))
            Record = JsonUtility.FromJson<HighScore>(System.IO.File.ReadAllText(m_SaveFile));
        else
            Record = new HighScore()
            {
                Name = "Your mom",
                Score = 10
            };
    }

    public void SaveHighScore()
    {
        System.IO.File.WriteAllText(m_SaveFile, JsonUtility.ToJson(Record));
    }
}
