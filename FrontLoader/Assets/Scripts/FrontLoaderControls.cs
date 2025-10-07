using UnityEngine;
using UnityEngine.InputSystem;

public class FrontLoaderControls : MonoBehaviour
{
    [SerializeField] float forceMove, forceTurn, armSpeed, bucketSpeed;
    [SerializeField] GameObject arms, bucket;
    [SerializeField] InputAction moveAction;
    private Vector2 moveValues;
    private Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        moveAction.Enable();
    }

    void Update()
    {
       moveValues = moveAction.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {   //movement
        rb.AddRelativeForce(Vector3.forward * moveValues.y * forceMove * Time.fixedDeltaTime);
        rb.AddRelativeTorque(Vector3.up * moveValues.x * forceTurn * Time.fixedDeltaTime);

        //Arms rotation
        if (Keyboard.current.uKey.isPressed)// need to make clamps for this and the bucket
        {
            arms.transform.Rotate(Vector3.left * armSpeed * Time.fixedDeltaTime);
        }
        if (Keyboard.current.jKey.isPressed)
        {
            arms.transform.Rotate(Vector3.right * armSpeed * Time.fixedDeltaTime);
        }

        //Bucket Rotation
        if (Keyboard.current.iKey.isPressed)
        {
            bucket.transform.Rotate(Vector3.left * bucketSpeed * Time.fixedDeltaTime);
        }
        if (Keyboard.current.kKey.isPressed)
        {
            bucket.transform.Rotate(Vector3.right * bucketSpeed * Time.fixedDeltaTime);
        }
    }
}
