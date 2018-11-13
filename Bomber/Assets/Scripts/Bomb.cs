using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float _countdown;
	
	
	void Update ()
    {
        _countdown -= Time.deltaTime;
        if (_countdown<=0)
        {
            Destroy(gameObject);
        }
	}
}
