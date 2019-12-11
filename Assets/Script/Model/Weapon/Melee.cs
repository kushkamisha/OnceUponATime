public class Melee : IWeapon
{

    public float ViewingRadius {
        get => 0f;
        set => throw new System.Exception("There impossible to change this value"); 
    }
    public float Speed {
        get => 0f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float Defence
    {
        get => 0f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float force
    {
        get => 0f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float AttackSpeed
    {
        get => 0f;
        set => throw new System.Exception("There impossible to change this value");
    }
}
