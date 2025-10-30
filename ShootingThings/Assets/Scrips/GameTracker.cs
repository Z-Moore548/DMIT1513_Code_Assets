using UnityEngine;

public class GameTracker : MonoBehaviour
{
    [SerializeField] bool isQuestActive, gotMap, tresureGot;
    [SerializeField] GameObject tresure, UI;

    public bool IsQuestActive { get => isQuestActive; set => isQuestActive = value; }
    public bool GotMap { get => gotMap; set => gotMap = value; }
    public bool TresureGot { get => tresureGot; set => tresureGot = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isQuestActive = false;
        GotMap = false;
        tresureGot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gotMap)
        {
            tresure.SetActive(false);
        }
        else
        {
            if (tresureGot)
            {
                UI.GetComponent<QuestAndUI>().IsInteractable(false, 3);
                tresure.SetActive(false);
            }
            else
            {
                tresure.SetActive(true);
            }
            
        }
    }
}
