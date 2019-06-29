using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    #region Variables -> Serialized Private

    [SerializeField] private Transform   playerBody         = null;

    [SerializeField] private string      mouseXInputName    = null;
    [SerializeField] private string      mouseYInputName    = null;

    [SerializeField] private float       mouseSensitivity   = 2.0f;

    #endregion

    #region Variables -> Private

    private float                 mouseX                = 0.0f;
    private float                 mouseY                = 0.0f;
    private float                 xAxisClamp            = 0.0f;

    #endregion

    #region Methods -> UnityCallbacks

    private void Awake() {
        LockCursor();
        xAxisClamp = 0.0f;
    }


    private void Update() {
        CameraRotation();
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

    #endregion
}
