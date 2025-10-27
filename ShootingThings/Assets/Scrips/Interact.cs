using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] GameObject UI, gameTracker, player;
    [SerializeField] TalkingTo who;
    enum TalkingTo{ steve, merchant}
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().MoveCamToSide(true);
            if (who == TalkingTo.steve)
            {
                if (gameTracker.GetComponent<GameTracker>().TresureGot)
                {
                    UI.GetComponent<QuestAndUI>().IsInteractable(true, 4);
                }
                else
                {
                    UI.GetComponent<QuestAndUI>().IsInteractable(true, 1);
                }
                
            }
            if(who == TalkingTo.merchant)
            {
                UI.GetComponent<QuestAndUI>().IsInteractable(true, 2);
            }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().MoveCamToSide(false);
            if (who == TalkingTo.steve)
            {
                if (gameTracker.GetComponent<GameTracker>().TresureGot)
                {
                    UI.GetComponent<QuestAndUI>().IsInteractable(false, 4);
                }
                else
                {
                    UI.GetComponent<QuestAndUI>().IsInteractable(false, 1);
                }
            }
            if(who == TalkingTo.merchant)
            {
                UI.GetComponent<QuestAndUI>().IsInteractable(false, 2);
            }
        }
    }
}
