using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction moveAction, rotateAction;
    [SerializeField] float moveSpeed, rotatingSpeed;
    [SerializeField] GameObject gameTracker, cameraPivot;
    
    Vector2 moveValue, rotateValue;
    Vector3 angles;
    Rigidbody rBody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Keyboard.current.escapeKey.isPressed)
        // {
        //     Application.Quit();
        // }
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
        transform.Rotate(Vector3.up, rotateValue.x * rotatingSpeed * Time.deltaTime);

        cameraPivot.transform.Rotate(Vector3.right, -rotateValue.y * rotatingSpeed * Time.deltaTime);

        angles = cameraPivot.transform.localEulerAngles;

        if (angles.x < 300 && angles.x > 180)
        {
            cameraPivot.transform.localRotation = Quaternion.Euler(300, 0, 0);
        }
        if(angles.x > 45 && angles.x < 180)
        {
            cameraPivot.transform.localRotation = Quaternion.Euler(45, 0, 0);
        }
    }
    void FixedUpdate()
    {
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up, rotateValue.x * rotatingSpeed * Time.fixedDeltaTime);

        cameraPivot.transform.Rotate(Vector3.right, -rotateValue.y * rotatingSpeed * Time.fixedDeltaTime);

        angles = cameraPivot.transform.localEulerAngles;

        if (angles.x < 300 && angles.x > 180)
        {
            cameraPivot.transform.localRotation = Quaternion.Euler(300, 0, 0);
        }
        if (angles.x > 45 && angles.x < 180)
        {
            cameraPivot.transform.localRotation = Quaternion.Euler(45, 0, 0);
        }

    }
    

    public void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
    }
    public void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
    }
}
