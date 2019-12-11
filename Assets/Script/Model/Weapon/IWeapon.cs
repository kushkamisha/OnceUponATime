interface IWeapon
{
    /* Radius of viewing */
    float ViewingRadius { get; }

    /* Creature move speed */
    float Speed { get; }

    /* Creature defence coefficient */
    float Defence { get; }

    /* Creature attack force coefficient */
    float Force { get; }

    /* Creature speed of striking */
    float AttackSpeed { get; }

}
