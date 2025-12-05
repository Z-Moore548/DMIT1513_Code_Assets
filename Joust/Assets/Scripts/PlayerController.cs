using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ostrich, spawn;
    [SerializeField] float speed, jumpForce, dashForce;
    [SerializeField] int gamepadID, playerIndex;

    GameManager gameManager;
    Rigidbody rBody;

    [SerializeField]float left, right, zValue;
    bool flap, dash, dashCool, facingRight, invincible, falling;
    
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
            if (Gamepad.all[playerIndex].yButton.wasPressedThisFrame)
            {
                falling = true;
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
            //rBody.constraints = RigidbodyConstraints.FreezePositionY;
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
        if (falling)
        {
            rBody.AddForce(Vector3.down * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
            falling = false;
        }
    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0,transform.rotation.y,0);
    }
    public int GetGamepadID()
    {
        // return the gamepad ID that the object is currently linked to.
        return gamepadID;
    }

    public void SetGamepadID(int id)
    {
        // set the gamepad ID that the object should be linked to.
        gamepadID = id;
    }
    public void Score()
    {
        gameManager.UpdateScores(playerIndex);
    }
    
    public void Killed()
    {
        if (invincible)
        {
            
        }
        else
        {
            transform.position = new Vector3(10,0,0);
            invincible = true;
            StartCoroutine(Respawn());
        }
        
    }
    


    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(.3f);
        rBody.constraints = RigidbodyConstraints.FreezeRotation;
        //rBody.linearVelocity = new Vector3(0, rBody.linearVelocity.y, 0);
        yield return new WaitForSeconds(.3f);
        dashCool = true;
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        transform.position = spawn.transform.position;
        invincible = true;
        yield return new WaitForSeconds(2);
        invincible = false;
    }
}
