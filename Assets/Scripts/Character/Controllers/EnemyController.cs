using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    private Animator a;

    void Start(){
        a = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.Health == 0) Die();
        if(Input.GetKey(KeyCode.W))
        {
            //isSelected = true;
            //StartCoroutine(Move(Vector3.forward*10)); mover personagem(para o futuro)
        }
    }

    public void Attack(Character playerCharacter)
    {
        //a.SetTrigger("Aim");
        enemy.TakeDamage(enemy.Damage);
    }

    public void Die(){
        a.SetTrigger("Die");
    }
}
