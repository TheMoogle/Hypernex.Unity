﻿using System;
using UnityEngine;

namespace Hypernex.Game.Bindings
{
    public class Mouse : IBinding
    {
        public string Id => "Mouse";
        public bool IsLook => true;
        
        public float Up { get; set; }
        public float Down { get; set; }
        public float Left { get; set; }
        public float Right { get; set; }
        public bool Button { get; set; }
        public Action ButtonClick { get; set; } = () => { };
        public bool Button2 { get; set; }
        public Action Button2Click { get; set; } = () => { };
        public float Trigger { get; set; }
        public Action TriggerClick { get; set; } = () => { };
        public bool Grab { get; set; }

        public float Sensitivity = 1;

        public void Update()
        {
            Vector2 move = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            switch (move.x)
            {
                case > 0:
                    Right = move.x;
                    Left = 0;
                    break;
                case < 0:
                    Right = 0;
                    Left = -1 * move.x;
                    break;
                default:
                    Right = 0;
                    Left = 0;
                    break;
            }
            switch (move.y)
            {
                case > 0:
                    Up = move.y;
                    Down = 0;
                    break;
                case < 0:
                    Up = 0;
                    Down = -1 * move.y;
                    break;
                default:
                    Up = 0;
                    Down = 0;
                    break;
            }
            Button = Input.GetKey(KeyCode.E);
            if(Input.GetKeyDown(KeyCode.E))
                ButtonClick.Invoke();
            Button2 = Input.GetKey(KeyCode.Tab);
            if(Input.GetKeyDown(KeyCode.Tab))
                Button2Click.Invoke();
            if(Input.GetMouseButtonDown(1))
                TriggerClick.Invoke();
            Trigger = Input.GetMouseButton(1) ? 1.0f : 0;
            Grab = Input.GetMouseButton(0);
        }
    }
}