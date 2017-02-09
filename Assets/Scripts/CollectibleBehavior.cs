using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class CollectibleBehavior : FloorPart
    {
        new protected void Start()
        {
            base.Start();
        }

        void Update()
        {
            Move();
            SpeedCheck();
            transform.position = new Vector3(transform.position.x, 1.23f, transform.position.z);
            DeathCheck(identity);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_gcFloorManager.PlayCoinParticles(transform.position);
                GameGlobals.Instance.ChangeTextValue(GameGlobals.TextName.Coins, 1);
                Destroy(gameObject);
            }
        }
    }
}