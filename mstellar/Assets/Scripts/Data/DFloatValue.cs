using UnityEngine;

[CreateAssetMenu(fileName = "Float Value", menuName = "Game Specific Values/Float Value")]
public class DFloatValue : ScriptableObject
{
    [SerializeField] private float   value   = 0.0f;

    public static implicit operator float(DFloatValue dFloatValue) {
        return dFloatValue.value;
    }

    public static DFloatValue operator--(DFloatValue dFloatValue) {
        dFloatValue.value--;
        return dFloatValue;
    }

    public static DFloatValue operator++(DFloatValue dFloatValue) {
        dFloatValue.value++;
        return dFloatValue;
    }

    public static DFloatValue operator +(DFloatValue dFloatValue, float value) {
        dFloatValue.value += value;
        return dFloatValue;
    }

    public static DFloatValue operator -(DFloatValue dFloatValue, float value) {
        dFloatValue.value -= value;
        return dFloatValue;
    }

}
