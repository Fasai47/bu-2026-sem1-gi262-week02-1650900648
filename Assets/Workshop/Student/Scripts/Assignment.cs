using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            AS01_RandomItemDrop();
            AS02_NestedLoopForCreate2DMap();
            AS03_NestedLoopForMakingWallAround();
            AS04_AttackEnemy();
            AS05_DynamicIterationLoop();
            AS06_WhileLoopAndArray();
            AS07_HealTargetAtIndex();
            AS08_RandomPickingDialogue();
            AS09_MultiplicationTable();
            AS10_FindSummationFromZeroToNUsingWhileLoop();
            AS11_SpawnEnemies();
            StartCoroutine(AS12_CountTime());
            AS13_SumOfNumbersInRow();
            AS14_SumOfNumbersInColumn();
            AS15_MakeTheTriangle();
            AS16_MultiplicationTableOf_2_3_and_4();
            //EX_01_TicTacToeGame_TurnPlay();
        }

        #region Assignment

        [Header("AS01_RandomItemDrop")]
        public GameObject[] as01_items;
        public void AS01_RandomItemDrop()
        {
            if (as01_items == null || as01_items.Length == 0) return;
            int r = UnityEngine.Random.Range(0, as01_items.Length);
            GameObject go = Instantiate(as01_items[r], transform.position, Quaternion.identity);
            Debug.Log($"Got item: {go.name}");
        }

        [Header("AS02_NestedLoopForCreate2DMap")]
        public GameObject[] as02_floorTiles;
        public int as02_columns;
        public int as02_rows;
        public void AS02_NestedLoopForCreate2DMap()
        {
            if (as02_floorTiles == null || as02_floorTiles.Length == 0) return;
            for (int y = 0; y < as02_rows; y++)
            {
                for (int x = 0; x < as02_columns; x++)
                {
                    int r = UnityEngine.Random.Range(0, as02_floorTiles.Length);
                    GameObject tile = Instantiate(as02_floorTiles[r], new Vector2(x, y), transform.rotation);
                    tile.name = $"tile {x} - {y}";
                }
            }
        }

        [Header("AS03_NestedLoopForMakingWallAround")]
        public GameObject as03_wall;
        public int as03_columns;
        public int as03_rows;
        public void AS03_NestedLoopForMakingWallAround()
        {
            if (as03_wall == null) return;
            for (int y = -1; y <= as03_rows; y++)
            {
                for (int x = -1; x <= as03_columns; x++)
                {
                    if (x == -1 || x == as03_columns || y == -1 || y == as03_rows)
                    {
                        GameObject wall = Instantiate(as03_wall, new Vector2(x, y), Quaternion.identity);
                        wall.name = $"wall {x} - {y}";
                    }
                }
            }
        }

        [Header("AS04_AttackEnemy")]
        public int[] as04_enemyHP;
        public int as04_damage;
        public int as04_target;
        public void AS04_AttackEnemy()
        {
            if (as04_enemyHP == null || as04_enemyHP.Length == 0) return;

            as04_enemyHP[0] = Mathf.Max(0, as04_enemyHP[0] - as04_damage);
            Debug.Log($"FirstEnemy hp :{as04_enemyHP[0]}");

            as04_enemyHP[as04_enemyHP.Length - 1] = Mathf.Max(0, as04_enemyHP[as04_enemyHP.Length - 1] - as04_damage);
            Debug.Log($"LastEnemy hp :{as04_enemyHP[as04_enemyHP.Length - 1]}");

            if (as04_target >= 0 && as04_target < as04_enemyHP.Length)
            {
                as04_enemyHP[as04_target] = Mathf.Max(0, as04_enemyHP[as04_target] - as04_damage);
                Debug.Log($"TargetEnemy {as04_target} hp :{as04_enemyHP[as04_target]}");
            }
        }

        [Header("AS05_DynamicIterationLoop")]
        public int as05_n;
        public void AS05_DynamicIterationLoop()
        {
            for (int i = 0; i < as05_n; i++)
            {
                Debug.Log($"{i}");
            }
        }

        [Header("AS06_WhileLoopAndArray")]
        public string[] as06_ironManSuitNames;
        public void AS06_WhileLoopAndArray()
        {
            if (as06_ironManSuitNames == null) return;

            int i = 0;
            Debug.Log("======Log by One======");
            while (i < as06_ironManSuitNames.Length)
            {
                Debug.Log($"{as06_ironManSuitNames[i]}");
                i++;
            }

            int j = 0;
            Debug.Log("======Log by Two======");
            while (j < as06_ironManSuitNames.Length)
            {
                Debug.Log($"{as06_ironManSuitNames[j]}");
                j += 2;
            }
        }

        [Header("AS07_HealTargetAtIndex")]
        public int[] as07_heroHPs;
        public int as07_heal;
        public int as07_targetIndex;
        public void AS07_HealTargetAtIndex()
        {
            if (as07_heroHPs == null || as07_heroHPs.Length == 0) return;

            as07_heroHPs[0] += as07_heal;
            Debug.Log($"FirstHero hp :{as07_heroHPs[0]}");

            as07_heroHPs[as07_heroHPs.Length - 1] += as07_heal;
            Debug.Log($"LastHero hp :{as07_heroHPs[as07_heroHPs.Length - 1]}");

            if (as07_targetIndex >= 0 && as07_targetIndex < as07_heroHPs.Length)
            {
                as07_heroHPs[as07_targetIndex] += as07_heal;
                Debug.Log($"TargetHero {as07_targetIndex} hp :{as07_heroHPs[as07_targetIndex]}");
            }
        }

        [Header("AS08_RandomPickingDialogue")]
        public string[] as08_dialogues;
        public void AS08_RandomPickingDialogue()
        {
            if (as08_dialogues == null || as08_dialogues.Length == 0) return;
            int r = UnityEngine.Random.Range(0, as08_dialogues.Length);
            Debug.Log($"{as08_dialogues[r]}");
        }

        [Header("AS09_MultiplicationTable")]
        public int as09_n;
        public void AS09_MultiplicationTable()
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{as09_n}x{i}={as09_n * i}");
            }
        }

        [Header("AS10_FindSummationFromZeroToNUsingWhileLoop")]
        public int as10_n;
        public void AS10_FindSummationFromZeroToNUsingWhileLoop()
        {
            int i = 1;
            int sum = 0;
            while (i <= as10_n)
            {
                sum += i;
                i++;
            }
            Debug.Log($"ผลรวมของ n จาก 1 ถึง {as10_n} คือ {sum}");
        }

        [Header("AS11_SpawnEnemies")]
        public int[] as11_enemyHPs;
        public GameObject as11_enemyPrefab;
        public void AS11_SpawnEnemies()
        {
            if (as11_enemyHPs == null || as11_enemyPrefab == null) return;
            for (int i = 0; i < as11_enemyHPs.Length; i++)
            {
                Instantiate(as11_enemyPrefab, new Vector3(i + 1, 0, -0.1f), transform.rotation);
                Debug.Log($"new enemy at position x = {i + 1}");
            }
        }

        [Header("AS12_CountTime")]
        public float as12_countTime;
        public IEnumerator AS12_CountTime()
        {
            float timer = 0f;
            while (timer < as12_countTime)
            {
                timer += Time.deltaTime;
                Debug.Log($"timer : {timer:F2}");
                yield return null;
            }
            Debug.Log($"End timer : {as12_countTime}");
        }

        [Header("AS13_SumOfNumbersInRow")]
        public Grid2DInt as13_matrix = new Grid2DInt
        {
            rows = 3,
            cols = 3,
            data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        };
        public int as13_row;
        public void AS13_SumOfNumbersInRow()
        {
            var matrix = as13_matrix.Get2DArray();
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                sum += matrix[as13_row, i];
            }
            Debug.Log($"{sum}");
        }

        [Header("AS14_SumOfNumbersInColumn")]
        public Grid2DInt as14_matrix = new Grid2DInt
        {
            rows = 3,
            cols = 3,
            data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        };
        public int as14_column;
        public void AS14_SumOfNumbersInColumn()
        {
            var matrix = as14_matrix.Get2DArray();
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, as14_column];
            }
            Debug.Log($"{sum}");
        }

        [Header("AS15_MakeTheTriangle")]
        public int as15_size;
        public void AS15_MakeTheTriangle()
        {
            for (int y = 1; y <= as15_size; y++)
            {
                string star = "";
                for (int x = 1; x <= y; x++)
                {
                    star += "*";
                }
                Debug.Log($"{star}");
            }
        }

        [Header("AS16_MultiplicationTableOf_2_3_and_4")]
        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            for (int y = 1; y <= 12; y++)
            {
                string line = $"{2} x {y} = {2 * y}\t{3} x {y} = {3 * y}\t{4} x {y} = {4 * y}";
                Debug.Log(line);
            }
        }

        #endregion
    }
}