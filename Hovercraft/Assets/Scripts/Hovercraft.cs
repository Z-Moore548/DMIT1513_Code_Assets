using UnityEngine;
using UnityEngine.InputSystem;

public class Hovercraft : MonoBehaviour
{
    [SerializeField] float moveSpeed, rotationSpeed;
    [SerializeField] GameObject groundDetectF, groundDetectB, detectR, detectL;
    [SerializeField] InputAction moveAction;
    Vector2 moveValue;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
    }

    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * moveValue.y * moveSpeed * Time.fixedDeltaTime);
        rb.AddRelativeTorque(Vector3.up * moveValue.x * rotationSpeed * Time.fixedDeltaTime);
        if (Physics.Linecast(transform.position, groundDetectF.transform.position, 1 << LayerMask.NameToLayer("Ground")) || Physics.Linecast(transform.position, groundDetectB.transform.position, 1 << LayerMask.NameToLayer("Ground")) || Physics.Linecast(transform.position, detectR.transform.position, 1 << LayerMask.NameToLayer("Ground")) || Physics.Linecast(transform.position, detectL.transform.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            rb.AddForce(Vector3.up * 1000 * Time.fixedDeltaTime, ForceMode.Force);
        }
        
    }
    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
