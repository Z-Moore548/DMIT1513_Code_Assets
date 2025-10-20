using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int currentHelth, maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHelth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ApplyDamage(int damage)
    {
        currentHelth -= damage;
        Debug.Log("OW");
        BroadcastMessage("UpdateHealthBar", currentHelth);
        if (currentHelth <= 0)
        {
            currentHelth = 0;
            gameObject.SetActive(false);
        }
    
    }
}
