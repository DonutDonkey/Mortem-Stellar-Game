using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    #region Variables -> Serialized Private

    [SerializeField] private Transform   playerBody         = null;

    [SerializeField] private string      mouseXInputName    = null;
    [SerializeField] private string      mouseYInputName    = null;

    [SerializeField] private float       mouseSensitivity   = 2.0f;

    [SerializeField] private static float       maxVerticalAngle   = 1.0f;

    #endregion

    #region Variables -> Private

    private new static Transform   transform    = null;

    private float                  mouseX       = 0.0f;
    private float                  mouseY       = 0.0f;
    private float                  xAxisClamp   = 0.0f;

    #endregion

    #region Methods -> UnityCallbacks

    private void Awake() {
        LockCursor();
        xAxisClamp = 0.0f;
        transform = GetComponent<Transform>();
    }


    private void Update() {
        CameraRotation();
        ResetHorizontalRotation();
    }

    #endregion

    #region Methods -> Private

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation() {
        mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity;
        mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity;

        xAxisClamp += mouseY;

        ClampRotation();

        Rotate();
    }

    private void ClampRotation() {
        if (xAxisClamp > 90.0f) {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f) {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }
    }

    private void ClampXAxisRotationToValue(float value) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    private void Rotate() {
        transform.Rotate(Vector3.left * mouseY);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ResetHorizontalRotation() {
        if(transform.eulerAngles.z != 0 && Input.GetAxis("Horizontal") == 0) {
            float zDifference = 0 - transform.eulerAngles.z;
            transform.Rotate(0, 0, zDifference);
        }
    }

    private static void HorizontalMovementTiltRotation(float value) {
        transform.Rotate(0, 0, -value, Space.Self);
    }
    #endregion

    #region Methods -> Public

    public static void CameraKickBack(float time, float shakeAmount)
    {
        Vector3 originalPos = transform.localPosition;
        float shakeDuration = time;
    }

    private static IEnumerator Shaking(float shakeAmount, Vector3 originalPos, float shakeDuration)
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * 0.1f;

        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalPos;

        }

        yield return new WaitForSeconds(0.1f);
    }

    public static void CameraHorizontalMovementTilt(float value) {
        if (transform.eulerAngles.z < maxVerticalAngle) {
            HorizontalMovementTiltRotation(value);
        } else if(360 - maxVerticalAngle < transform.eulerAngles.z) {
            HorizontalMovementTiltRotation(value);
        }
    }

    #endregion
}
