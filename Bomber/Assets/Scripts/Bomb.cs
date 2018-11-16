using System.Collections;
using UnityEngine;
using Bomber.Controllers;

/// <summary>
/// Содержит логику и параметры бомбы
/// </summary>
public class Bomb : MonoBehaviour
{
    /// <summary>
    /// Время до взрыва бомбы
    /// </summary>
    [SerializeField]
    [Tooltip("Время до взрыва бомбы")]
    private float _countdown = 2;
    /// <summary>
    /// Время до взрыва бомбы
    /// </summary>
    public float CountDown => _countdown;
    /// <summary>
    /// Колличестово взрывов
    /// </summary>
    private int _explosionCount;
    /// <summary>
    /// Колличество взрывов. Не может быть меньше 1.
    /// </summary>
    public int ExplosionCount
    {
        get => _explosionCount;
        set => _explosionCount = (value <1) ?1: value; 
    }
    /// <summary>
    /// Ссылка на Тайл Мап Контроллер
    /// </summary>
    private MapDestroyer _mapDestroyer;

    private void Start()
    {
        _mapDestroyer = FindObjectOfType<MapDestroyer>();
        StartCoroutine(Explode(_countdown, _explosionCount));
    }

    /// <summary>
    /// Вызывает в Тайл Мап Контроллере метод создания взрывов
    /// спустя заданный промежуток времени
    /// </summary>
    /// <param name="explodeTime">задержка перед врывом</param>
    /// <param name="explosionCount">колличество взрывов</param>
    /// <returns></returns>
    IEnumerator Explode(float explodeTime, int explosionCount)
    {
        yield return new WaitForSeconds(explodeTime);
        _mapDestroyer.Explode(transform.position, explosionCount);
        Destroy(gameObject);
    }
    //bool ExplodeCell(Vector3Int cell)
    //{
        
    //    Tile tile = _wallsMap.GetTile<Tile>(cell);
    //    if (tile != _destractable && tile != null)
    //    {
    //        return false;
    //    }
    //    _wallsMap.SetTile(cell, null);

    //    Vector3 explosionPos = _wallsMap.GetCellCenterWorld(cell);
    //    var exp = Instantiate(_explosionPrefab, explosionPos, Quaternion.identity);

    //    Destroy(exp, 0.5f);
    //    return true;

    //}
    //public void Explode(Vector2 worldPos, int count)
    //{

    //    Vector3Int originDestrCell = _mapDestroyer.GetWallsMap.WorldToCell(transform.position);
    //    ExplodeCell(originDestrCell);
    //    for (int i = 1; i < count + 1; i++)
    //    {
    //        if (!ExplodeCell(originDestrCell + new Vector3Int(i, 0, 0)))
    //        {
    //            break;
    //        }
    //    }
    //    for (int i = 1; i < count + 1; i++)
    //    {
    //        if (!ExplodeCell(originDestrCell + new Vector3Int(-i, 0, 0)))
    //        {
    //            break;
    //        }
    //    }
    //    for (int i = 1; i < count + 1; i++)
    //    {
    //        if (!ExplodeCell(originDestrCell + new Vector3Int(0, i, 0)))
    //        {
    //            break;
    //        }
    //    }
    //    for (int i = 1; i < count + 1; i++)
    //    {
    //        if (!ExplodeCell(originDestrCell + new Vector3Int(0, -i, 0)))
    //        {
    //            break;
    //        }
    //    }
    //}
}
