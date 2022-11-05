using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Character character;
    private Animator a;
    private float tileMoveTime = 0.2f;
    private bool isMoving;
    public bool isSelected;

    void Start(){
        a = gameObject.GetComponent<Animator>();

        //Meter atributo string de arma talvez para mudar isto tudo simplesmente para a.setTrigger("Start" + character.weapon) para ser
        //mais reutilizavel, senao caso sejam adicionadas mais personagens apenas são metidos mais if's
        //a.SetTrigger("StartPistol");
        a.SetTrigger("StartRifle"); 
    }

    private IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 origPos, targPos;
        float elapsedTime = 0;

        origPos = transform.position;
        targPos = origPos + direction;

        while(elapsedTime < tileMoveTime)
        {
            transform.position = Vector3.Lerp(origPos, targPos, (elapsedTime/tileMoveTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targPos;
        isMoving = false;
    }

    public void Attack(Enemy enemy)
    {
        a.SetTrigger("Aim");
        enemy.TakeDamage(character.Damage);
    }

    public void TakeDamage(int amount)
    {
        character.Health -= amount;

        if(character.Health < 0) Die();
    }

    public void Die(){
        Destroy(this, 3f);
    }
}
