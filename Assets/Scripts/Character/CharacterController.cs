using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, IDamageable
{
    private int amountTileMoves = 3;
    public int AmountTileMoves{get;}
    private bool isMoving;
    private float tileMoveTime = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && !isMoving){
            StartCoroutine(Move(Vector3.forward*10));
        }
    }

    public void Damage()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator Move(Vector3 direction){
        isMoving = true;
        Vector3 origPos, targPos;
        float elapsedTime = 0;

        origPos = transform.position;
        targPos = origPos + direction;

        while(elapsedTime < tileMoveTime){
            transform.position = Vector3.Lerp(origPos, targPos, (elapsedTime/tileMoveTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targPos;
        isMoving = false;
    }

    public void resetMoves(){
        amountTileMoves = 3;
    }
}
