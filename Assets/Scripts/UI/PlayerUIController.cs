using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public static bool IsAttacking{ get; set; }
    // Start is called before the first frame update
    void Start()
    {
        IsAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAttacking){
            //Mostrar algo
        }
    }

    public void StartAttack(){
        IsAttacking = true;
        print("yep");
    }

    public static void ConfirmAttack(CharacterController attacker, EnemyController enemy){
        if(IsAttacking) attacker.Attack(enemy.enemy);
        IsAttacking = false;
    }
}
