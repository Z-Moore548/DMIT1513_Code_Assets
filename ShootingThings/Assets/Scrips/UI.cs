using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class QuestAndUI : MonoBehaviour
{
    [SerializeField] TMP_Text quest, spoken, interact, play;
    [SerializeField] GameObject dialogueBox, gameTracker;
    bool interactable;
    [SerializeField] int textNum;
    
    void Start()
    {
        dialogueBox.SetActive(false);
        interact.gameObject.SetActive(false);
        quest.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        textNum = 1;
    }


    void Update()
    {
        if (interactable)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {


                switch (textNum)
                {
                    case 1://Steve Dialogue
                        ShowTextBox();
                        ChangeDialogue("I Have A Quest For You Brave Adventurer.");
                        textNum = 2;
                        break;
                    case 2:
                        ChangeDialogue("That guy over there has a tresure map. Bring me the tresure once you found it.");
                        textNum = 3;
                        quest.gameObject.SetActive(true);
                        gameTracker.GetComponent<GameTracker>().IsQuestActive = true;
                    
                        break;
                    case 3:
                        IsInteractable(true, 1);
                        textNum = 1;
                        dialogueBox.SetActive(false);
                        break;
                    case 4://Merchant Dialogue
                        ShowTextBox();
                        ChangeDialogue("Play my game to earn a Treasure Map.");
                        textNum = 5;
                        break;
                    case 5:
                        IsInteractable(true, 2);
                        textNum = 4;
                        dialogueBox.SetActive(false);
                        break;

                }
            }
            
        }
    }

    public void IsInteractable(bool yes, int who)
    {
        if (yes)
        {
            interact.gameObject.SetActive(true);
            interactable = true;
            switch (who)
            {
                case 1:
                    textNum = 1;
                    break;
                case 2:
                    textNum = 4;
                    break;
            }
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
    public void PlayText(bool yes)
    {
        if (yes)
        {
            play.gameObject.SetActive(true);
        }
        else
        {
            play.gameObject.SetActive(false);
        }
    }
}
