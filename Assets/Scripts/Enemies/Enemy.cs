using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public int Health{get; set;}
    public int Damage{get; set;}

    public Enemy(int health, int damage){
        Health = health;
        Damage = damage;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }
}
