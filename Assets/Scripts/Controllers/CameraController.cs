using UnityEngine;

namespace HappyInvaders
{
    public class CameraController
    {
        private float X;
        private float Y;

        private float offSetX = 0f;
        private float offSetY = 0f;

        private float _offSetLerpSpeed = 5f;
        private Vector3 _offsetLerpVector;

        public float OffSetX { get => offSetX; set => offSetX = value; }
        public float OffSetY { get => offSetY; set => offSetY = value; }


        private float camSpeed = 300f;

        private Transform _player;
        private Transform _camera;

        public CameraController(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
        }

        public void Update()
        {
            X = _player.position.x;
            Y = _player.position.y;

            _offsetLerpVector = Vector3.Lerp(_camera.position, new Vector3(X + offSetX, Y+offSetY, _camera.position.z), Time.deltaTime * _offSetLerpSpeed);
            _camera.position = Vector3.Lerp(_camera.position, _offsetLerpVector, Time.deltaTime * camSpeed);
           
            
        }

    }
}
