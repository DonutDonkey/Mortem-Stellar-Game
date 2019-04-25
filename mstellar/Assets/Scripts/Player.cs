public class Player : Actor
{
    private float armor;

    private float maxArmor;

    private int level;

    public override void Start() {
        base.Start();

        maxArmor = ((DPlayer)actorData).maxArmor;
        armor = maxArmor;
    }

    void Update() {

    }
}

