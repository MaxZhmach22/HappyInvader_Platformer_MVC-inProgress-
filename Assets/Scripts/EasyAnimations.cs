using UnityEngine;

namespace HappyInvaders
{
    public class EasyAnimations
    {

        private static float minimum = -0.2F;
        private static float maximum = 0.2F;
        private float _startPosY;
        private float t = 0.0f;
        private Transform _transform;

        public EasyAnimations(Transform transform,float startPosY)
        {
            _startPosY = startPosY;
            _transform = transform;
        }

        public void Update()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.Lerp(_startPosY + minimum, _startPosY + maximum, t), _transform.position.z);
            t += 0.7f * Time.deltaTime;
            if (t > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                t = 0.0f;
            }
        }
    }
}