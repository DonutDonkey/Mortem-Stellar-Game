using UnityEngine;

[CreateAssetMenu(fileName = "Float Value", menuName = "Game Specific Values/Float Value")]
public class DFloatValue : ScriptableObject
{
    [SerializeField]
    private float value = 0.0f;

    public static implicit operator float(DFloatValue dFloatValue) {
        return dFloatValue.value;
    }
}
