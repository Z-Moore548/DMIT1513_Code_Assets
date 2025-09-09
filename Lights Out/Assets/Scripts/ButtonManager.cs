using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    bool[] buttonsSate = new bool[9];
    [SerializeField] GameObject[] buttons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i <= 9; i++)
        {
            buttonsSate[i] = false;
        }
        ChangeAll();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Reset()
    {
        Start();
    }

    public void Clicked(int i)
    {
        buttonsSate[i] = !buttonsSate[i];
        ChangeColor(i);
        ChangeSuround(i);
    }

    void ChangeColor(int i)
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
    void ChangeAll()
    {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Image>().color = Color.black;
        }
    }

    void ChangeSuround(int num)
    {
        GameObject up = null, down = null, left = null, right = null;
        up = buttons[num].GetComponent<Button>().FindSelectableOnUp().GetComponent<Button>().gameObject;
        down = buttons[num].GetComponent<Button>().FindSelectableOnDown().GetComponent<Button>().gameObject;
        left = buttons[num].GetComponent<Button>().FindSelectableOnLeft().GetComponent<Button>().gameObject;
        right = buttons[num].GetComponent<Button>().FindSelectableOnRight().GetComponent<Button>().gameObject;

        for (int i = 0; i < 9; i++)
        {
            if (up != null)
            {
                if (buttons[i] == up)
                {
                    buttonsSate[i] = !buttonsSate[i];
                    ChangeColor(i);
                }
            }
            if (down != null)
            {
                if (buttons[i] == down)
                {
                    buttonsSate[i] = !buttonsSate[i];
                    ChangeColor(i);
                }
            }
            if (left != null)
            {
                if (buttons[i] == left)
                {
                    buttonsSate[i] = !buttonsSate[i];
                    ChangeColor(i);
                }
            }
            if (right != null)
            {
                if (buttons[i] == right)
                {
                    buttonsSate[i] = !buttonsSate[i];
                    ChangeColor(i);
                }
            }
        }
    }
}
