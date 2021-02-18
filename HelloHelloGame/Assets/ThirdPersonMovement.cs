using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;

    public FixedJoystick leftjoystick;
    public FloatingJoystick rightjoystick;
    public Animator PlayerAnimator;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    float lookX = 0;
    float lookY = 0;

    bool jumpButtonPressed;

    public CinemachineFreeLook vCam;

    Vector3 direction;

    void Start()
    {
        //PlayerAnimator = GetComponent<Animator>();
        //leftjoystick = GetComponent<FixedJoystick>();
        CinemachineCore.GetInputAxis = GetAxisCustom;       
    }

    public float GetAxisCustom(string axisName)
    {
        if(axisName == "Mouse X")
        {
            return lookX;
        }
        else if (axisName == "Mouse Y")
        {
            return lookY;
        }
        return 0;
    }


    void Update()
    {


        float horizontal;
        float vertical;

        if (Input.touchCount > 0)
        {
            horizontal = leftjoystick.Horizontal;
            vertical = leftjoystick.Vertical;

            lookX = rightjoystick.Horizontal;
            lookY = rightjoystick.Vertical;
        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        // If the Button Designated for Jump is Pressed & Player is not Jumping already


        direction = new Vector3(horizontal, 0f, vertical);



        if (direction.magnitude >= 0.1f)  // Walking Mode
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * direction.magnitude * Time.deltaTime);
        }

        if (jumpButtonPressed)
        {
            PlayerAnimator.SetBool("isJumping", true);
        }
        else
        { 
            PlayerAnimator.SetBool("isJumping", false);
        }
    }

    void setAnimation(float magnitude) 
    {
        if (magnitude >= 0.1f && magnitude <0.9f)
        {
            PlayerAnimator.SetBool("isWalking", true);
            PlayerAnimator.SetBool("isRunning", false);
        }

        else if(magnitude >= 0.7f)
        {
            PlayerAnimator.SetBool("isWalking", true);
            PlayerAnimator.SetBool("isRunning", true);
        }

        else if(magnitude == 0f)  // IDLE Mode
        {
            PlayerAnimator.SetBool("isWalking", false);
            PlayerAnimator.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        setAnimation(direction.magnitude);
    }

    public void Jump()
    {
        jumpButtonPressed = true;
        Invoke("UnJump", 0.1f);
    }

    public void UnJump()
    {
        jumpButtonPressed = false;
    }
}
