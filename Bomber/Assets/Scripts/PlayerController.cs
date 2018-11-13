using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private GameObject _bombPrefab;
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = _tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPos = _tilemap.GetCellCenterWorld(cell);

            Instantiate(_bombPrefab, cellCenterPos, Quaternion.identity);
        }
	}
}
