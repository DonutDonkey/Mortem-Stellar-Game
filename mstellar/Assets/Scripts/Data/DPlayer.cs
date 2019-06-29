using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Game Specific Objects/Player")]
public class DPlayer : DActor
{
    public DFloatValue armor;

    public DFloatValue maxArmor;

    public DFloatValue maxSpeed;
}
