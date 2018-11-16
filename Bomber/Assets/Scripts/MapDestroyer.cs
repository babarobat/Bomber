using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Bomber.Controllers
{
    [RequireComponent(typeof(Tilemap))]
    class MapDestroyer : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _map;
        [SerializeField]
        private Tile _destractable;
        [SerializeField]
        private GameObject _explosionPrefab;


        public void Explode(Vector2 worldPos, int count)
        {

            Vector3Int originDestrCell = _map.WorldToCell(worldPos);
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
        bool ExplodeCell(Vector3Int cell)
        {
            Tile tile = _map.GetTile<Tile>(cell);
            if (tile != _destractable && tile != null)
            {
                return false;
            }
            _map.SetTile(cell, null);

            Vector3 explosionPos = _map.GetCellCenterWorld(cell);
            var exp = Instantiate(_explosionPrefab, explosionPos, Quaternion.identity);
            
            Destroy(exp, 0.5f);
            return true;

        }
    }

}
