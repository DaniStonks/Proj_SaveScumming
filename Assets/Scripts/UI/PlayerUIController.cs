using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private GameObject AttackPanel;
    public CharacterController selectedCharacter { get; set; }
    private bool IsAttacking { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        IsAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAttacking){
            SelectEnemy();
            //Mostrar algo nos inimigos.
        }
    }

    public void toggleAttack()
    {
        IsAttacking = IsAttacking ? false : true;
    }

    public void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 300.0f) && hit.transform.tag.Equals("Tile"))
            {
                Tile t = hit.transform.gameObject.GetComponent<Tile>();
                if (t != null && t.getContent().tag.Equals("EnemyChar"))
                {
                    AttackPanel.SetActive(true);
                    gameObject.SetActive(false);
                    AttackController attkC = AttackPanel.GetComponent<AttackController>();
                    attkC.selectedCharacter = selectedCharacter;
                    attkC.selectedEnemy = t.getContent().GetComponent<EnemyController>();
                }
            }
        }
    }
}
