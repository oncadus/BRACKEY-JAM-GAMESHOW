using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class QuestioningLogic : MonoBehaviour
{
    public float time = 15;
    private float percentleft = 1;


    Question[] questions =
    {
        new Question("Does 3 + 5 equal to 9", false),
        new Question("Is the eifel tower in paris?", true),
        new Question("Jbone is a stupid big dumb face", true) // teehee
    };

    Question currentQuestion;

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        VisualElement timer = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("Timer");

        while (time > 0)
        {
            time -= Time.deltaTime;
            percentleft = time / 15;
            timer.style.scale = new Scale(new Vector3(percentleft, 1, 01));
            yield return null;
        }

        SceneManager.LoadScene("Lose");
    }


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


        // These are hover events
        falseButton.RegisterCallback<MouseOverEvent>((type) =>
        {
            falseButton.style.opacity = 0.5f;
        });

        falseButton.RegisterCallback<MouseOutEvent>((type) =>
        {
            falseButton.style.opacity = 1f;
        });

        trueButton.RegisterCallback<MouseOverEvent>((type) =>
        {
            trueButton.style.opacity = 0.5f;
        });

        trueButton.RegisterCallback<MouseOutEvent>((type) =>
        {
            trueButton.style.opacity = 1f;
        });


        // Assign first question
        currentQuestion = questions[2];
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
