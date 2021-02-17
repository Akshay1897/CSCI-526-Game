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

    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    float lookX = 0;
    float lookY = 0;

    public CinemachineFreeLook vCam;

    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        leftjoystick = GetComponent<FixedJoystick>();
        CinemachineCore.GetInputAxis = GetAxisCustom;

        isWalkingHash = Animator.StringToHash("iswalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
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
        bool isWalking = PlayerAnimator.GetBool(isWalkingHash);
        bool isRunning = PlayerAnimator.GetBool(isRunningHash);
        bool isJumping = PlayerAnimator.GetBool(isJumpingHash);

        bool jumpButtonPressed = Input.GetKey("q");

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
        if (jumpButtonPressed)
            PlayerAnimator.SetBool(isJumpingHash, true);
        else
            PlayerAnimator.SetBool(isJumpingHash, false);

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f && direction.magnitude < 0.5f)  // Walking Mode
        {
            PlayerAnimator.SetBool(isWalkingHash, true);
            PlayerAnimator.SetBool(isRunningHash, false);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else if(direction.magnitude >= 0.5f)    // Running Mode
        {
            PlayerAnimator.SetBool(isRunningHash, true);
            PlayerAnimator.SetBool(isWalkingHash, false);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else if(direction.magnitude == 0f)  // IDLE Mode
        {
            PlayerAnimator.SetBool(isWalkingHash, false);
            PlayerAnimator.SetBool(isRunningHash, false);
        }

    }
}
