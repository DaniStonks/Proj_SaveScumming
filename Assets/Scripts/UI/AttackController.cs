using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public CharacterController selectedCharacter { get; set;}
    public EnemyController selectedEnemy { get; set;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CancelAttack(){

    }

    public void ConfirmAttack(){
        selectedCharacter.Attack(selectedEnemy.enemy);
        gameObject.SetActive(false);
    }
}
