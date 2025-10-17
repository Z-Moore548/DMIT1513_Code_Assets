using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    float fireRate, timeStamp;
    [SerializeField] GameObject barrelEnd;
    [SerializeField] GameObject[] projectiles = new GameObject[2];
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireRate = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.isPressed)
        {
            index = 0;
        }
        if (Keyboard.current.digit2Key.isPressed)
        {
            index = 1;
        }
    }
    void FireWeapon()
    {
        if(Time.time > timeStamp + fireRate)
        {
            GameObject instantiatedObject = Instantiate(projectiles[index], barrelEnd.transform.position, barrelEnd.transform.rotation);

            Rigidbody rbody = instantiatedObject.GetComponent<Rigidbody>();

            if(rbody != null)
            {
                rbody.linearVelocity = barrelEnd.transform.forward * 20;
                timeStamp = Time.time;
            }
        }
    }
}
