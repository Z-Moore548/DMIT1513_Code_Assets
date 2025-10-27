using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction moveAction, rotateAction, fireAction, jumpAction;
    [SerializeField] float moveSpeed, rotatingSpeed, jumpForce;
    [SerializeField] GameObject weaponPivot, gameTracker;
    [SerializeField] GameObject firstPerson, thirdPerson, mainCam;
    bool inFirstPerson;
    Vector2 moveValue, rotateValue;
    Vector3 angles;
    Rigidbody rBody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
        inFirstPerson = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
        transform.Rotate(Vector3.up, rotateValue.x * rotatingSpeed * Time.deltaTime);

        weaponPivot.transform.Rotate(Vector3.right, -rotateValue.y * rotatingSpeed * Time.deltaTime);

        angles = weaponPivot.transform.localEulerAngles;

        if (angles.x < 300 && angles.x > 180)
        {
            weaponPivot.transform.localRotation = Quaternion.Euler(300, 0, 0);
        }
        if(angles.x > 45 && angles.x < 180)
        {
            weaponPivot.transform.localRotation = Quaternion.Euler(45, 0, 0);
        }

        if (fireAction.IsPressed())
        {
            BroadcastMessage("FireWeapon");
        }
        if (jumpAction.WasPressedThisFrame())
        {
            rBody.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if (Keyboard.current.cKey.wasPressedThisFrame)//Camera Controls
        {
            inFirstPerson = !inFirstPerson;
            if (inFirstPerson)
            {
                mainCam.transform.position = firstPerson.transform.position;
            }
            else
            {
                mainCam.transform.position = thirdPerson.transform.position;
            }
        }
    }
    void FixedUpdate()
    {
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up, rotateValue.x * rotatingSpeed * Time.fixedDeltaTime);

        weaponPivot.transform.Rotate(Vector3.right, -rotateValue.y * rotatingSpeed * Time.fixedDeltaTime);

        angles = weaponPivot.transform.localEulerAngles;

        if (angles.x < 300 && angles.x > 180)
        {
            weaponPivot.transform.localRotation = Quaternion.Euler(300, 0, 0);
        }
        if (angles.x > 45 && angles.x < 180)
        {
            weaponPivot.transform.localRotation = Quaternion.Euler(45, 0, 0);
        }

    }
    
    public void MoveCamToSide(bool inTrigger)
    {
        if (inTrigger)
        {
            
        }
        else
        {
            if (inFirstPerson)
            {
                
            }
            else
            {
                
            }
        }
    }

    void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
        fireAction.Enable();
        jumpAction.Enable();
    }
    void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
        fireAction.Disable();
        jumpAction.Disable();
    }

    
}
