using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Bomber.Interfaces;
namespace Bomber.Controllers
{
    /// <summary>
    /// Содержит логику и параметры управления игроком
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class PlayerController : MonoBehaviour,IDamage
    {

        /// <summary>
        /// Ссылка на префаб бомбы.
        /// </summary>
        [Header("Оружие")]
        [Tooltip("Префаб бомбы")]
        [SerializeField]
        private Bomb _bombPrefab;
        /// <summary>
        /// Место создания бомбы
        /// </summary>
        [Tooltip("Место создания бомбы")]
        [SerializeField]
        private Transform _bombSpawnPoint;
        /// <summary>
        /// Колличество взрывов
        /// </summary>
        [Tooltip("Колличество взрывов")]
        [SerializeField]
        private int _explosionCount;
        /// <summary>
        /// Стартовая скорость игрока
        /// </summary>
        [Header("Параметры игрока")]
        [Tooltip("Стартовая скорость игрока")]
        [SerializeField]
        private float _speed;
        /// <summary>
        /// Стартовое здоровье игрока
        /// </summary>
        [Tooltip("Стартовое здоровье игрока")]
        [SerializeField]
        private int _health;
        
        /// <summary>
        /// ссылка на компонент RigidBody 2D
        /// </summary>
        private Rigidbody2D _rb;
        /// <summary>
        /// Ссылка на контроллер ввода
        /// </summary>
        private InputController _inputController;
        /// <summary>
        /// Ссылка на контроллер карты
        /// </summary>
        private MapDestroyer _mapDestroyer;

        /// <summary>
        /// Текущая скорость. Не может быть меньше 0
        /// </summary>
        public float CurrentSpeed
        {
            get => _speed;
            set => _speed = (value < 0) ? 0 : value;
        }
        /// <summary>
        /// Текущее здоровье
        /// </summary>
        public int CurrentHealth
        {
            get => _health;
            set => _health = (value < 0) ? 0 : value;

        }
        public void ApplyDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
        
        private void Start()
        {
            
            _rb = GetComponent<Rigidbody2D>();
            _inputController = FindObjectOfType<InputController>();
            _mapDestroyer = FindObjectOfType<MapDestroyer>();

            CurrentSpeed = _speed;


            _inputController.PlaceBomb += PlaceBomb;
            _inputController.GetInput += Move;
        }
        /// <summary>
        /// Устанавливает бомбу под игроком и передает ей параметры колличества взрывов
        /// </summary>
        private void PlaceBomb()
        {
            Vector3Int cell = _mapDestroyer.GetWallsMap.WorldToCell(_bombSpawnPoint.position);
            Vector3 cellCenterPos = _mapDestroyer.GetWallsMap.GetCellCenterWorld(cell);
            var bomb = Instantiate(_bombPrefab, cellCenterPos, Quaternion.identity);
            bomb.ExplosionCount = _explosionCount;
        }
        /// <summary>
        /// Двигает игрока по горизонтали и вертикали
        /// </summary>
        /// <param name="hor"></param>
        /// <param name="vert"></param>
        private void Move( float hor, float vert)
        {
            var tmpSpeed = CurrentSpeed;
            if (hor != 0 && vert != 0)
            {
                tmpSpeed = tmpSpeed * 0.75f;
            }
            _rb.MovePosition(new Vector3(transform.position.x + hor * tmpSpeed * Time.deltaTime,
                                          transform.position.y + vert * tmpSpeed * Time.deltaTime, 0));

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Explosion")
            {
               
            }
        }
    }

}
