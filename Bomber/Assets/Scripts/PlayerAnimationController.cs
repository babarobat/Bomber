using UnityEngine;

namespace Bomber.Controllers
{
    /// <summary>
    /// Логика и параметры анимации игрока
    /// </summary>
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
