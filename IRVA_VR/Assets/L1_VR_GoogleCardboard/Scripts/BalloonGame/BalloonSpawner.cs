using System.Collections;
using DG.Tweening;
using L1_VR_GoogleCardboard.Scripts.Helpers;
using UnityEngine;

namespace L1_VR_GoogleCardboard.Scripts.BalloonGame
{
    /// <summary>
    /// Used to control the spawn behavior of balloons.
    /// </summary>
    public class BalloonSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject balloonPrefab;
        [SerializeField] [Range(0.1f, 5f)] private float spawnRate = 1.5f;

        private BoxCollider _boxCollider;

        private void Awake() => _boxCollider = GetComponent<BoxCollider>();

        private void Start() => StartCoroutine(SpawnBalloonsRoutine());

        private IEnumerator SpawnBalloonsRoutine()
        {
            for (;;)
            {
                var spawnPos = Utils.GetRandomPointInBounds(_boxCollider.bounds);
                
                if(balloonPrefab != null)
                {
                    Instantiate(balloonPrefab, spawnPos, Quaternion.identity);
                }
                else
                {
                    Debug.LogWarning("'balloonPrefab' is NULL!");
                }
                
                yield return new WaitForSeconds(spawnRate);
            }
        }
    }
}
