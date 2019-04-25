using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Clean code this mess
    //Increase speed when jumping
    //Create Scriptable Objects for jump, speed, inputs 

    [SerializeField]
    private string horizontalInputName;

    [SerializeField]
    private string verticalInputName;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private AnimationCurve jumpFallOff;

    [SerializeField]
    private float jumpMultiplier;

    [SerializeField]
    private string jumpKey;

    private bool isJumping;

    private CharacterController characterController;
    private Animator characterAnimator;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();
    }

    private void Update() {
        Movement();
    }

    private void Movement() {
        float horizontalInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float verticalInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        characterController.SimpleMove(forwardMovement + rightMovement);

        characterAnimator.SetFloat("speed", (float)characterController.velocity.magnitude);

        JumpInput();
    }

    private void JumpInput() {
        if(Input.GetButton(jumpKey) && !isJumping) {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
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

        //Place for either movement increase based on player experience or stance reset

        characterController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
