using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreBoard;


 
    void Update()
    {
        scoreBoard.text = scoreText.text;
    }
}
