using UnityEngine;
using UnityEngine.InputSystem;

public class HealthUI : MonoBehaviour
{
    [SerializeField] RectTransform greenHealth;
    [SerializeField] GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
    
    void UpdateHealthBar(int currentHelth)
    {
        Debug.Log("Up");
        int f = currentHelth / 10;
        greenHealth.localScale = new Vector3(f, 1.1f, 1);
        
    }
}
