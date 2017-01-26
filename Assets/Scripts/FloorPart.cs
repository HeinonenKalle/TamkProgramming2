using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public enum ObjectType
    {
        Floor,
        Enemy
    }

    public class FloorPart : MonoBehaviour {

        public ObjectType identity;

        public float m_fStartZ = 25.0f;
        public float m_fEndZ = -15.0f;
        public float m_fMovementSpeed;

        public FloorManager m_gcFloorManager;

        private Transform m_tTransform;
        private Vector3 m_vTrajectory;

        // Use this for initialization
        protected void Start () {
            m_tTransform = GetComponent<Transform>();
            m_tTransform.position = new Vector3(0.0f, 0.0f, m_fStartZ);
            m_vTrajectory = Vector3.zero;
            m_vTrajectory.z = -1;
        }

	    // Update is called once per frame
	    void Update ()
        {
            Move();
            DeathCheck(identity);
            SpeedCheck();
        }

        public void SpeedCheck()
        {
            m_fMovementSpeed = m_gcFloorManager.m_fMovementSpeed;
        }

        public void DeathCheck(ObjectType identity)
        {
            if (transform.position.z <= m_fEndZ)
            {
                /*if (null != m_gcFloorManager && identity == ObjectType.Floor)
                    m_gcFloorManager.SpawnNewFloor(m_tTransform.position.z - m_fEndZ);
                else if (null != m_gcFloorManager && identity == ObjectType.Enemy)
                    m_gcFloorManager.SpawnNewFloor(m_tTransform.position.z - m_fEndZ);
                else
                    Debug.LogError("No reference to the floor manager!");*/

                if (null != m_gcFloorManager && identity == ObjectType.Floor)
                {
                    m_gcFloorManager.SpawnNewFloor(m_tTransform.position.z - m_fEndZ);
                }
                else if (null != m_gcFloorManager && identity == ObjectType.Enemy)
                {
                    m_gcFloorManager.SpawnNewFloor(m_tTransform.position.z - m_fEndZ);
                    m_gcFloorManager.ManageEnemyCount();
                }
                else
                {
                    Debug.LogError("No reference to the floor manager!");
                }

                Destroy(gameObject);
            }
        }

        public void Move()
        {
            transform.position += (m_vTrajectory * m_fMovementSpeed) * Time.deltaTime;
        }
    }
}
