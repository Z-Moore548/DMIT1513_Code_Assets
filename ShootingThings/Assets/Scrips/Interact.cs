using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] GameObject UI;
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
            UI.GetComponent<QuestAndUI>().IsInteractable(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.GetComponent<QuestAndUI>().IsInteractable(false);
        }
    }
}
