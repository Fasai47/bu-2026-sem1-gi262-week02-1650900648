using System;
using UnityEngine;

namespace Workshop.Student
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };

        // 1. declare Players variable
        public GameObject playerPrefab;

        // 7. declare Exit variable 
        public GameObject exitPrefab;

        public void Start()
        {
            // 1. random player at the position <0, 0> map
            if (playerPrefab != null)
            {
                Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            }

            // 2. create obstacles
            int obstacleCount = UnityEngine.Random.Range(2, 5);
            for (int i = 0; i < obstacleCount; i++)
            {
                int posX = UnityEngine.Random.Range(1, columns - 1);
                int posY = UnityEngine.Random.Range(1, rows - 1);

                if (wallTiles != null && wallTiles.Length > 0)
                {
                    int randWall = UnityEngine.Random.Range(0, wallTiles.Length);
                    Instantiate(wallTiles[randWall], new Vector3(posX, posY, -0.1f), Quaternion.identity);
                }
            }

            // 3. create floor
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (floorTiles != null && floorTiles.Length > 0)
                    {
                        int randFloor = UnityEngine.Random.Range(0, floorTiles.Length);
                        Instantiate(floorTiles[randFloor], new Vector2(x, y), Quaternion.identity);
                    }
                }
            }

            // 4. create walls
            for (int y = -1; y <= rows; y++)
            {
                for (int x = -1; x <= columns; x++)
                {
                    bool isOuterWall = (x == -1 || x == columns || y == -1 || y == rows);
                    if (isOuterWall && wallTiles != null && wallTiles.Length > 0)
                    {
                        int randWall = UnityEngine.Random.Range(0, wallTiles.Length);
                        Instantiate(wallTiles[randWall], new Vector2(x, y), Quaternion.identity);
                    }
                }
            }

            // 5. random foods
            int foodAmount = UnityEngine.Random.Range(2, 4);
            for (int i = 0; i < foodAmount; i++)
            {
                int fx = UnityEngine.Random.Range(0, columns);
                int fy = UnityEngine.Random.Range(0, rows);

                if (foodTiles != null && foodTiles.Length > 0)
                {
                    int randFood = UnityEngine.Random.Range(0, foodTiles.Length);
                    Instantiate(foodTiles[randFood], new Vector2(fx, fy), Quaternion.identity);
                }
            }

            // 6. generate item along with the saveItemMap
            if (foodTiles != null && foodTiles.Length > 0)
            {
                int mapRows = saveItemMap.GetLength(0);
                int mapCols = saveItemMap.GetLength(1);

                for (int r = 0; r < mapRows; r++)
                {
                    for (int c = 0; c < mapCols; c++)
                    {
                        string itemName = saveItemMap[r, c].Trim();
                        if (!string.IsNullOrEmpty(itemName))
                        {
                            foreach (GameObject foodPrefab in foodTiles)
                            {
                                if (foodPrefab != null && foodPrefab.name.Equals(itemName, StringComparison.OrdinalIgnoreCase))
                                {
                                    Instantiate(foodPrefab, new Vector2(c, r), Quaternion.identity);
                                }
                            }
                        }
                    }
                }
            }

            // 7. place exit
            if (exitPrefab != null)
            {
                Instantiate(exitPrefab, new Vector2(columns - 1, rows - 1), Quaternion.identity);
            }
        }
    }
}