using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataWriter : MonoBehaviour
{

    [SerializeField] private GameObject ScoreBoard;
    [SerializeField] private GameObject InputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WriteScores();
        if (DataManager.Instance.firstScreen)
        {
            DisableInputField();
            DataManager.Instance.firstScreen = false;
        }
        else 
        {
            InputField.active = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void AddScore() 
    {
        DataManager.Instance.AddToList(InputField.transform.GetChild(0).GetComponent<TMP_InputField>().text);
        WriteScores();
        DisableInputField();
    }

    private void DisableInputField()
    {
        InputField.active = false;
    }

    private void WriteScores()
    {
        for (int i = 0; i < 10; i++)
        {
            var nb = ScoreBoard.transform.GetChild(0).transform.GetChild(i + 2).GetComponent<TextMeshProUGUI>();
            nb.text = DataManager.Instance.scoreArray[i].Item2.ToString();
            var sb = ScoreBoard.transform.GetChild(1).transform.GetChild(i + 2).GetComponent<TextMeshProUGUI>();
            sb.text = DataManager.Instance.scoreArray[i].Item1.ToString();

            ///Debug.Log(jeff);
        }
    }
}
