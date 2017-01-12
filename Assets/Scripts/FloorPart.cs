﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class FloorPart : MonoBehaviour {

        public float m_fStartZ = 25.0f;
        public float m_fEndZ = -15.0f;
        public float m_fMovementSpeed;

        public FloorManager m_gcFloorManager;

        private Transform m_tTransform;
        private Vector3 m_vTrajectory;

        // Use this for initialization
        void Start () {
            m_tTransform = GetComponent<Transform>();
            m_tTransform.position = new Vector3(0.0f, 0.0f, m_fStartZ);
            m_vTrajectory = Vector3.zero;
            m_vTrajectory.z = -1;
        }

	    // Update is called once per frame
	    void Update () {
            m_tTransform.position += (m_vTrajectory * m_fMovementSpeed) * Time.deltaTime;
            if (m_tTransform.position.z <= m_fEndZ)
            {
                if (null != m_gcFloorManager)
                    m_gcFloorManager.SpawnNewFloor(m_tTransform.position.z - m_fEndZ);
                else
                    Debug.LogError("Floor part %s has no reference to the floor manager!");

                Destroy(gameObject);
            }
        }
    }
}
