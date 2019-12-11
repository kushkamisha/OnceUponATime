public class Bludgeon : IWeapon
{

    public float ViewingRadius
    {
        get => -5f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float Speed
    {
        get => -1f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float Defence
    {
        get => 2f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float force
    {
        get => 5f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float AttackSpeed
    {
        get => -3f;
        set => throw new System.Exception("There impossible to change this value");
    }
}
