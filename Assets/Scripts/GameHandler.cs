using System.Collections.Generic;
using UnityEngine;

namespace HappyInvaders
{

    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig playerConfig;
        [SerializeField] private SpriteAnimatorConfig starsConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelView _playerView;
        private GameObject[] _stars;
        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _starsAnimator;
        private PlayerMoveController _playerMoveController;
        private CameraController _cameraController;
        private List<EasyAnimations> _easyAnimations = new List<EasyAnimations>();

        private void Awake()
        {
            playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(playerConfig);
            _starsAnimator = new SpriteAnimatorController(starsConfig);
            _stars = GameObject.FindGameObjectsWithTag("Stars");
            for (int i = 0; i < _stars.Length; i++)
            {
                SpriteRenderer spriteRenderer = _stars[i].GetComponent<SpriteRenderer>();
                _starsAnimator.StartAnimation(spriteRenderer, AnimState.Idle, true, 5);
                _easyAnimations.Add(new EasyAnimations(_stars[i].transform, _stars[i].transform.position.y));
            }

            _cameraController = new CameraController(_playerView.transform, Camera.main.transform);
            _playerMoveController = new PlayerMoveController(_playerView, _playerAnimator, _cameraController);

        }

        private void Update()
        {
            _playerMoveController.Update();
            _cameraController.Update();
            _starsAnimator.Update();

           foreach(var star in _easyAnimations)
            {
                star.Update();
            }
                
        }

        private void FixedUpdate()
        {
            
        }


    }
}
