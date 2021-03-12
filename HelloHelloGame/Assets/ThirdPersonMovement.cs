using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public FixedJoystick leftjoystick;
    public FloatingJoystick rightjoystick;
    public Animator PlayerAnimator;

    public GameObject ball;
    public float ballDistance;
    private bool holdingBall = true;
    public float ballThrowingForce;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    float lookX = 0;
    float lookY = 0;

    bool jumpButtonPressed;

    public CinemachineFreeLook vCam;

    bool lockMovement = false;

    float movementFactor;

    public float timePeriodForce;
    public float timeSinceStart;

    public float currentForce;

    public Slider BallThrowSliderRef;

    Vector3 direction;

    void Start()
    {
        //PlayerAnimator = GetComponent<Animator>();
        //leftjoystick = GetComponent<FixedJoystick>();
        CinemachineCore.GetInputAxis = GetAxisCustom;
        ball.GetComponent<Rigidbody>().useGravity = false;
        controller = GetComponent<CharacterController>();
        Debug.Log(controller);

        timeSinceStart = (3 * timePeriodForce) / 4;
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

        //if (Input.touchCount > 0)
        //{
            horizontal = leftjoystick.Horizontal;
            vertical = leftjoystick.Vertical;

            lookX = rightjoystick.Horizontal;
            lookY = rightjoystick.Vertical;
        //}
        //else
        //{
            //horizontal = Input.GetAxisRaw("Horizontal");
            //vertical = Input.GetAxisRaw("Vertical");
        //}


        direction = new Vector3(horizontal, 0f, vertical);

        if (!lockMovement)
        {
            if (direction.magnitude >= 0.1f)  // Walking Mode
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move (moveDir.normalized * speed * direction.magnitude * Time.deltaTime);
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

        if (lockMovement)
        {
            ThrowBallPower();
        }
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

    public void throwball()
    {
        if (holdingBall)
        {
            GameObject obj = Instantiate(ball, transform);

            obj.transform.position = cam.transform.position + cam.transform.forward * ballDistance;
           
            //holdingBall = false;
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Rigidbody>().AddForce(cam.transform.forward * currentForce); 
        }
    }

    public void lockMovementInput()
    {
        lockMovement = true;
    }

    public void unlockMovementInput()
    {
        lockMovement = false;
    }

    public void lookMovementInput()
    {

    }

    public void ThrowBallPower()
    {
        currentForce = 2 * ballThrowingForce + ballThrowingForce * Mathf.Sin(Time.time/2);
        //timeSinceStart += Time.deltaTime;
        BallThrowSliderRef.value = currentForce;
        Debug.Log(currentForce);

    }
}
