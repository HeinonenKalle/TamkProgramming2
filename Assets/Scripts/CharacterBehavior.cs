using UnityEngine;
using System.Collections;

namespace TamkRunner
{
    public class CharacterBehavior : MonoBehaviour {

        public float MoveSpeed;
        public float JumpSpeed;
        public float Gravity;

        private CharacterController _characterController;
        private Vector3 _moveDirection = Vector3.zero;
        private Vector3 _startPosition;

	    // Use this for initialization
	    void Start () {
            _startPosition = transform.position;
            _characterController = GetComponent<CharacterController>();
	    }
	
	    // Update is called once per frame
	    void Update () {
            if (_characterController.isGrounded)
            {
                _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                _moveDirection = transform.TransformDirection(_moveDirection);
                _moveDirection *= MoveSpeed;

                if (Input.GetKey(KeyCode.Space))
                {
                    _moveDirection.y = JumpSpeed;
                }
            }
            _moveDirection.y -= Gravity * Time.deltaTime;
            _characterController.Move(_moveDirection * Time.deltaTime);

            if (transform.position.y <= -2)
            {
                transform.position = _startPosition;
            }
        }
    }
}