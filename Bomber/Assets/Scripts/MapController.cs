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
        private Tile _destractable;
        [SerializeField]
        private GameObject _explosionPrefab;

        public Tilemap GetWallsMap
        {
            get => _wallsMap;
            
        }
        public Vector3Int GetWorldToCellPos(Vector2 worldPos) => _wallsMap.WorldToCell(worldPos);
        public bool CanExplodeCell(Vector2 worldPos)
        {
            Vector3Int originDestrCell = _wallsMap.WorldToCell(worldPos);
            Tile tile = _wallsMap.GetTile<Tile>(originDestrCell);
            if (tile != _destractable && tile != null)
            {
                return false;
            }
            else return true;
        }
        public void RemoveCell(Vector2 worldPos) 
        {
            Vector3Int originDestrCell = _wallsMap.WorldToCell(worldPos);
            Tile tile = _wallsMap.GetTile<Tile>(originDestrCell);
            _wallsMap.SetTile(originDestrCell, null);
        }
        public void Explode(Vector2 worldPos, int count)
        {

            Vector3Int originDestrCell = _wallsMap.WorldToCell(worldPos);
            ExplodeCell(originDestrCell);
            for (int i = 1; i < count + 1; i++)
            {
                if (!ExplodeCell(originDestrCell + new Vector3Int(i, 0, 0)))
                {
                    break;
                }
            }
            for (int i = 1; i < count + 1; i++)
            {
                if (!ExplodeCell(originDestrCell + new Vector3Int(-i, 0, 0)))
                {
                    break;
                }
            }
            for (int i = 1; i < count + 1; i++)
            {
                if (!ExplodeCell(originDestrCell + new Vector3Int(0, i, 0)))
                {
                    break;
                }
            }
            for (int i = 1; i < count + 1; i++)
            {
                if (!ExplodeCell(originDestrCell + new Vector3Int(0, -i, 0)))
                {
                    break;
                }
            }
        }
        bool CanExplodeCell(Vector3Int cell)
        {
            Tile tile = _wallsMap.GetTile<Tile>(cell);
            if (tile != _destractable && tile != null)
            {
                return false;
            }
            if (tile == _destractable)
            {
                _wallsMap.SetTile(cell, null);

                Vector3 expPos = _wallsMap.GetCellCenterWorld(cell);
                var expp = Instantiate(_explosionPrefab, expPos, Quaternion.identity);

                Destroy(expp, 0.5f);
                return false;
            }
            _wallsMap.SetTile(cell, null);

            Vector3 explosionPos = _wallsMap.GetCellCenterWorld(cell);
            var exp = Instantiate(_explosionPrefab, explosionPos, Quaternion.identity);

            Destroy(exp, 0.5f);
            return true;

        }
        public List<Vector3> CanExplodePoints(Vector2 startWorldPoint, int count)
        {
            List<Vector3> tmp = new List<Vector3>();

        }
    }

}
