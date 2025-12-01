using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ostrich;
    [SerializeField] float speed, jumpForce, dashForce;
    [SerializeField] int gamepadID, playerIndex;

    Rigidbody rBody;

    [SerializeField]float left, right, zValue;
    bool flap, dash, dashCool, facingRight;
    
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        flap = false;
        dash = false;
        facingRight = false;
        dashCool = true;
    }

    void Update()
    {
        if (gamepadID != -1)
        {
            #region Controller Input for Gamepad
            
            left = Gamepad.all[playerIndex].leftStick.right.value;
            right = Gamepad.all[playerIndex].leftStick.left.value;
            zValue = right - left;
            if(zValue < 0)
            {
                ostrich.transform.rotation = Quaternion.Euler(0,180,0);
                facingRight = true;
            }
            if(zValue > 0)
            {
                ostrich.transform.rotation = Quaternion.Euler(0,0,0);
                 facingRight = false;
            }

            if (Gamepad.all[playerIndex].aButton.wasPressedThisFrame)
            {
                flap = true;
            }
            if (Gamepad.all[playerIndex].xButton.wasPressedThisFrame & dashCool)
            {
                dash = true;
                dashCool = false;
            }
            
            #endregion
        }
    }
    void FixedUpdate()
    {
        transform.Translate(0, 0, zValue * speed * Time.fixedDeltaTime);

        if (flap)
        {
            rBody.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
            flap = false;
        }
        if (dash)
        {
            rBody.constraints = RigidbodyConstraints.FreezePositionY;
            if (!facingRight)
            {
                rBody.AddForce(Vector3.forward * dashForce * Time.fixedDeltaTime, ForceMode.Impulse);
            }
            else
            {
                rBody.AddForce(Vector3.back * dashForce * Time.fixedDeltaTime, ForceMode.Impulse);
            }
            StartCoroutine(DashCooldown());
            dash = false;
        }
    }





    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(.3f);
        rBody.constraints = RigidbodyConstraints.FreezeRotation;
        rBody.linearVelocity = new Vector3(0, rBody.linearVelocity.y, 0);
        yield return new WaitForSeconds(.5f);
        dashCool = true;
    }

}
