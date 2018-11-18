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
    [SerializeField]
    private GameObject _explosionPrefab;
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
    private MapController _mapController;

    private void Start()
    {
        _mapController = FindObjectOfType<MapController>();
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
        _mapController.Explode(transform.position, explosionCount);
        Destroy(gameObject);
    }
    
    private void InstantiateExplosions(int explosionCount)
    {
        Vector3Int pos = _mapController.GetWorldToCellPos(transform.position);
        if (_mapController.CanExplodeCell(transform.position))
        {

        }
        Instantiate(_explosionPrefab, pos, Quaternion.identity);
        
    }
}
