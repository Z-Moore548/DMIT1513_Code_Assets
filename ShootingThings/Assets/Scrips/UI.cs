using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Unity.VisualScripting;


public class QuestAndUI : MonoBehaviour
{
    [SerializeField] TMP_Text quest, quest2, spoken, interact, play;
    [SerializeField] GameObject dialogueBox, gameTracker, map, tresure, player;
    bool interactable;
    [SerializeField] int textNum;
    
    void Start()
    {
        dialogueBox.SetActive(false);
        interact.gameObject.SetActive(false);
        quest.gameObject.SetActive(false);
        quest2.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        map.SetActive(false);
        tresure.SetActive(false);
        textNum = 1;
    }


    void Update()
    {
        if (gameTracker.GetComponent<GameTracker>().GotMap)
        {
            map.SetActive(true);
        }
        if (gameTracker.GetComponent<GameTracker>().TresureGot)
        {
            tresure.SetActive(true);
        }
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
                        player.GetComponent<PlayerController>().MoveCamToSide(false);
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
                        player.GetComponent<PlayerController>().MoveCamToSide(false);
                        break;
                    case 6://get tresure
                        ShowTextBox();
                        ChangeDialogue("You got the Tresure!");
                        quest.gameObject.SetActive(false);
                        quest2.gameObject.SetActive(true);
                        gameTracker.GetComponent<GameTracker>().TresureGot = true;
                        textNum = 7;
                        break;
                    case 7:
                        IsInteractable(false, 3);
                        textNum = 6;
                        dialogueBox.SetActive(false);
                        player.GetComponent<PlayerController>().MoveCamToSide(false);
                        break;
                    case 8:
                        ShowTextBox();
                        ChangeDialogue("Thank you for bring me the Tresure!");
                        textNum = 9;
                        break;
                    case 9:
                        ChangeDialogue("You are true Hero!, thank you for Everything");
                        textNum = 10;
                        break;
                    case 10:
                        Application.Quit();
                        IsInteractable(true, 4);
                        textNum = 8;
                        dialogueBox.SetActive(false);
                        player.GetComponent<PlayerController>().MoveCamToSide(false);
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
                case 3:
                    textNum = 6;
                    break;
                case 4:
                    textNum = 8;
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
        player.GetComponent<PlayerController>().MoveCamToSide(true);
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
