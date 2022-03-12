using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;

    void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "SCORE : " + score;
    }

    public void IncreaseScore()
    {
        score += 20;
    }
}
