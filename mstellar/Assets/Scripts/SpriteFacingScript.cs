using UnityEngine;

public class SpriteFacingScript : MonoBehaviour
{
    public Transform   target   = null;

    private Vector3    point   = Vector3.zero;

    void Update() {
        if (target != null) {
            transform.LookAt(GetLookAtVector());
        }
    }

    private Vector3 GetLookAtVector() {
        GetLookAtPosition();
        return point;
    }

    private void GetLookAtPosition() {
        point = target.position;
        point.y = transform.position.y;
    }
}

