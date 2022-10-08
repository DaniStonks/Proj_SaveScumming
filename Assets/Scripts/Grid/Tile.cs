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
        if (!isSelected)
        {
            foreach (GameObject b in borders)
            {
                b.GetComponent<MeshRenderer>().material = hoverColors;
            }
        }
    }

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
            print("F");
            foreach (GameObject b in borders)
            {
                b.GetComponent<MeshRenderer>().material = selectedColors;
            }
            // TODO - Mostrar UI
            Collider[] hit = Physics.OverlapSphere(gameObject.transform.position, 5f * tileContent.GetComponent<PlayerCharacter>().amountTileMoves);
            foreach (Collider enemy in hit)
            {
                if (enemy.tag.Equals("Tile"))
                {
                    enemy.GetComponent<Tile>().e();
                }
            }
        }
    }
}
