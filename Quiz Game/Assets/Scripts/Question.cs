using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Question")]


public class Question : ScriptableObject
{
    [TextArea(5,10)]
    [SerializeField] string questionText;
    [TextArea(2, 6)]
    [SerializeField] string[] answers;
    [SerializeField] int correctAnswerIndex;

    //returns question text
    public string GetQuestionText()
    {
        return questionText;
    }
    //returns array of answer texts
    public string[] GetAnswerTexts()
    {
        return answers;
    }
    //return index of correct answer in answer array
    public int GetCorrectAswerIndex()
    {
        return correctAnswerIndex;
    }
}
