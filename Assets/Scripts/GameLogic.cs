using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Text questionText;
    public Text rightButtonText;
    public Text wrongButtonText;

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
        //int currentQuestion = Random.Range(0, questions.Length);
        
        //int buttonChoiceR = Random.Range(0, 2);
        //int buttonChoiceL = Random.Range(0, 2);

        /*if (buttonChoiceR == 0)
        {
            int questionSet = Random.Range(0, 3);
            
        }
        else
        {
            int questionSet = Random.Range(0, 3);
            questionText.text = questions[questionSet];
            wrongButtonText.text = rightAnswers[questionSet];
            rightButtonText.text = wrongAnswers[questionSet];
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name);  }
        
    }
}
