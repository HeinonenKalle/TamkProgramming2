using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{ 
    public class FloorManager : MonoBehaviour {
        public Transform[] m_aFloorPrefabs;
        public Transform EnemyPrefab;

        public float m_fFloorStartZ;
        public float m_fFloorEndZ;
        public float m_fMinMovementSpeed;
        public float m_fMaxMovementSpeed;
        public int SafeFloorNumber;
        public float m_fMovementSpeed { get; private set; }
        public float SpeedUpAmount;
        

        // Use this for initialization
        void Start () {
            float fZPos = 0.0f;
            float fFloorLength = Mathf.Abs(m_fFloorStartZ) + Mathf.Abs(m_fFloorEndZ);

            Debug.Log("Floor length is: " + fFloorLength.ToString());

            m_fMovementSpeed = m_fMinMovementSpeed;

            while (fZPos > -fFloorLength)
            {
                SpawnSafeFloor(fZPos);
                fZPos -= 5.0f;
            }
        }
	
	    // Update is called once per frame
	    void Update () {
	    }

        public void SpawnSafeFloor(float fZOffset)
        {
            Transform tFloorTransform = Instantiate(m_aFloorPrefabs[0], new Vector3(0.0f, 0.0f, m_fFloorStartZ + fZOffset), Quaternion.identity) as Transform;
            if (null == tFloorTransform)
            {
                Debug.LogError("Unable to instantiate floor part");
                return;
            }

            FloorPart gcFloorPart = tFloorTransform.GetComponent<FloorPart>();
            if (null == gcFloorPart)
            {
                Debug.LogError("Prefab does not have a FloorPart component, unable to create the floor!");
                return;
            }

            gcFloorPart.m_fEndZ = m_fFloorEndZ;
            gcFloorPart.m_fStartZ = m_fFloorStartZ + fZOffset;
            gcFloorPart.m_fMovementSpeed = m_fMovementSpeed;

            gcFloorPart.m_gcFloorManager = this;
        }

        public void SpawnNewFloor(float fZOffset)
        {
            Transform tFloorTransform = Instantiate(m_aFloorPrefabs[Random.Range(0, m_aFloorPrefabs.Length - 1)], new Vector3(0.0f, 0.0f, m_fFloorStartZ + fZOffset), Quaternion.identity) as Transform;
            if (null == tFloorTransform)
            {
                Debug.LogError("Unable to instantiate floor part");
                return;
            }

            FloorPart gcFloorPart = tFloorTransform.GetComponent<FloorPart>();
            if (null == gcFloorPart)
            {
                Debug.LogError("Prefab does not have a FloorPart component, unable to create the floor!");
                return;
            }

            gcFloorPart.m_fEndZ = m_fFloorEndZ;
            gcFloorPart.m_fStartZ = m_fFloorStartZ + fZOffset;
            gcFloorPart.m_fMovementSpeed = m_fMovementSpeed;

            if (m_fMovementSpeed < m_fMaxMovementSpeed)
            {
                m_fMovementSpeed += SpeedUpAmount;

                if (m_fMovementSpeed > m_fMaxMovementSpeed)
                {
                    m_fMovementSpeed = m_fMaxMovementSpeed;
                }
            }

            gcFloorPart.m_gcFloorManager = this;

            if (Random.Range(0, 3) == 1)
            {
                SpawnNewBaddie();
            }
        }

        public void SpawnNewBaddie()
        {
            Transform EnemyTransform = Instantiate(EnemyPrefab, new Vector3(0.0f, 1.3f, m_fFloorStartZ), Quaternion.identity) as Transform;
            if (null == EnemyTransform)
            {
                Debug.LogError("Unable to instantiate enemy");
                return;
            }

            FloorPart enemyPart = EnemyTransform.GetComponent<BaddieBehavior>();
            if (null == enemyPart)
            {
                Debug.LogError("Prefab does not have a FloorPart component, unable to create the enemy!");
                return;
            }

            enemyPart.m_fEndZ = m_fFloorEndZ;
            enemyPart.m_fMovementSpeed = m_fMovementSpeed;

            if (m_fMovementSpeed < m_fMaxMovementSpeed)
            {
                m_fMovementSpeed += SpeedUpAmount;

                if (m_fMovementSpeed > m_fMaxMovementSpeed)
                {
                    m_fMovementSpeed = m_fMaxMovementSpeed;
                }
            }

            enemyPart.m_gcFloorManager = this;
        }
    }
}