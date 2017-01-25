using UnityEngine;
using System.Collections;

namespace TamkRunner
{
    public enum rotationDirection
    {
        left,
        right
    }

    public class Spin : MonoBehaviour {

        public rotationDirection DirectionToRotateIn;
        public float RotationSpeed;

	    // Use this for initialization
	    void Start () {
	
	    }
	
	    // Update is called once per frame
	    void Update () {
            Vector3 Rotation = transform.rotation.eulerAngles;

            if (DirectionToRotateIn == rotationDirection.left)
            {
                Rotation.z += RotationSpeed * Time.deltaTime;
            }
            else if (DirectionToRotateIn == rotationDirection.right)
            {
                Rotation.z -= RotationSpeed * Time.deltaTime;
            }

            transform.Rotate(new Vector3(0, 0, Rotation.z));
	    }
    }
}