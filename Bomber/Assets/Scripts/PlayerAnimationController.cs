using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Bomber.Controllers
{
    [RequireComponent(typeof(Animator))]
    class PlayerAnimationController:MonoBehaviour
    {
        private Animator _animator;
        private InputController _inputController;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _inputController = FindObjectOfType<InputController>();
            _inputController.GetInput += SetFloat;
        }
        private void SetFloat(float velocityX,float velocityY)
        {
            
            _animator.SetFloat("VelocityX", velocityX);
            _animator.SetFloat("VelocityY", velocityY);
        }
    }
}
