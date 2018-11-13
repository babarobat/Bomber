using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(Tilemap))]
class MapDestroyer : MonoBehaviour
{
   
    private Tilemap _tilemap;

    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
    }
    public void Explode(Vector2 worldPos)
    {
       Vector3Int originCell =  _tilemap.WorldToCell(worldPos);
    }
}
