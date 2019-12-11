interface IWeapon
{
    /* Radius of viewing */
    float ViewingRadius { get; set; }

    /* Creature move speed */
    float Speed { get; set; }

    /* Creature defence coefficient */
    float Defence { get; set; }

    /* Creature attack force coefficient */
    float force { get; set; }

    /* Creature speed of striking */
    float AttackSpeed { get; set; }

}
