using UnityEngine;

[CreateAssetMenu(fileName = "New Actor", menuName = "Game Specific Objects/Actor")]
public class DActor : ScriptableObject
{
    public DFloatValue health;

    public DFloatValue maxHealth;
}
