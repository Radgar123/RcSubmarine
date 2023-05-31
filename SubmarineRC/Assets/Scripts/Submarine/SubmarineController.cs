using UnityEngine;

namespace Submarine
{
    public class SubmarineController :  MonoBehaviour
    {
        #region Variables
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _movementSpeedVertical;
        [SerializeField] private float _movementSpeedHorizonta;
        [SerializeField] private bool _isEngineStart;
        #endregion
        
        #region Move

        public void MoveForward()
        {
            if (_isEngineStart)
                _rigidbody.AddForce(transform.forward * _movementSpeedVertical);
        }

        public void MoveUpDown()
        {
            if (_isEngineStart)
                _rigidbody.AddForce(transform.up * _movementSpeedVertical);
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
    }
}