using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRow : MonoBehaviour // row отслеживает те cell, что внутри него
{
    public TileCell[] cells {  get; private set; }

    public void Awake()
    {
        cells = GetComponentsInChildren<TileCell>(); //поиск компонентов в ряду (дочерних)
    }
}
