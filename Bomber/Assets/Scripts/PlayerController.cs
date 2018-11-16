using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Bomber.Interfaces;
namespace Bomber.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class PlayerController : MonoBehaviour,IDamage
    {

        [SerializeField]
        private Tilemap _tilemap;
        [SerializeField]
        private Bomb _bombPrefab;
        [SerializeField]
        private Transform _bombSpawnPoint;
        [SerializeField]
        private float _speed;

        
        private int _health;
        private Rigidbody2D _rb;
        private InputController _inputController;
        
        public void ApplyDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
        
        private void Start()
        {
            
            _rb = GetComponent<Rigidbody2D>();
            _inputController = FindObjectOfType<InputController>();
            
            
            _inputController.PlaceBomb += PlaceBomb;
            _inputController.GetInput += Move;
        }
        
        private void PlaceBomb()
        {
                Vector3Int cell = _tilemap.WorldToCell(_bombSpawnPoint.position);
                Vector3 cellCenterPos = _tilemap.GetCellCenterWorld(cell);
                Instantiate(_bombPrefab, cellCenterPos, Quaternion.identity);            
        }
        private void Move( float hor, float vert)
        {
            var tmpSpeed = _speed;
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
