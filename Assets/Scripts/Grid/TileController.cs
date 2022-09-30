using UnityEngine;

public class TileController : MonoBehaviour
{
    private GameObject hoveredTile;
    private GameObject selectedTile;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag.Equals("Tile"))
            {
                //Se o cursor está numa tile e nao esta selecionada, muda a cor da tile para a de Hover.
                if (hoveredTile != null)
                {
                    hoveredTile.GetComponent<Tile>().setTileHovered(false);
                    hoveredTile = hit.collider.gameObject;
                    hoveredTile.GetComponent<Tile>().setTileHovered(true);
                }
                else
                {
                    hoveredTile = hit.collider.gameObject;
                    hoveredTile.GetComponent<Tile>().setTileHovered(true);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if(selectedTile != null){ //Se uma tile já está selecionada, deseleciona-a, e a que o user deu hover passa a ser a selecionada
                        selectedTile.GetComponent<Tile>().setTileSelected(false);
                        selectedTile = hoveredTile;
                        selectedTile.GetComponent<Tile>().setTileSelected(true);
                    } else {
                        selectedTile = hoveredTile;
                        selectedTile.GetComponent<Tile>().setTileSelected(true);
                    }
                }
            }
        }
    }

    public GameObject getSelectedTile(){
        return selectedTile;
    }
}
