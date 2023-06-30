using System;
using ManagersAndControllers;
using ManagersAndControllers.Spawner;
using Radgar.Difficulty;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AI
{ 
    public class FishAI : MonoBehaviour
    {
        [SerializeField] private FishDifficulty _fishDifficulty;
        //public float swimSpeed = 2f;
        //public float changeDirectionInterval = 3f;
        //public float separationDistance = 1f;
        public float separationForce = 1f;

        private float timer;
        private Rigidbody rb;
        private Camera mainCamera;
        private float screenEdgeBuffer = 1f;

        private void OnEnable()
        {
            _fishDifficulty = FindObjectOfType<GameSpawner>()._difficulty.fishDifficulty;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Random.insideUnitSphere.normalized * _fishDifficulty.swimSpeed;
            timer = _fishDifficulty.changeDirectionInterval;
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

            if (screenPos.x < screenEdgeBuffer || screenPos.x > Screen.width - screenEdgeBuffer ||
                screenPos.y < screenEdgeBuffer || screenPos.y > Screen.height - screenEdgeBuffer)
            {
                rb.velocity = Random.insideUnitSphere.normalized * _fishDifficulty.swimSpeed;
                
                if (rb.velocity.x > 0f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(rb.velocity);
                    rb.MoveRotation(targetRotation);
                }
                else if (rb.velocity.x < 0f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(-rb.velocity);
                    rb.MoveRotation(targetRotation);
                }
            }
        }

        private void FixedUpdate()
        {
            Vector3 separationForce = ComputeSeparationForce();
            rb.AddForce(separationForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

        private Vector3 ComputeSeparationForce()
        {
            Vector3 separationForce = Vector3.zero;
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, _fishDifficulty.separationDistance);

            foreach (Collider collider in nearbyColliders)
            {
                if (collider != GetComponent<Collider>())
                {
                    Vector3 toOtherFish = collider.transform.position - transform.position;
                    float distance = toOtherFish.magnitude;
                    float separationFactor = Mathf.Max(0f, _fishDifficulty.separationDistance - distance) / 
                                             _fishDifficulty.separationDistance;

                    separationForce -= toOtherFish.normalized * separationFactor;
                }
            }

            return separationForce;
        }
    }
}