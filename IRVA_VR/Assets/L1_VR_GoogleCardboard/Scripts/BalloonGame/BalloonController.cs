using L1_VR_GoogleCardboard.Scripts.Helpers;
using UnityEngine;

namespace L1_VR_GoogleCardboard.Scripts.BalloonGame
{
    /// <summary>
    /// Script which controls the behavior of balloon game objects.
    /// </summary>
    public class BalloonController : MonoBehaviour
    {
        
        // Extra info:
        //  --> The [SerializeField] attribute enables you to keep variables private whilst exposing their value in the editor's inspector.
        //  --> The [Range(...)] attribute is a nice way to set limits on the value of a variable & it also exposes it as a slider in the editor's inspector.
        [SerializeField] [Range(0.25f, 5f)] private float speed = 1f;
        [SerializeField] [Range(0.25f, 2f)] private float requiredTimeToPop = 0.75f;
        [SerializeField] private AudioClip popSound;
        [SerializeField] private AudioClip failSound;
        [SerializeField] private Gradient colors;
        
        private bool _isTargeted = false;
        private float _balloonPopTimeInternal = 0f;
        private MeshRenderer _balloonMeshRenderer;

        private void Awake() => _balloonMeshRenderer = GetComponent<MeshRenderer>();
        
        /// <summary>
        /// This is automatically called from 'CardboardReticlePointer' when the reticle (crosshair) raycasts the collider of this object.
        /// In short, called when the balloon is targeted.
        /// </summary>
        public void OnPointerEnter()
        {
            _isTargeted = true;
        }
        
        /// <summary>
        /// This is automatically called from 'CardboardReticlePointer' when the reticle (crosshair) ends raycasting with the collider of this object.
        /// In short, called when the balloon is not targeted anymore.
        /// </summary>
        public void OnPointerExit()
        {
            _isTargeted = false;

            _balloonPopTimeInternal = .0f;
        }
        
        private void Update()
        {
            MoveBalloon();
            UpdateBalloonTimer();
            SetBalloonColor();
        }

        private void MoveBalloon()
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime;
        }

        private void UpdateBalloonTimer()
        {
            if (_isTargeted)
            {
                _balloonPopTimeInternal += 0.01f;
            }

            if (_balloonPopTimeInternal >= requiredTimeToPop)
            {
                PopBalloon();
            }
        }
        
        private void SetBalloonColor() => _balloonMeshRenderer.material.color = colors.Evaluate(_balloonPopTimeInternal.Remap(0f, requiredTimeToPop, 0f, 1f));

        private void PopBalloon() => DestroyBalloon(hasBeenPoppedByPlayer: true);
        
        public void DestroyBalloon(bool hasBeenPoppedByPlayer)
        {
            if (hasBeenPoppedByPlayer)
            {
                ScoreController.Instance.IncrementScore(); 
            }
            else
            {
                ScoreController.Instance.DecrementScore();
            }

            PlayBalloonSound(hasBeenPoppedByPlayer);
            
            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        
        private void PlayBalloonSound(bool hasBeenPoppedByPlayer) => AudioSource.PlayClipAtPoint(hasBeenPoppedByPlayer ? popSound : failSound, transform.position);
    }
}
