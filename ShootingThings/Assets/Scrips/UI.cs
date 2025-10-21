using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class QuestAndUI : MonoBehaviour
{
    [SerializeField] TMP_Text quest, spoken, interact;
    [SerializeField] GameObject dialogueBox;
    bool interactable;
    int textNum;
    
    void Start()
    {
        dialogueBox.SetActive(false);
        interact.gameObject.SetActive(false);
        quest.gameObject.SetActive(false);
        textNum = 1;
    }


    void Update()
    {
        if (interactable)
        {
            switch (textNum)
            {
                case 1:
                    if (Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        ShowTextBox();
                        ChangeDialogue("I Have A Quest For You Brave Adventurer.");
                        textNum = 2;
                    }
                break;
                case 2:
                    if(Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        ChangeDialogue("Those Enemies over there have a tresure map. Bring me the tresure once you found it.");
                        textNum = 3;
                        quest.gameObject.SetActive(true);
                    }
                    break;
                case 3:
                    if(Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        IsInteractable(true);
                        textNum = 1;
                        dialogueBox.SetActive(false);
                    }
                    break;

            }
            
        }
    }

    public void IsInteractable(bool yes)
    {
        if (yes)
        {
            interact.gameObject.SetActive(true);
            interactable = true;
        }
        else
        {
            interact.gameObject.SetActive(false);
            interactable = false;
            dialogueBox.SetActive(false);
        }
    }

    void ShowTextBox()
    {
        dialogueBox.SetActive(true);
        interact.gameObject.SetActive(false);
    }
    void ChangeDialogue(string text)
    {
        spoken.text = text;
    }
}
