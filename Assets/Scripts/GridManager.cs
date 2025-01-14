using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class TileCollection
{
    public List<TileComponent> tiles = new List<TileComponent>();
}
public class GridManager : MonoBehaviour
{
    [SerializeField]
    List<TileCollection> columns;
    [SerializeField]
    List<TileCollection> lines;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
