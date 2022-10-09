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

    //ver no que da fazer desta maneira
    [SerializeField] private GameObject tileContent;

    // Start is called before the first frame update
    void Start()
    {
        Transform border = this.gameObject.transform.GetChild(1);
        foreach (Transform b in border)
        {
            borders.Add(b.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        isHovered = true;
        if (!isSelected)
        {
            foreach (GameObject b in borders)
            {
                b.GetComponent<MeshRenderer>().material = hoverColors;
            }
        }
    }

    /*
    if (isSelected)
        {
            foreach (GameObject b in borders)
            {
                b.GetComponent<MeshRenderer>().material = selectedColors;
            }
        }
        else
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
                {
                    foreach (GameObject b in borders)
                    {
                        b.GetComponent<MeshRenderer>().material = idleColors;
                    }
                }
            }
        }
        */

    void OnMouseExit()
    {
        if (!isSelected)
        {
            foreach (GameObject b in borders)
            {
                b.GetComponent<MeshRenderer>().material = idleColors;
            }
        }
    }

    public void e()
    {
        foreach (GameObject b in borders)
        {
            b.GetComponent<MeshRenderer>().material = selectedColors;
        }
    }

    void OnMouseUpAsButton()
    {
        if (tileContent != null && tileContent.tag.Equals("PlayerChar"))
        {
            isSelected = true;
            foreach (GameObject b in borders)
            {
                b.GetComponent<MeshRenderer>().material = selectedColors;
            }

            // TODO - Mostrar UI

            /* Coisas teste
            Coordenates t = Grid.indexOf(this);
            Tile te = Grid.GameGrid[t.X, t.Y];
            List<Tile> tiless = Grid.adjacentTilesWithinDistance(this, 4);
            foreach(Tile ti in tiless){
                ti.e();
            }
            */
        }
    }
}
