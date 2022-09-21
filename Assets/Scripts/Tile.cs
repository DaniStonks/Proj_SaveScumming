using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private List<GameObject> borders = new List<GameObject>();
    [SerializeField] private Material selectedColors;
    [SerializeField] private Material idleColors;
    private bool isSelected = false;

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

    public void isTileSelected(bool selected)
    {
        isSelected = selected;
    }
}
