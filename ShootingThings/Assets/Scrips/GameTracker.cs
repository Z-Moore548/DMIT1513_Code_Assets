using UnityEngine;

public class GameTracker : MonoBehaviour
{
    bool isQuestActive, isQuestCompleted;

    public bool IsQuestActive { get => isQuestActive; set => isQuestActive = value; }
    public bool IsQuestCompleted { get => isQuestCompleted; set => isQuestCompleted = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isQuestActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
