using UnityEngine;

namespace HappyInvaders
{
    public class PlayerMoveController
    {
        private float _xAxisInput; 
        private bool _isJump; 

        private float _walkSpeed = 150f;
        private float _animationSpeed = 15f;
        private float _movingTreshold = 0.1f; 

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private bool isMoving;

        private float _jumpForce = 7f;
        private float _jumpTreshold = 1f;
        private float _g = -9.8f;
        private float _groundLevel = 0.5f;
        private float _yVelocity = 0f;
        private float _xVelocity = 0f;

        private LevelView _view;
        private SpriteAnimatorController _spriteAnimator;
        private readonly ContactPoller _contactPoller;
        private CameraController _cameraController;

        public PlayerMoveController(LevelView player, SpriteAnimatorController animator, CameraController cameraController)
        {
            _view = player;
            _spriteAnimator = animator;
            _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            _contactPoller = new ContactPoller(_view._collider2D);
            _cameraController = cameraController;
        }

        private void MoveTowards()
        {
            _xVelocity = _walkSpeed * Time.fixedDeltaTime * (_xAxisInput < 0 ? -1 : 1);
            if (_xAxisInput > 0)
            {
                _cameraController.OffSetX = 3f;
                
            }
            else
            {
                _cameraController.OffSetX = -3f;

            }
                
            _view._rigidbody2D.velocity = _view._rigidbody2D.velocity.Change(x: _xVelocity);
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public void Update()
        {
            _spriteAnimator.Update();
            _contactPoller.Update();

            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;


            if (isMoving)
            {
                MoveTowards();
            }

            if (_contactPoller.IsGrounded)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);
                _cameraController.OffSetY = 0;

                if (_isJump && Mathf.Abs(_view._rigidbody2D.velocity.y) <= _jumpTreshold)
                {
                    _view._rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                    _cameraController.OffSetY = 3f;
                }
            }
            else
            {
                if (Mathf.Abs(_view._rigidbody2D.velocity.y) > _jumpTreshold)
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }
            }
        }
    }
}
