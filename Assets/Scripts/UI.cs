using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text ScoreText;
    public CanvasGroup StartScreenCanvasGroup;
    
    public void SetScoreText(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
}
