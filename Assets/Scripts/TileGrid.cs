using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileGrid : MonoBehaviour //grid смотрит на ряды и на cells тоже
{
    public TileRow[] rows {  get; private set; }
    public TileCell[] cells { get; private set; }

    public int size => cells.Length; 
    public int height => rows.Length; 
    public int width => size / height;

    private void Awake()
    {   
        rows = GetComponentsInChildren<TileRow>();
        cells = GetComponentsInChildren<TileCell>();
    }
    //привязать координаты к каждой cell

    private void Start()
    {
        for (int y = 0 ; y < rows.Length; y++)
        {
            for (int x = 0 ; x < rows[y].cells.Length; x++)
            {
                rows[y].cells[x].coordinates = new Vector2Int(x, y); //определили координаты cell
            }
        }
    }
    
    public TileCell GetCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return rows[y].cells[x];
        } else
        {
            return null;
        }
    }

    public TileCell GetCell(Vector2Int coordinates)
    {
        return GetCell(coordinates.x, coordinates.y);
    }
    public TileCell GetAdjacentCell(TileCell cell, Vector2Int direction) //соседн клетка
    {
        Vector2Int coordinates = cell.coordinates;
        coordinates.x += direction.x;
        coordinates.y -= direction.y; //'-1' - up => reverse

        return GetCell(coordinates);
    }

    public TileCell GetRandomEmptyCell() //посик рандомной свободной клетки для спавна
    {
        int index = Random.Range(0, cells.Length);
        int startingIndex = index;
        while (cells[index].occupied)
        {
            index ++;
            if (index >= cells.Length)
            {
                index = 0;
            }
            if (index == startingIndex)
            {
                return null;
            }
        }
        return cells[index];
    }
}
