using TMPro;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TMP_Text minBox;
    [SerializeField] TMP_Text maxBox;
    [SerializeField] TMP_Text question, qLeft, correct, results;//these have nothing in thier slot yet.
    private int minNum, maxNum; //have not done the operation selector.

    void Start()
    {
        minNum = 0;
        maxNum = 20;
    }

    void Update()
    {

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
        
    }
    
    public void Back()
    {
        anim.SetBool("StartGame", false);
    }
}
