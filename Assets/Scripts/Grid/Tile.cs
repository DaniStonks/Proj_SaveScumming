using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private List<Material> borderMaterials = new List<Material>();
    private Material tileMaterial;
    public bool Selected { get; set; }
    public bool Hovered { get; set; }
    [SerializeField] private GameObject content; //conteudo da tile, quer seja personagens ou obstaculos

    void Start()
    {
        Hovered = false;
        Selected = false;
        Transform border = this.gameObject.transform.GetChild(1);
        foreach (Transform b in border) borderMaterials.Add(b.GetComponent<MeshRenderer>().material);
    }

    void Update()
    {
        updateTileColor();
    }

    void OnMouseOver()
    {
        Hovered = true;
    }

    void OnMouseExit()
    {
        Hovered = false;
    }

    void OnMouseUpAsButton()
    {
        if (content != null && content.tag.Equals("PlayerChar"))
        {
            Selected = true;
            Grid.selectedCharacter = content.GetComponent<CharacterController>();
            GameObject.Find("Canvas").transform.Find("UIPanel").gameObject.SetActive(true);
        }
        if (PlayerUIController.IsAttacking)
        {
            print(content.GetComponent<EnemyController>().enemy.Health);
            PlayerUIController.ConfirmAttack(Grid.selectedCharacter,content.GetComponent<EnemyController>());
            print("Apos fight" + content.GetComponent<EnemyController>().enemy.Health);
        }
    }

    private void updateTileColor()
    {
        if (Hovered)
        {
            foreach (Material m in borderMaterials) m.color = new Color(1, 0.78f, 0); //cor amarela
        }
        else
        {
            if (Selected)
            {
                foreach (Material m in borderMaterials) m.color = new Color(1, 0.34f, 0); //cor laranja
            }
            else
            {
                foreach (Material m in borderMaterials) m.color = new Color(1,1,1); //cor branca
            }
        }
    }

    public GameObject getContent(){
        return content;
    }

    public void setContent(GameObject content){
        this.content = content;
    }
}
