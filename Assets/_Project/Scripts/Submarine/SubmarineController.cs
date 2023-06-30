using System;
using UnityEngine;

namespace Submarine
{
    public class SubmarineController :  MonoBehaviour
    {
        #region Variables
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _submarineModel;
        [SerializeField] private float _movementSpeedVertical;
        [SerializeField] private float _movementSpeedHorizonta;
        [SerializeField] private bool _isEngineStart;
        [SerializeField] private float _padding = 1f; 
        #endregion
        
        #region Move

        private void Update()
        {
            ClampPositionsToBounds();
        }

        public void MoveForward()
        {
            if (_isEngineStart)
            {
                _rigidbody.AddForce(-transform.right * _movementSpeedVertical);
                if (_submarineModel)
                {
                    _submarineModel.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                }
            }
                
        }
        
        public void MoveBackward()
        {
            if (_isEngineStart)
                _rigidbody.AddForce(transform.right * _movementSpeedVertical);
            
            if (_submarineModel)
            {
                _submarineModel.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
        }

        public void MoveUp()
        {
            if (_isEngineStart)
                _rigidbody.AddForce(transform.up * _movementSpeedVertical);
        }
        
        public void MoveDown()
        {
            if (_isEngineStart)
                _rigidbody.AddForce(-transform.up * _movementSpeedVertical);
        }

        #endregion

        #region EngineStart

        public void EngineStart()
        {
            if (_isEngineStart) {
                _isEngineStart = false;
                StopSubmarine();
            } else
            {
                _isEngineStart = true;
            }
        }

        #endregion

        #region Stop

        public void StopSubmarine()
        {
            _rigidbody.velocity = new Vector3(0, 0, 0);
        }

        #endregion

        #region CollisionAndTriggers

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Interectable.Interectable>())
            {
                collision.gameObject.GetComponent<Interectable.Interectable>().Interact();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }
        
        private void ClampPositionsToBounds()
        {
            Vector3 clampedPosition = transform.position;
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            
            if (viewportPosition.x < 0f)
            {
                clampedPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(0f, viewportPosition.y, viewportPosition.z)).x + _padding;
            }
            else if (viewportPosition.x > 1f)
            {
                clampedPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(1f, viewportPosition.y, viewportPosition.z)).x - _padding;
            }

            if (viewportPosition.y < 0f)
            {
                clampedPosition.y = Camera.main.ViewportToWorldPoint(new Vector3(viewportPosition.x, 0f, viewportPosition.z)).y + _padding;
            }
            else if (viewportPosition.y > 1f)
            {
                clampedPosition.y = Camera.main.ViewportToWorldPoint(new Vector3(viewportPosition.x, 1f, viewportPosition.z)).y - _padding;
            }

            transform.position = clampedPosition;
        }


        #endregion
    }
}