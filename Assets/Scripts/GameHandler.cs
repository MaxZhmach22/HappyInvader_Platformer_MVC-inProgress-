using UnityEngine;

namespace HappyInvaders
{

    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig playerConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelView _playerView;
        private SpriteAnimatorController _playerAnimator;
        private PlayerMoveController _playerMoveController;

        private void Awake()
        {
            playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(playerConfig);
            _playerMoveController = new PlayerMoveController(_playerView, _playerAnimator);

        }

        private void Update()
        {
            _playerMoveController.Update();
        }

        private void FixedUpdate()
        {
            
        }
    }
}
