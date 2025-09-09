using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    bool[] buttonsSate = new bool[9];
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject textBox;
    bool didWin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            buttonsSate[i] = false;
        }
        ChangeAll();
    }

    // Update is called once per frame
    void Update()
    {
        didWin = true; // everything here checks if you have won
        for (int i = 0; i < 9; i++)
        {

            if (!buttonsSate[i])
            {
                didWin = false;
            }
        }
        if (didWin)
        {
            textBox.GetComponent<TMP_Text>().text = "You Win!";
        }
    }
    public void Reset()
    {
        for (int i = 0; i < 9; i++)
        {
            buttonsSate[i] = false;
        }
        ChangeAll();
        didWin = false;
        textBox.GetComponent<TMP_Text>().text = "Lights On";
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Clicked(int i)// click event
    {
        buttonsSate[i] = !buttonsSate[i];
        ChangeColor(i);
        ChangeSuround(i);
    }

    void ChangeColor(int i) //changes the tile to the opposite color
    {
            if (buttonsSate[i])
            {
                buttons[i].GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                buttons[i].GetComponent<Image>().color = Color.black;
            }
    }
    void ChangeAll() //changes all tiles to the same color
    {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Image>().color = Color.black;
        }
    }

    void ChangeSuround(int num)
    {
        switch (num) //this is me just brute forcing it. it works but its super cumbersome.
        {
            case 0:
                buttonsSate[1] = !buttonsSate[1];
                ChangeColor(1);
                buttonsSate[3] = !buttonsSate[3];
                ChangeColor(3);
                break;
            case 1:
                buttonsSate[0] = !buttonsSate[0];
                ChangeColor(0);
                buttonsSate[4] = !buttonsSate[4];
                ChangeColor(4);
                buttonsSate[2] = !buttonsSate[2];
                ChangeColor(2);
                break;
            case 2:
                buttonsSate[1] = !buttonsSate[1];
                ChangeColor(1);
                buttonsSate[5] = !buttonsSate[5];
                ChangeColor(5);
                break;
            case 3:
                buttonsSate[0] = !buttonsSate[0];
                ChangeColor(0);
                buttonsSate[4] = !buttonsSate[4];
                ChangeColor(4);
                buttonsSate[6] = !buttonsSate[6];
                ChangeColor(6);
                break;
            case 4:
                buttonsSate[1] = !buttonsSate[1];
                ChangeColor(1);
                buttonsSate[3] = !buttonsSate[3];
                ChangeColor(3);
                buttonsSate[5] = !buttonsSate[5];
                ChangeColor(5);
                buttonsSate[7] = !buttonsSate[7];
                ChangeColor(7);
                break;
            case 5:
                buttonsSate[2] = !buttonsSate[2];
                ChangeColor(2);
                buttonsSate[4] = !buttonsSate[4];
                ChangeColor(4);
                buttonsSate[8] = !buttonsSate[8];
                ChangeColor(8);
                break;
            case 6:
                buttonsSate[3] = !buttonsSate[3];
                ChangeColor(3);
                buttonsSate[7] = !buttonsSate[7];
                ChangeColor(7);
                break;
            case 7:
                buttonsSate[6] = !buttonsSate[6];
                ChangeColor(6);
                buttonsSate[4] = !buttonsSate[4];
                ChangeColor(4);
                buttonsSate[8] = !buttonsSate[8];
                ChangeColor(8);
                break;
            case 8:
                buttonsSate[5] = !buttonsSate[5];
                ChangeColor(5);
                buttonsSate[7] = !buttonsSate[7];
                ChangeColor(7);
                break;
        }
        // GameObject up = null, down = null, left = null, right = null;
        // up = buttons[num].GetComponent<Button>().FindSelectableOnUp().GetComponent<Button>().gameObject;
        // down = buttons[num].GetComponent<Button>().FindSelectableOnDown().GetComponent<Button>().gameObject;
        // left = buttons[num].GetComponent<Button>().FindSelectableOnLeft().GetComponent<Button>().gameObject;
        // right = buttons[num].GetComponent<Button>().FindSelectableOnRight().GetComponent<Button>().gameObject;

        // for (int i = 0; i < 9; i++)
        // {
        //     if (up != null)
        //     {
        //         if (buttons[i] == up)
        //         {
        //             buttonsSate[i] = !buttonsSate[i];
        //             ChangeColor(i);
        //         }
        //     }
        //     if (down != null)
        //     {
        //         if (buttons[i] == down)
        //         {
        //             buttonsSate[i] = !buttonsSate[i];
        //             ChangeColor(i);
        //         }
        //     }
        //     if (left != null)
        //     {
        //         if (buttons[i] == left)
        //         {
        //             buttonsSate[i] = !buttonsSate[i];
        //             ChangeColor(i);
        //         }
        //     }
        //     if (right != null)
        //     {
        //         if (buttons[i] == right)
        //         {
        //             buttonsSate[i] = !buttonsSate[i];
        //             ChangeColor(i);
        //         }
        //     }
    }
}
