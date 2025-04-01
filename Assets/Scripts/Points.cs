using System;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI[] TryAgainText;
    public int score { get; set; }
    public GameObject[] Objects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        scoreText.text = score.ToString("0");
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString("0");
    }

    public void GameOver(bool isLoose)
    {
        if (isLoose)
        {
            for (int i = 0; i < Objects.Length; i++)
            {
                Objects[i].SetActive(false);
                
            }

            for (int y = 0; y < TryAgainText.Length; y++)
            {
                TryAgainText[y].gameObject.SetActive(true);
            }
        }
    }
}
