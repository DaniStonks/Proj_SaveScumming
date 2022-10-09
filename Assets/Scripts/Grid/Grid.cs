using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Tile[,] GameGrid { get; set; } //[linha, coluna]

    void Start()
    {
        GameGrid = new Tile[10, 10];
        SetUpGrid();
    }

    private void SetUpGrid()
    {
        GameObject graphicGrid = GameObject.FindGameObjectWithTag("Grid");
        int row = 0, col = 0;
        foreach (Transform rowLine in graphicGrid.transform)
        {
            foreach (Transform rowTile in rowLine)
            {
                GameGrid[row, col] = rowTile.GetComponent<Tile>();
                col++;
            }
            row++;
            col = 0;
        }
    }

    /// <summary>
    /// Function to check if a cell has been visited
    /// </summary>
    private static bool isValid(bool[,] visited,
                       int row, int col)
    {
        // If cell lies out of bounds
        if (row < 0 || col < 0 || row >= GameGrid.GetLength(0) || col >= GameGrid.GetLength(1))
            return false;

        // If cell is already visited
        if (visited[row, col])
            return false;

        // Otherwise
        return true;
    }

    /// <summary>
    /// Uses Breadth-First Search to find all tiles within a certain distance from a starting tile.
    /// </summary>
    public static List<Tile> adjacentTilesWithinDistance(Tile tile, int maxDistance)
    {
        int[] dRow = { -1, 0, 1, 0 };
        int[] dCol = { 0, 1, 0, -1 };
        bool[,] visited = new bool[GameGrid.GetLength(0), GameGrid.GetLength(1)];
        int currentDistance = 0;
        List<Tile> adjacentTiles = new List<Tile>();

        // Stores indices of the matrix cells
        Queue q = new Queue();

        // Mark the starting cell as visited
        // and push it into the queue
        Coordenates startingCoords = indexOf(tile);
        q.Enqueue(startingCoords);
        visited[startingCoords.X, startingCoords.Y] = true;

        // Iterate while the queue
        // is not empty
        while (q.Count != 0)
        {
            if (currentDistance >= maxDistance)
            {
                return adjacentTiles;
            }
            int distanceSize = q.Count;

            // Go to the adjacent cells
            while (distanceSize-- != 0)
            {
                Coordenates currentTile = (Coordenates)q.Dequeue();
                print(GameGrid[currentTile.X, currentTile.Y] + " ");
                for (int i = 0; i < 4; i++)
                {
                    int adjx = currentTile.X + dRow[i];
                    int adjy = currentTile.Y + dCol[i];
                    if (isValid(visited, adjx, adjy))
                    {
                        q.Enqueue(new Coordenates(adjx, adjy));
                        visited[adjx, adjy] = true;
                        adjacentTiles.Add(GameGrid[adjx, adjy]);
                    }
                }
            }
            currentDistance++;
        }
        return adjacentTiles;
    }

    /// <summary>
    /// Returns the index of a tile passed by parameter, returns null if it doesn't exist
    /// </summary>
    public static Coordenates indexOf(Tile tile)
    {
        if (tile == null) return null;

        for (int r = 0; r < GameGrid.Length; r++)
        {
            for (int c = 0; c < GameGrid.Length; c++)
            {
                if (GameGrid[r, c] == tile) return new Coordenates(r, c);
            }
        }
        return null;
    }
}
