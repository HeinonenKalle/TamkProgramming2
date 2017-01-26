using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{ 
    public class FloorManager : MonoBehaviour {
        public Transform[] m_aFloorPrefabs;
        public Transform EnemyPrefab;
        public Transform CoinPrefab;

        public float m_fFloorStartZ;
        public float m_fFloorEndZ;
        public float m_fMinMovementSpeed;
        public float m_fMaxMovementSpeed;
        public int SafeFloorNumber;
        public float m_fMovementSpeed { get; private set; }
        public float SpeedUpAmount;
        public int MaxEnemiesOnScreen;
        public float CoinSpawnTime;
        public ParticleSystem CoinParticles;

        private int _currentEnemies;
        private float _currentCoinTimer;

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

            if (_currentEnemies < MaxEnemiesOnScreen)
            {
                if (Random.Range(0, 3) == 1)
                {
                    SpawnNewBaddie();
                }
            }

            if (_currentCoinTimer >= CoinSpawnTime)
            {
                _currentCoinTimer = 0f;
                SpawnNewCoin();
            }

            _currentCoinTimer += Time.deltaTime;
        }

        public void SpawnNewBaddie()
        {
            _currentEnemies++;
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

        public void SpawnNewCoin()
        {
            int SpawnX = SpawnXCheck();

            if (SpawnX > 2)
            {
                Debug.Log("No safe positions for coin on this floor");
                return;
            }

            Transform CoinTransform = Instantiate(CoinPrefab, new Vector3(SpawnX, 1.3f, m_fFloorStartZ), CoinPrefab.transform.rotation) as Transform;
            if (null == CoinTransform)
            {
                Debug.LogError("Unable to instantiate coin");
                return;
            }

            FloorPart coinPart = CoinTransform.GetComponent<CollectibleBehavior>();
            if (null == coinPart)
            {
                Debug.LogError("Prefab does not have a FloorPart component, unable to create the coin!");
                return;
            }

            coinPart.m_fEndZ = m_fFloorEndZ;
            coinPart.m_fMovementSpeed = m_fMovementSpeed;

            if (m_fMovementSpeed < m_fMaxMovementSpeed)
            {
                m_fMovementSpeed += SpeedUpAmount;

                if (m_fMovementSpeed > m_fMaxMovementSpeed)
                {
                    m_fMovementSpeed = m_fMaxMovementSpeed;
                }
            }

            coinPart.m_gcFloorManager = this;

            Debug.Log("Coin Spawn!");
        }

        public void PlayCoinParticles(Vector3 playPosition)
        {
            Instantiate(CoinParticles, playPosition, CoinParticles.transform.rotation);
        }

        public void ManageEnemyCount()
        {
            _currentEnemies--;

            if (_currentEnemies < 0)
            {
                _currentEnemies = 0;
            }
        }

        public int SpawnXCheck()
        {
            /*
             * RaycastHit hit;
             * if (Physics.Raycast(vPos, -Vector3.up, out hit, 3.0f))
             * {
             * Debug.DrawLine(vPos, new Vector3(vPos.x, vPos.y - 2, vPos.z), Color.green, 1, false);
             * }
             */
            RaycastHit hit;

            List<int> possibleLocations = new List<int>();

            for (int i = -2; i <= 2; i++)
            {
                if (Physics.Raycast(new Vector3(i, 1.3f, m_fFloorStartZ), Vector3.down, out hit))
                {
                    Debug.DrawRay(new Vector3(i, 1.3f, m_fFloorStartZ), Vector3.down, Color.green, 1f);
                    possibleLocations.Add(i);
                }
                else
                {
                    Debug.DrawRay(new Vector3(i, 1.3f, m_fFloorStartZ), Vector3.down, Color.red, 1f);
                }

                //Physics.Raycast(new Vector3(i, 1.3f, m_fFloorStartZ), Vector3.down);
                //Debug.DrawRay(new Vector3(i, 1.3f, m_fFloorStartZ), Vector3.down, Color.green, 5f);
            }

            int goodXLocation = 5;

            if (possibleLocations.Count == 1)
            {
                goodXLocation = possibleLocations[0];
            }
            else if (possibleLocations.Count > 1)
            {
                goodXLocation = Random.Range(0, possibleLocations.Count - 1);
            }

            Debug.Log("goodXLocation = " + goodXLocation);
            return goodXLocation;
        }
    }
}