using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int moveRadius;
    [SerializeField] private int damageBonus;
    [SerializeField] private int accuracyBonus;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public int Damage
    {
        get { return damage; }
    }
    public int MoveRadius
    {
        get { return moveRadius; }
    }
    public int DamageBonus
    {
        get { return damageBonus; }
    }
    public int AccuracyBonus
    {
        get { return accuracyBonus; }
    }
}
