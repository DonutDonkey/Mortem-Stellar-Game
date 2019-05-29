public class Player : Actor
{
    private PlayerController controller;
    private PlayerWeapons    weapons;

    private float            armor;
    private float            maxArmor;

    private int              level;


    public override void Start() {
        base.Start();

        maxArmor = ((DPlayer)actorData).maxArmor;
        armor = maxArmor;

        controller = GetComponent<PlayerController>();
        controller.SetMaxSpeed(((DPlayer)actorData).maxSpeed);

        weapons = GetComponent<PlayerWeapons>();
    }

    void Update() {

    }
}

