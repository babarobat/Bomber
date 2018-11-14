using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float _countdown = 2;
    private MapDestroyer _mapDestroyer;

    private void Start()
    {
        _mapDestroyer = FindObjectOfType<MapDestroyer>();
    }

    void Update ()
    {
        _countdown -= Time.deltaTime;
        if (_countdown<=0)
        {
            _mapDestroyer.Explode(transform.position,5);
            Destroy(gameObject);
        }
	}
}
