using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private List<GameObject> borders = new List<GameObject>();
    [SerializeField] private Material selectedColors;
    [SerializeField] private Material hoverColors;
    [SerializeField] private Material idleColors;
    private bool isSelected { get; set; }
    private bool isHovered { get; set; }
    [SerializeField] private GameObject tileContent; //conteudo da tile, quer seja personagens ou obstaculos

    void Start()
    {
        //Find do painel aqui
        Transform border = this.gameObject.transform.GetChild(1);
        foreach (Transform b in border)
        {
            borders.Add(b.gameObject);
        }
    }

    void Update()
    {
        updateTileColor();
    }

    void OnMouseOver()
    {
        isHovered = true;
    }

    void OnMouseExit()
    {
        isHovered = false;
    }

    void OnMouseUpAsButton()
    {
        if (tileContent != null && tileContent.tag.Equals("PlayerChar"))
        {
            isSelected = true;

            GameObject.Find("Canvas").transform.Find("UIPanel").gameObject.SetActive(true);
        }
    }

    public void TilesToMove()
    {
        List<Tile> adjacentTiles = Grid.adjacentTilesWithinDistance(this, tileContent.GetComponent<CharacterController>().AmountTileMoves);
        foreach (Tile tile in adjacentTiles)
        {
            tile.isSelected = true;
        }
    }

    private void updateTileColor()
    {
        if (isHovered)
        {
            foreach (GameObject b in borders)
            {
                b.GetComponent<MeshRenderer>().material = hoverColors;
            }
        }
        else
        {
            if (isSelected)
            {
                foreach (GameObject b in borders)
                {
                    b.GetComponent<MeshRenderer>().material = selectedColors;
                }
            }
            else
            {
                foreach (GameObject b in borders)
                {
                    b.GetComponent<MeshRenderer>().material = idleColors;
                }
            }
        }
    }
}
