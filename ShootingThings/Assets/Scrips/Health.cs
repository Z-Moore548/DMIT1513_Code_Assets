using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int currentHelth, maxHealth;
    [SerializeField] GameObject map, mapSpawn;
    [SerializeField] bool dropsMap;

    public int CurrentHelth { get => currentHelth; set => currentHelth = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHelth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ApplyDamage(int damage)
    {
        CurrentHelth -= damage;
        Debug.Log("OW");
        BroadcastMessage("UpdateHealthBar", CurrentHelth);
        if (CurrentHelth <= 0)
        {
            CurrentHelth = 0;
            if (dropsMap)
            {
                Instantiate(map, mapSpawn.transform);
            }
            
            gameObject.SetActive(false);
        }
    
    }
}
