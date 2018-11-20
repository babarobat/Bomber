using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(InstantiateExplosions(_explosionCount,_countdown ));
    }

    

    IEnumerator InstantiateExplosions(int explosionCount, float explodeTime)
    {
        yield return new WaitForSeconds(explodeTime);
        foreach (var item in _mapController.ExplodeCells(transform.position,ExplosionCount))
        {
            var exp = Instantiate(_explosionPrefab, item, Quaternion.identity);
            Destroy(exp, 0.5f);
        }
        Destroy(gameObject);
    }
    
    
}
