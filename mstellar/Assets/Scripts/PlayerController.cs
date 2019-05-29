using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Clean code this mess
    //Increase speed when jumping
    //Create Scriptable Objects for jump, speed, inputs 

    #region Variables -> Serialized Private

    [SerializeField] private AnimationCurve   jumpFallOff;

    [SerializeField] private string           horizontalInputName     = null;
    [SerializeField] private string           verticalInputName       = null;

    [SerializeField] private string           jumpKey                 = null;

    [SerializeField] private float            movementSpeed           = 5.0f;
    [SerializeField] private float            movementSpeedDiameter   = 1.0f;

    [SerializeField] private float            jumpMultiplier          = 5.0f;

    #endregion

    #region Variables -> Private

    private CharacterController   characterController   = null;
    private Animator              characterAnimator     = null;

    private bool                  isJumping             = false;
    private bool                  speedIsDecreasing     = false;

    private float                 maxSpeed              = 5.0f;

    #endregion

    #region Methods -> Public

    public void SetMaxSpeed(float maxSpeed) {
        this.maxSpeed = maxSpeed;
    }
    
    #endregion

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();
    }

    private void Update() {
        characterAnimator.SetFloat("speed", characterController.velocity.magnitude);
    }

    private void FixedUpdate() {
        Movement();

        JumpInput();
    }

    private void Movement() {
        float horizontalInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float verticalInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        characterController.SimpleMove(forwardMovement + rightMovement);
    }

    private void JumpInput() {
        if(Input.GetButton(jumpKey) && !isJumping) {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }

        if(!Input.GetButton(jumpKey) && characterController.isGrounded && !speedIsDecreasing && !isJumping) {
            speedIsDecreasing = true;
            StartCoroutine(DecreaseSpeed());
        }
    }

    private IEnumerator DecreaseSpeed() {
        while (5.0f < movementSpeed && speedIsDecreasing) {
            movementSpeed -= movementSpeedDiameter;
            yield return new WaitForSeconds(0.1f);
        }
        speedIsDecreasing = false;
    }

    private IEnumerator JumpEvent() {
        characterController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do 
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            characterController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!characterController.isGrounded && characterController.collisionFlags != CollisionFlags.Above);

        IncreaseSpeed();

        characterController.slopeLimit = 45.0f;
        isJumping = false;
    }

    private void IncreaseSpeed() {
        if(movementSpeed < maxSpeed) {
            movementSpeed += movementSpeedDiameter;
        }
    }
}
