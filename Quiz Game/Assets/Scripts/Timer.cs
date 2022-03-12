using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject timer;
    [SerializeField] string gameState;
    [SerializeField] QuizGame quizGame;

    string QUESTION_STATE = "QUESTION";
    string ANSWER_STATE = "ANSWER";

    void Start()
    {
        //set the game state
        gameState = QUESTION_STATE;
    }


    void Update()
    {
        UpdateTimer();
        FillTimerAndChangeGameState();
    }

    private void FillTimerAndChangeGameState()
    {
        if (timer.GetComponent<Image>().fillAmount == 0)
        {
            FillTheTimer();

            if (gameState == QUESTION_STATE)
            {
                gameState = ANSWER_STATE;
                quizGame.ShowTheAnswer();
            }
            else
            {
                gameState = QUESTION_STATE;
                quizGame.GetAndSetNextQuestion();
            }
        }
    }

    private void FillTheTimer()
    {
        timer.GetComponent<Image>().fillAmount = 1;
    }

    public void SetToAnswerState()
    {
        gameState = ANSWER_STATE;
        FillTheTimer();

    }

    private void UpdateTimer()
    {
        if (QUESTION_STATE == gameState)
        {
            //10 saniyede timer biter
            timer.GetComponent<Image>().fillAmount -= (Time.deltaTime * 1 / 8);
        }
        else
        {
            timer.GetComponent<Image>().fillAmount -= (Time.deltaTime * 1 / 3);
        }
    }
}
