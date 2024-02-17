using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Text questionText;
    public Text rightButtonText;
    public Text wrongButtonText;
    public Button rightButton;
    public Button wrongButton;

    private int questionSet;
    private int buttonChoiceR;
    private int buttonChoiceL;

    private float timer;
    [SerializeField] private float nextQuestionSpawner;

    public string[] questions =
    {
        "What is 1 + 2?",
        "Who was in paris?",
        "Is Jbone a stupid big dumb face?"
    };

    public string[] rightAnswers =
    {
        "3",
        "African americans",
        "LOL!!!!!"
    };

    public string[] wrongAnswers =
    {
        "4",
        "Fellas",
        "noooo :<"
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name);  }
        
        

        if (timer < nextQuestionSpawner)
        {
            timer += Time.deltaTime;
        }
        else if (timer >=  nextQuestionSpawner)
        {
            wrongChoice();
        }

        if (buttonChoiceR == 0)
        {
            createQuestionSet();
        }
        else
        {
            createQuestionSet();
        }
    }

    public void createQuestionSet()
    {
        questionText.text = questions[questionSet];
        wrongButtonText.text = rightAnswers[questionSet];
        rightButtonText.text = wrongAnswers[questionSet];
    }

    public void rightChoice()
    {
        SceneManager.LoadScene("Win");
    }

    public void wrongChoice()
    {
        SceneManager.LoadScene("Lose");
    }
}
