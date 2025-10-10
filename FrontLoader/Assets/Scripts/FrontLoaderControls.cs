using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrontLoaderControls : MonoBehaviour
{
    [SerializeField] float forceMove, forceTurn, armSpeed, bucketSpeed;
    [SerializeField] GameObject arms, bucket;
    [SerializeField] InputAction moveAction;
    private Vector2 moveValues;
    private Rigidbody rb;
    [SerializeField] private Vector3 angles, bucketAngle;
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

        angles = arms.transform.rotation.eulerAngles;
        bucketAngle = bucket.transform.rotation.eulerAngles;
        //Arms rotation
        if (Keyboard.current.uKey.isPressed)// need to make clamps for this and the bucket
        {
            if (angles.x < 300 && angles.x > 180)
            {
                arms.transform.localRotation = Quaternion.Euler(-60, 0, 0);
            }
            arms.transform.Rotate(Vector3.left * armSpeed * Time.fixedDeltaTime);
        }
        if (Keyboard.current.jKey.isPressed)
        {
            if (angles.x > 25 && angles.x < 180)
            {
                arms.transform.localRotation = Quaternion.Euler(35, 0, 0);
            }
            arms.transform.Rotate(Vector3.right * armSpeed * Time.fixedDeltaTime);
        }

        //Bucket Rotation
        if (Keyboard.current.iKey.isPressed)
        {
            if(bucketAngle.x < 320 && bucketAngle.x > 180)
            {
                bucket.transform.rotation = Quaternion.Euler(-40, 0, 0);
            }
            bucket.transform.Rotate(Vector3.left * bucketSpeed * Time.fixedDeltaTime);
        }
        if (Keyboard.current.kKey.isPressed)
        {
            if(bucketAngle.x > 50 && bucketAngle.x < 180)
            {
                bucket.transform.rotation = Quaternion.Euler(50, 0, 0);
            }
            bucket.transform.Rotate(Vector3.right * bucketSpeed * Time.fixedDeltaTime);
        }
    }
}
