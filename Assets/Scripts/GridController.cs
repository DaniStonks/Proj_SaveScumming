using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private GameObject selectedTile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(selectedTile != null){
            selectedTile.GetComponent<Tile>().isTileSelected(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(selectedTile != null){
                    selectedTile.GetComponent<Tile>().isTileSelected(false);
                }
                selectedTile = hit.transform.parent.gameObject;
            }
        }
    }
}
