using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Character character;
    private Animator a;
    private bool isMoving;
    private float tileMoveTime = 0.2f;
    public bool isSelected;

    void Start(){
        a = gameObject.GetComponent<Animator>();

        //Meter atributo string de arma talvez para mudar isto tudo simplesmente para a.setTrigger("Start" + character.weapon) para ser
        //mais reutilizavel, senao caso sejam adicionadas mais personagens apenas são metidos mais if's
        if(character is AccuracyCharacter) a.SetTrigger("StartPistol");
        else a.SetTrigger("StartRifle"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            isSelected = true;
            //StartCoroutine(Move(Vector3.forward*10)); mover personagem(para o futuro)
        }
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
}
