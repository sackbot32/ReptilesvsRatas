using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[Serializable]
public class TileCollection
{
    public List<TileComponent> tiles = new List<TileComponent>();

    public bool ContainsTile(TileComponent tile)
    {
        return tiles.Contains(tile);
    }
}
public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public TileCollection allTiles;
    [SerializeField]
    public List<TileCollection> columns;
    [SerializeField]
    public List<TileCollection> lines;
    public Transform selector;
    //Data
    Vector2 touchPosition;
    Vector3 worldPosition;

    private void Start()
    {
        instance = this;
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        if (Touch.activeTouches.Count == 0)
        {
            foreach (TileComponent allTile in GridManager.instance.allTiles.tiles)
            {
                allTile.sRendrer.color = Color.white;
            }
            selector.position = new Vector2(1000, 1000);
        } else
        {
            touchPosition = new Vector2();
            foreach (Touch touch in Touch.activeTouches)
            {
                touchPosition = touch.screenPosition; //Sum up th positions of all touches
            }

            //Get the average position of all touches 
            //touchPosition /= Touch.activeTouches.Count;

            //convert the touch position to the unity world space
            worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            //print(worldPosition);
            selector.position = worldPosition;
        }

        
    }
    /// <summary>
    /// Returns coords of the grid, first is line, second is column
    /// </summary>
    /// <param name="tile"></param>
    /// <returns></returns>
    public int[] WhereTile(TileComponent tile)
    {
        int[] coords = new int[2];
        int whatLine = 0;
        int whatColumn = 0;
        foreach (TileCollection lineCollect in lines)
        {
            if (lineCollect.ContainsTile(tile))
            {
                break;
            } else
            {
                whatLine++;
            }
        }
        foreach (TileCollection columnCollect in columns)
        {
            if (columnCollect.ContainsTile(tile))
            {
                break;
            } else
            {
                whatColumn++;
            }
        }
        coords[0] = whatLine;
        coords[1] = whatColumn;

        return coords;
        
    }
}
