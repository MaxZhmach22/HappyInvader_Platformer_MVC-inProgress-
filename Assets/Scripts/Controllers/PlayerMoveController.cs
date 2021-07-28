using UnityEngine;

namespace HappyInvaders
{
    public class PlayerMoveController
    {
        private float _xAxisInput; 
        private bool _isJump; 

        private float _walkSpeed = 3f;
        private float _animationSpeed = 10f;
        private float _movingTreshold = 0.1f; 
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private bool isMoving;

        private float _jumpSpeed = 9f;
        private float _jumpTreshold = 1f;
        private float _g = -9.8f;
        private float _groundLevel = 0.5f;
        private float _yVelocity = 0f;

        private LevelView _view;
        private SpriteAnimatorController _spriteAnimator;

        public PlayerMoveController(LevelView player, SpriteAnimatorController animator)
        {
            _view = player;
            _spriteAnimator = animator;
            _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
        }

        public bool IsGrounded()
        {
            return _view._transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
        }

        private void MoveTowards()
        {   
            _view._transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale); 
        }

        public void Update()
        {
            _spriteAnimator.Update(); 
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0; 
            isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold; 


            if (isMoving)
            {
                MoveTowards();
            }

            if (IsGrounded())
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);


                if (_isJump && _yVelocity <= 0)
                {
                    _yVelocity = _jumpSpeed;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = float.Epsilon;
                    _view._transform.position = _view._transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpTreshold)
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }

                _yVelocity += _g * Time.deltaTime;

                _view._transform.position += Vector3.up * (Time.deltaTime * _yVelocity);

            }
        }
    }
}
