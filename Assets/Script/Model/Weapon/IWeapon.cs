interface IWeapon
{
    /* Radius of viewing */
    float viewingRadius { get; }

    /* Creature move speed */
    float speed { get; }

    /* Creature defence coefficient */
    float defence { get; }

    /* Creature attack force coefficient */
    float force { get; }

    /* Creature speed of striking */
    float attackSpeed { get; }

}
