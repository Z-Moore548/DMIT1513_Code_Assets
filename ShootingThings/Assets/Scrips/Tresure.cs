using UnityEngine;

public class Tresure : MonoBehaviour
{
    [SerializeField] GameObject gameTracker, UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.GetComponent<QuestAndUI>().IsInteractable(true, 3);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.GetComponent<QuestAndUI>().IsInteractable(false, 3);
        }
    }
}
