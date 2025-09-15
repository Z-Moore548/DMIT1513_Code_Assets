using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TMP_Text minBox;
    [SerializeField] TMP_Text maxBox;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] TMP_InputField input;
    [SerializeField] TMP_Text question, qLeft, correct, results;
    [SerializeField] Button backbutton;

    private int minNum, maxNum, questionsLeft, correctAnswer, rand1, rand2;
    private float percentage;
    private string symbol;

    void Start()
    {
        minNum = 0;
        maxNum = 20;
    }

    void Update()
    {
        qLeft.text = $"Questions Left: {questionsLeft}";
        correct.text = $"Correct Answers: {correctAnswer}";
    }
    public void MinUp()
    {
        if (maxNum > minNum + 1)
        {
            minBox.text = minNum + 1 + "";
            minNum++;
        }

    }
    public void MinDown()
    {
        if (minNum > 0)
        {
            minBox.text = minNum - 1 + "";
            minNum--;
        }

    }
    public void MaxUp()
    {
        if (maxNum < 99)
        {
            maxBox.text = maxNum + 1 + "";
            maxNum++;
        }
    }
    public void MaxDown()
    {
        if (maxNum > minNum + 1)
        {
            maxBox.text = maxNum - 1 + "";
            maxNum--;
        }
    }

    public void Begin()
    {
        anim.SetBool("StartGame", true);
        switch (dropdown.value)
        {
            case 0:
                symbol = "+";
                break;
            case 1:
                symbol = "-";
                break;
            case 2:
                symbol = "*";
                break;
        }
        questionsLeft = 10;
        correctAnswer = 0;
        input.interactable = true;
        backbutton.interactable = false;
        rand1 = Random.Range(minNum, maxNum + 1);
        rand2 = Random.Range(minNum, maxNum + 1);

        question.text = $"{rand1} {symbol} {rand2} =";
        results.text = "";
        input.text = "";
    }

    public void Back()
    {
        anim.SetBool("StartGame", false);
    }

    public void OnAnswer()
    {
        int answer = int.Parse(input.text);
        switch (dropdown.value)
        {
            case 0:
                if (answer == rand1 + rand2)
                {
                    correctAnswer++;
                }
                break;
            case 1:
                if (answer == rand1 - rand2)
                {
                    correctAnswer++;
                }
                break;
            case 2:
                if (answer == rand1 * rand2)
                {
                    correctAnswer++;
                }
                break;
        }
        questionsLeft--;
        if (questionsLeft <= 0)
        {
            input.interactable = false;
            percentage = (correctAnswer / 10f) * 100;
            results.text = $"You Got {percentage}%";
            backbutton.interactable = true;
        }
        else
        {
            rand1 = Random.Range(minNum, maxNum + 1);
            rand2 = Random.Range(minNum, maxNum + 1);

            question.text = $"{rand1} {symbol} {rand2} =";
            input.text = "";
            input.ActivateInputField();
        }
    }

}
