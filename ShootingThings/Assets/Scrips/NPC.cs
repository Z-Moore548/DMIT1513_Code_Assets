using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject map, mapSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Health>().CurrentHelth == 0)
        {
            Instantiate(map, mapSpawn.transform);
        }
    }
}
