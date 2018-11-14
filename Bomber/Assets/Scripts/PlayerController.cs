using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private Bomb _bombPrefab;
    [SerializeField]
    private Transform _bombSpawnPoint;
    [SerializeField]
    private float _speed;
    
    private Animator _animator;

    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       
        _animator = GetComponent<Animator>();
    }
    void Update ()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");
        _animator.SetFloat("VelocityX", hor);
        _animator.SetFloat("VelocityY", vert);
        if (Input.GetButtonDown("Jump"))
        {
            
            Vector3Int cell = _tilemap.WorldToCell(_bombSpawnPoint.position);
            Vector3 cellCenterPos = _tilemap.GetCellCenterWorld(cell);
            Instantiate(_bombPrefab, cellCenterPos, Quaternion.identity);
        }
        if (hor != 0 || vert !=0)
        {
            
            _rb.MovePosition( new Vector3(transform.position.x + hor* _speed * Time.deltaTime, transform.position.y+vert * _speed * Time.deltaTime,0));
        }
        
	}

}
