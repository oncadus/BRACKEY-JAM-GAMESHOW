using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class QuestioningLogic : MonoBehaviour
{
    Question[] questions =
    {
        new Question("Does 3 + 5 equal to 9", false),
        new Question("Is the eifel tower in paris?", true),
        new Question("Jbone is a stupid big dumb face", true) // teehee
    };

    Question currentQuestion;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button trueButton = root.Q<Button>("True");
        Button falseButton = root.Q<Button>("False");

        Label questionLabel = root.Q<Label>("Question");

        // These are click events
        trueButton.clicked += () =>
        {
            CheckAnswer(true);
        };

        falseButton.clicked += () =>
        {
            CheckAnswer(false);
        };


        // Assign first question
        currentQuestion = questions[0];
        questionLabel.text = currentQuestion.question;

    }


    private void CheckAnswer(bool answer)
    {
        bool isCorrect = answer == currentQuestion.answer;

        if (isCorrect)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
