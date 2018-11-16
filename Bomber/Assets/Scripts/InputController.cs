using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Bomber.Controllers
{
    class InputController: MonoBehaviour
    {
        public float GetHorizontal { get; private set; }
        public float GetVertical { get; private set; }
        public Action PlaceBomb;
        public Action<float,float> GetInput;

        private bool _zeroSended = false;

        private void Update()
        {
            GetHorizontal = Input.GetAxisRaw("Horizontal");
            GetVertical = Input.GetAxisRaw("Vertical");
            if (Input.GetButtonDown("Jump"))
            {
                PlaceBomb?.Invoke();
            }
            if (GetHorizontal == 0 && GetVertical == 0 && !_zeroSended)
            {
                Debug.Log(0);
                GetInput?.Invoke(GetHorizontal, GetVertical);
                _zeroSended = true;
            }
            if (GetHorizontal!=0|| GetVertical!=0)
            {
                GetInput?.Invoke(GetHorizontal, GetVertical);
                _zeroSended = false;
            }
        }
        
    }
}
