using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapTileBasic;
    public GameObject baseTile;
    public GameObject startTile;

    public int mapWidth;
    public int mapHeight;

    private int currentIndex;
    private GameObject currentTile;

    private List<GameObject> mapTiles = new List<GameObject>();
    private List<int> lastPaths = new List<int>();

    private void Awake()
    {
        lastPaths.Add(3);
        lastPaths.Add(3); //find a better way

        generateMap();
        generatePath();
    }
    
    void pathLeft()
    {
        currentIndex--;
        currentTile = mapTiles[currentIndex];
        lastPaths.Add(1);
        lastPaths.RemoveAt(0);
    }
    void pathRight()
    {
        currentIndex++;
        currentTile = mapTiles[currentIndex];
        lastPaths.Add(2);
        lastPaths.RemoveAt(0);
    }
    void pathUP()
    {
        currentIndex += mapWidth;
        currentTile = mapTiles[currentIndex];
        lastPaths.Add(3);
        lastPaths.RemoveAt(0);
    }
    
    private void generateMap()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                GameObject newTile = Instantiate(mapTileBasic);
                mapTiles.Add(newTile);
                newTile.transform.position = new Vector2(x-mapWidth/2, y-mapHeight/2);
            }
        }    
        
        Instantiate(baseTile, new Vector2(0, -mapHeight / 2), transform.rotation);
    }
    
    void generatePath()
    {
        currentIndex = Mathf.FloorToInt(mapWidth / 2);
        currentTile = mapTiles[currentIndex];

        int i = 0; 
        while (i < 1000)
        {
            if (currentIndex > mapHeight * mapWidth - mapWidth)
            {
                Instantiate(startTile, currentTile.transform.position, transform.rotation);
                Destroy(currentTile);
                break;
            }

            Destroy(currentTile);
            int roll = Random.Range(1, 6);
            i++;

            if (roll == 5 || currentIndex <= 23)
            {
                pathUP();
            }
            else if ((roll == 1 || roll == 2) && (currentIndex + (mapWidth - 1)) % mapWidth != 0 && lastPaths[1] != 2 && !(lastPaths[0] == 2 && lastPaths[1] == 3))
            {
                pathLeft();
            }
            else if ((roll == 3 || roll == 4) && (currentIndex + 2) % mapWidth != 0 && lastPaths[1] != 1 && !(lastPaths[0] == 1 && lastPaths[1] == 3))
            {
                pathRight();
            }
            else
            {
                Debug.Log(i + "reroll");
            }
        }
    }
}