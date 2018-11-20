using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Bomber.Controllers
{
    /// <summary>
    /// Содержит логику и параметры карты из тайлов.
    /// </summary>
    [RequireComponent(typeof(Grid))]
    class MapController : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _wallsMap;
        [SerializeField]
        private Tile[] _destractables;


        public Tilemap GetWallsMap => _wallsMap;
        public Vector3Int GetWorldToCellPos(Vector3 worldPos) => _wallsMap.WorldToCell(worldPos);
        public Tile GetTile(Vector3Int pos) => _wallsMap.GetTile<Tile>(pos);



        public List<Vector3> ExplodeCells(Vector3 worldPos, int eplxCount)
        {
            List<Vector3> tmp = new List<Vector3>();
            Vector3Int origin = GetWorldToCellPos(worldPos);
            Vector3 explosionPos = _wallsMap.GetCellCenterWorld(origin);
            tmp.Add(explosionPos);
            foreach (var item in _destractables)
            {
                for (int i = 1; i < eplxCount + 1; i++)
                {
                    Vector3Int pos = origin + new Vector3Int(i, 0, 0);
                    explosionPos = _wallsMap.GetCellCenterWorld(pos);
                    Tile tile = GetTile(pos);
                    if (tile == item)
                    {
                        _wallsMap.SetTile(pos, null);
                        tmp.Add(explosionPos);

                        break;
                    }
                    if (tile != item && tile != null)
                    {

                        break;
                    }
                    if (tile != item && tile == null)
                    {

                        tmp.Add(explosionPos);

                    }
                }
                for (int i = 1; i < eplxCount + 1; i++)
                {
                    Vector3Int pos = origin + new Vector3Int(-i, 0, 0);
                    explosionPos = _wallsMap.GetCellCenterWorld(pos);
                    Tile tile = GetTile(pos);
                    if (tile == item)
                    {
                        _wallsMap.SetTile(pos, null);
                        tmp.Add(explosionPos);

                        break;
                    }
                    if (tile != item && tile != null)
                    {

                        break;
                    }
                    if (tile != item && tile == null)
                    {

                        tmp.Add(explosionPos);

                    }
                }
                for (int i = 1; i < eplxCount + 1; i++)
                {
                    Vector3Int pos = origin + new Vector3Int(0, -i, 0);
                    explosionPos = _wallsMap.GetCellCenterWorld(pos);
                    Tile tile = GetTile(pos);
                    if (tile == item)
                    {
                        _wallsMap.SetTile(pos, null);
                        tmp.Add(explosionPos);

                        break;
                    }
                    if (tile != item && tile != null)
                    {

                        break;
                    }
                    if (tile != item && tile == null)
                    {

                        tmp.Add(explosionPos);

                    }
                }
                for (int i = 1; i < eplxCount + 1; i++)
                {
                    Vector3Int pos = origin + new Vector3Int(0, i, 0);
                    explosionPos = _wallsMap.GetCellCenterWorld(pos);
                    Tile tile = GetTile(pos);
                    if (tile == item)
                    {
                        _wallsMap.SetTile(pos, null);
                        tmp.Add(explosionPos);

                        break;
                    }
                    if (tile != item && tile != null)
                    {

                        break;
                    }
                    if (tile != item && tile == null)
                    {

                        tmp.Add(explosionPos);

                    }
                }
            }
            return tmp;
        }
    }
    
}

        
        
        
    


