using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public (int, string)[] scoreArray = new (int, string)[10]
    {
        (0, "name"),
        (0, "name"),
        (0, "name"),
        (0, "name"),
        (0, "name"),
        (0, "name"),
        (0, "name"),
        (0, "name"),
        (0, "name"),
        (0, "name"),
    };

    private string dataPath = "/scores.json";

    private int lastScore = 0;

    public bool firstScreen = true;

    //[SerializeField] private TextMeshProUGUI nb;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        WriteData();
        LoadData();
    }

    private void Start()
    {
        
    }


    [System.Serializable]
    class Data
    {
        public int score1;
        public int score2;
        public int score3;
        public int score4;
        public int score5;
        public int score6;
        public int score7;
        public int score8;
        public int score9;
        public int score10;

        public string name1;
        public string name2;
        public string name3;
        public string name4;
        public string name5;
        public string name6;
        public string name7;
        public string name8;
        public string name9;
        public string name10;

    }

    //private void add

    public void WriteData() 
    {
        Data data = new Data();

        data.score1 = scoreArray[0].Item1;
        data.score2 = scoreArray[1].Item1;
        data.score3 = scoreArray[2].Item1;
        data.score4 = scoreArray[3].Item1;
        data.score5 = scoreArray[4].Item1;
        data.score6 = scoreArray[5].Item1;
        data.score7 = scoreArray[6].Item1;
        data.score8 = scoreArray[7].Item1;
        data.score9 = scoreArray[8].Item1;
        data.score10 = scoreArray[9].Item1;

        data.name1 = scoreArray[0].Item2;
        data.name2 = scoreArray[1].Item2;
        data.name3 = scoreArray[2].Item2;
        data.name4 = scoreArray[3].Item2;
        data.name5 = scoreArray[4].Item2;
        data.name6 = scoreArray[5].Item2;
        data.name7 = scoreArray[6].Item2;
        data.name8 = scoreArray[7].Item2;
        data.name9 = scoreArray[8].Item2;
        data.name10 = scoreArray[9].Item2;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + dataPath, json);
    }

    public void NewScore(int score) 
    {
        lastScore = score;
    }

    public void AddToList(string name) 
    {
        bool flag = true;
        (int, string) last = (0, "name");
        //var name = InputField.transform.GetChild(0).GetComponent<TMP_InputField>().text;
        //scoreArray[10] = (lastScore, name);
        for (int i = 0; i < 10; i++)
        {
            if (flag)
            {
                if (lastScore > scoreArray[i].Item1)
                {
                    last = scoreArray[i];
                    scoreArray[i] = (lastScore, name);
                    flag = false;
                }
            }
            else 
            {
                var temp = scoreArray[i];
                scoreArray[i] = last;
                last = temp;
            }
        }
        //DisableInputField();

    }

    

    public void LoadData() 
    {
        string path = Application.persistentDataPath + dataPath;
        //Debug.Log(Application.persistentDataPath + dataPath);
        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            scoreArray = new (int, string)[10]
            {
                (data.score1, data.name1),
                (data.score2, data.name2),
                (data.score3, data.name3),
                (data.score4, data.name4),
                (data.score5, data.name5),
                (data.score6, data.name6),
                (data.score7, data.name7),
                (data.score8, data.name8),
                (data.score9, data.name9),
                (data.score10, data.name10),
            };
        }
    }
}
