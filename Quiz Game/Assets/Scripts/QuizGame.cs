using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizGame : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] Question[] questions;
    [SerializeField] TMPro.TextMeshProUGUI questionText;
    [Header("Answers")]
    [SerializeField] GameObject[] buttons;
    [Header("Timer")]
    [SerializeField] Timer timer;
    [Header("Score")]
    [SerializeField] Score score;
    [Header("Slider")]
    [SerializeField] GameObject slider;

    int currentQuestionIndex = 0;
    Color32 correctAnswerColor = new Color32(87, 255, 0, 255);
    Color32 wrongAnswerColor = new Color32(255, 0, 10, 255);
    Color32 neutralColor = new Color32(255, 255, 255, 255);

    private void Start()
    {
        WriteQuestionOnScreen();
    }

    //writes question and answer texts on screen
    private void WriteQuestionOnScreen()
    {
        questionText.text = questions[currentQuestionIndex].GetQuestionText();

        for(int i = 0; i < 4; i++)
        {
           buttons[i].transform.Find("Button " + (i + 1) + " Text").GetComponent<TMPro.TextMeshProUGUI>().text = questions[currentQuestionIndex].GetAnswerTexts()[i]; 
        }
    }

    //checks whether answer is correct or not
    public void CheckTheAnswer(int buttonIndex)
    {
        int corAnsInd = questions[currentQuestionIndex].GetCorrectAswerIndex();
        if(buttonIndex == corAnsInd)
        {
            buttons[buttonIndex].GetComponent<Image>().color = correctAnswerColor;
            score.IncreaseScore();
        }
        else
        {
            buttons[buttonIndex].GetComponent<Image>().color = wrongAnswerColor;
            buttons[corAnsInd].GetComponent<Image>().color = correctAnswerColor;
        }
        changeButtonInteractability(false);
        slider.GetComponent<Slider>().value = currentQuestionIndex+1;
        timer.SetToAnswerState();
    }

    //if time is up and no answer is given show the answer
    public void ShowTheAnswer()
    {
        buttons[questions[currentQuestionIndex].GetCorrectAswerIndex()].GetComponent<Image>().color = correctAnswerColor;
        changeButtonInteractability(false);

    }

    //changes buttons interactability
    private void changeButtonInteractability(bool a)
    {
        for(int i = 0; i < 4; i++)
        {
            buttons[i].GetComponent<Button>().interactable = a;
        }
    }

    //initiates next question
    public void GetAndSetNextQuestion()
    {
        changeButtonInteractability(true);
        //change button color to neutral color
        for (int i = 0; i < 4; i++)
        {
            buttons[i].GetComponent<Button>().GetComponent<Image>().color = neutralColor;
        }
        //increase question index
        currentQuestionIndex++;
        LoadEndSceneIfGameEnded();
        WriteQuestionOnScreen();
    }

    private void LoadEndSceneIfGameEnded()
    {
        if (currentQuestionIndex == 5)
        {
            SceneManager.LoadScene("End Screen");
        }
    }
}
