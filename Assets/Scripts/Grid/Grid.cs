using UnityEngine;

public class Grid : MonoBehaviour
{

    private GameObject[,] grid; //[linha, coluna]
    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[10,10];
        SetUpGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpGrid(){
        GameObject graphicGrid = GameObject.FindGameObjectWithTag("Grid");
        int row = 0, col = 0;
        foreach(Transform rowLine in graphicGrid.transform){
            foreach(Transform rowTile in rowLine){
                grid[row, col] = rowTile.gameObject;
                col++;
            }
            row++;
            col = 0;
        }
    }
}
