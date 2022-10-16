using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public int Health{get; set;}
    public int MoveRadius{get; set;}
    public int Damage{get; set;}

    public Character(int health, int moveRadius, int damage){
        Health = health;
        MoveRadius = moveRadius;
        Damage = damage;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if(Health < 0) Die();
    }

    public void Die(){
        throw new System.NotImplementedException();
    }
}
