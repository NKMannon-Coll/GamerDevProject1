using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIWriter : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Sharks: " + GameManager.Instance.score;
    }
    public void IncreaseScore() 
    {
        GameManager.Instance.IncScore();
        scoreText.text = "Sharks: " + GameManager.Instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
