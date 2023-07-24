using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // make singleton
    public static GameManager Instance;

    public string playerName = "Player";
    public string highScoreplayerName = "Player";
    public int highScore { get; private set; }

    void Start()
    {

        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        StoreHighScore();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

        Application.Quit();
#endif
    }

    public void SetHighScore(int score)
    {
        highScore = score;
        Debug.Log("High Score Name: " + playerName);
        highScoreplayerName = playerName;

    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    public void StoreHighScore()
    {
        var saveData = new SaveData();
        saveData.name = highScoreplayerName;
        saveData.highScore = highScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var saveData = JsonUtility.FromJson<SaveData>(json);
            highScoreplayerName = saveData.name;
            highScore = saveData.highScore;
        }
    }

}
