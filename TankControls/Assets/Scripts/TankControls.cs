using UnityEngine;
using UnityEngine.InputSystem;

public class TankControls : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3.0f, rotationSpeed = 100.0f, angleSpeed, forwardValue, backValue, rightValue, leftValue;
    [SerializeField] GameObject turret, cannon, shoot;
    [SerializeField] GameObject ballPrefab;
    private bool fired;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }

        //Keyboard Control
        if (Keyboard.current.wKey.isPressed)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
            transform.Rotate(Vector3.up * (rotationSpeed / 2) * Time.fixedDeltaTime);
        }
        if (Keyboard.current.iKey.isPressed)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
            transform.Rotate(-Vector3.up * (rotationSpeed / 2) * Time.fixedDeltaTime);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.Translate(-Vector3.forward * movementSpeed * Time.fixedDeltaTime);
            transform.Rotate(-Vector3.up * (rotationSpeed / 2) * Time.fixedDeltaTime);
        }
        if (Keyboard.current.kKey.isPressed)
        {
            transform.Translate(-Vector3.forward * movementSpeed * Time.fixedDeltaTime);
            transform.Rotate(Vector3.up * (rotationSpeed / 2) * Time.fixedDeltaTime);
        }

        //Turret Rotation
        if (Keyboard.current.dKey.isPressed)
        {
            turret.transform.Rotate(-Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }
        if (Keyboard.current.jKey.isPressed)
        {
            turret.transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }

        //Cannon angle
        if (Keyboard.current.oKey.isPressed)
        {
            cannon.transform.Rotate(-Vector3.right * angleSpeed * Time.fixedDeltaTime);
        }
        if (Keyboard.current.lKey.isPressed)
        {
            cannon.transform.Rotate(Vector3.right * angleSpeed * Time.fixedDeltaTime);
        }

        //Shoot
        if (Keyboard.current.spaceKey.isPressed && !fired) //will alwyas fire forward game space, not in relation to cannon
        {
            //intanstiate and add force to an object
            GameObject Projectile = Instantiate(ballPrefab);
            Projectile.transform.position = shoot.transform.position;
            Projectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Impulse);
            fired = true;
        }
        if (Keyboard.current.rKey.isPressed)
        {
            fired = false;
        }
        //Gamepad Controls!
        // forwardValue = Gamepad.current.leftStick.up.value;
        // backValue = Gamepad.current.leftStick.down.value;
        // rightValue = Gamepad.current.leftStick.right.value;
        // leftValue = Gamepad.current.leftStick.left.value;
        // transform.Translate(Vector3.forward * (forwardValue - backValue) * movementSpeed * Time.fixedDeltaTime);
        // transform.Rotate(Vector3.up * (rightValue - leftValue) * rotationSpeed * Time.fixedDeltaTime);
    }
}
