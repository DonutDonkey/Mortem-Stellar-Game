using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables -> Serialized Private

    [SerializeField] private Animator   cameraAnimator        = null;
    [SerializeField] private Animator   armatureAnimator      = null;

    [SerializeField] private float      speedChangeDiameter   = 1.0f;
    [SerializeField] private float      movementSpeed         = 5.0f;
    [SerializeField] private float      jumpForce             = 7.0f;

    #endregion

    #region Variables -> Private

    private CharacterController   characterController   = null;

    private Vector3               moveDirection         = Vector3.zero;

    private float                 maxSpeed              = 5.0f;

    private bool                  speedIsDecreasing     = false;
    private bool                  isJumping             = false;
    
    private static readonly int   IsGrounded            = Animator.StringToHash("isGrounded");
    private static readonly int   Velocity              = Animator.StringToHash("velocity");

    #endregion

    #region Variables -> Public

    public float    gravity               = 20.0f;

    public string   horizontalInputName   = "Horizontal";
    public string   verticalInputName     = "Vertical";
    public string   jumpInputName         = "Jump";
    
    #endregion

    #region Methods -> Unity Callbacks

    void Start() {
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        if (characterController.isGrounded) {
            CheckForMovementIncrease();

            UpdateMovement();

            JumpInput();

        }
        else {
            AirControl();
        }
        ApplyGravity();
        characterController.Move(moveDirection * Time.deltaTime);

        PlayerCamera.CameraHorizontalMovementTilt(Input.GetAxis(horizontalInputName));
        HeadBob();
    }

    private void FixedUpdate() {
        armatureAnimator.SetFloat("speed", characterController.velocity.magnitude);
    }

    #endregion

    #region Methods -> Private

    private void UpdateMovement() {
        moveDirection = new Vector3(Input.GetAxis(horizontalInputName), 0.0f, Input.GetAxis(verticalInputName));
        moveDirection *= movementSpeed;

        UpdateTransform();
    }

    private void JumpInput() {
        if (Input.GetButton(jumpInputName)) {
            isJumping = true;
            Jump();
        }
        else if (!speedIsDecreasing) {
            speedIsDecreasing = true;
            StartCoroutine(DecreaseSpeed());
        }
    }

    private void Jump() {
        moveDirection.y = jumpForce;
    }

    private void AirControl() {
        moveDirection.x = Input.GetAxis(horizontalInputName) * movementSpeed;
        moveDirection.z = Input.GetAxis(verticalInputName) * movementSpeed;
        UpdateTransform();
    }

    private void CheckForMovementIncrease() {
        if (isJumping) {
            isJumping = false;
            IncreaseSpeed();
        }
    }

    private void IncreaseSpeed() {
        if (movementSpeed < maxSpeed) {
            movementSpeed += speedChangeDiameter;
        }
    }

    private IEnumerator DecreaseSpeed() {
        while (4.0f < movementSpeed && speedIsDecreasing) {
            movementSpeed -= speedChangeDiameter;
            yield return new WaitForSeconds(0.1f);
        }
        speedIsDecreasing = false;
    }

    private void UpdateTransform() {
        moveDirection = transform.TransformDirection(moveDirection);
    }

    private void ApplyGravity() {
        moveDirection.y -= gravity * Time.deltaTime;
    }

    private void HeadBob() {

    }

    #endregion

    #region Methods -> Public

    public void SetMaxSpeed(float maxSpeed) {
        this.maxSpeed = maxSpeed;
    }

    #endregion
}
