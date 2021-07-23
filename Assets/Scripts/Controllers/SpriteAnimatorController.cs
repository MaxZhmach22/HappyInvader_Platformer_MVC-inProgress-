using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HappyInvaders
{

    public class SpriteAnimatorController : IDisposable
    {

        private sealed class Animation
        {
            public AnimState Track;
            public List<Sprite> Sprites;
            public bool Loop;
            public float Speed = 10;
            public float Counter = 0;
            public bool Sleep;

            public void Update()
            {
                if (Sleep) return;


            }
        }


        public void Update()
        {

        }
        public void Dispose()
        {
            
        }

    }

}
