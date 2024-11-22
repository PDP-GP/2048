using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCell : MonoBehaviour // (cell не двигается, tile двиг)
{
    
    public Vector2Int coordinates { get; set; } //grid передаёт координаты для cell
    public Tile tile { get; set; } // отслеживание, какая tile на cell

    public bool empty => tile == null; //проверка, есть ли на cell tile
    public bool occupied => tile != null;
}
