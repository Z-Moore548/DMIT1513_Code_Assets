using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] GameObject UI;
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
            if (who == TalkingTo.steve)
            {
                UI.GetComponent<QuestAndUI>().IsInteractable(true, 1);
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
            if (who == TalkingTo.steve)
            {
                UI.GetComponent<QuestAndUI>().IsInteractable(false, 1);
            }
            if(who == TalkingTo.merchant)
            {
                UI.GetComponent<QuestAndUI>().IsInteractable(false, 2);
            }
        }
    }
}
