using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public static Tile selectedTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveButtonPress() 
    {
        if (selectedTile != null) 
        {
            List<Tile> adjTiles = Grid.adjacentTilesWithinDistance(selectedTile, 1);
            foreach (Tile tiles in adjTiles)
            {
                tiles.Selected = true;
            }
        }
    }
}
