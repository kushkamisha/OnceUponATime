public class Sword : IWeapon
{

    public float ViewingRadius
    {
        get => -1f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float Speed
    {
        get => -1f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float Defence
    {
        get => 3f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float force
    {
        get => 3f;
        set => throw new System.Exception("There impossible to change this value");
    }
    public float AttackSpeed
    {
        get => -1f;
        set => throw new System.Exception("There impossible to change this value");
    }
}