public class Player : Actor
{
    private float armor;

    private float maxArmor;

    private int level;

    private PlayerController controller;

    public override void Start() {
        base.Start();

        maxArmor = ((DPlayer)actorData).maxArmor;
        armor = maxArmor;

        controller = GetComponent<PlayerController>();
        controller.SetMaxSpeed(((DPlayer)actorData).maxSpeed);
    }

    void Update() {

    }
}

