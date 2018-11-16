using System;
using UnityEngine;

namespace Bomber.Controllers
{
    /// <summary>
    /// Содержит логику и параметры для обработку входящих команд пользователя
    /// </summary>
    class InputController: MonoBehaviour
    {
        /// <summary>
        /// Значение входящей команды от пользователя по оси "Horizontal" без сглаживания 
        /// </summary>
        public float GetHorizontalRaw { get; private set; }
        
        /// <summary>
        /// Значение входящей команды от пользователя по оси "Vertical" без сглаживания 
        /// </summary>
        public float GetVerticalRaw { get; private set; }
        
        /// <summary>
        /// Событие нажатия на кнопку Space
        /// </summary>
        public Action PlaceBomb;
        /// <summary>
        /// Событие изменения входящих команд
        /// </summary>
        public Action<float,float> GetInput;
        /// <summary>
        /// Флаг для прекращения отпрвки 0 по осям "Horizontal" и "Vertical".
        /// Используется для предотвращения отправки одинаковой инфорации
        /// </summary>
        private bool _zeroSended = false;

        

        private void Update()
        {
            GetHorizontalRaw = Input.GetAxisRaw("Horizontal");
            GetVerticalRaw = Input.GetAxisRaw("Vertical");
            if (Input.GetButtonDown("Jump"))
            {
                PlaceBomb?.Invoke();
            }
            if (GetHorizontalRaw == 0 && GetVerticalRaw == 0 && !_zeroSended)
            {
                GetInput?.Invoke(GetHorizontalRaw, GetVerticalRaw);
                _zeroSended = true;
            }
            if (GetHorizontalRaw!=0|| GetVerticalRaw!=0)
            {
                GetInput?.Invoke(GetHorizontalRaw, GetVerticalRaw);
                _zeroSended = false;
            }
            
        }
        
    }
}
