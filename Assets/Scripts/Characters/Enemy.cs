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

        if(Health <= 0) Die();
        print("yeeeeeep");
    }

    public void Die(){
        Destroy(this.gameObject, 3.3f);
    }
}
