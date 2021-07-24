using UnityEngine;

namespace HappyInvaders
{

    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig playerConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelView _playerView;
        private SpriteAnimatorController _playerAnimator;

        private void Awake()
        {
            playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(playerConfig);
            _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, _animationSpeed);
        }

        private void Update()
        {
            _playerAnimator.Update();
        }

        private void FixedUpdate()
        {
            
        }
    }
}
