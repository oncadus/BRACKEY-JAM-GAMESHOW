using Assets.Scripts;
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
    [SerializeField] private float timelimit;

    public Question[] questions =
    {
        new Question("Does 3 + 5 equal to 9", false),
        new Question("Is the eifel tower in paris?", true),
        new Question("Jbone is a stupid big dumb face", true) // teehee
    };

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name);  }
        
        

        if (timer < timelimit)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= timelimit)
        {
            wrongChoice();
        }


        Debug.Log(buttonChoiceR);
    }

    public void createQuestionSet()
    {
        questionText.text = questions[0].question;
        wrongButtonText.text = "False";
        rightButtonText.text = "True";
    }

    public void CheckGivenAnswer(bool answer)
    {
        if (answer == questions[0].answer)
        {
            rightChoice();
        }
        else
        {
            wrongChoice();
        }
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
