using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            collision.gameObject.GetComponent<Health>().ApplyDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
