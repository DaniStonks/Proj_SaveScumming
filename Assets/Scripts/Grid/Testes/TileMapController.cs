using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapController : MonoBehaviour
{
    [SerializeField] private int rows = 10, cols = 10;
    [SerializeField] private float tileSize = 10;
    [SerializeField] private GameObject[,] mapGrid;

    // Start is called before the first frame update
    void Start()
    {
        mapGrid = new GameObject[rows, cols];
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject refTile = (GameObject)Instantiate(Resources.Load("MapTile"));
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(refTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector3(posX, 0, posY);
                mapGrid[row, col] = tile;
            }
        }

        Destroy(refTile);
    }


    //A grid vai ter que verificar o conteudo da tile se tiver um player vai lhe mostrar o quanto pode andar -> Caso estejam obstaculos no caminho tem que haver um recalculo do move
    private void TileContentVerification()
    {
    }
    //Se for obstaculo nao faz nada 
}
