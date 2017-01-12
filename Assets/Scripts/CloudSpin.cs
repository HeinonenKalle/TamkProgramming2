using UnityEngine;
using System.Collections;

namespace TamkRunner
{
    public enum rotationDirection
    {
        left,
        right
    }

    public class CloudSpin : MonoBehaviour {

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
                Rotation.y += RotationSpeed * Time.deltaTime;
            }
            else if (DirectionToRotateIn == rotationDirection.right)
            {
                Rotation.y -= RotationSpeed * Time.deltaTime;
            }
            
	    }
    }
}