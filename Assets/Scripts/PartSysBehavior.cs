using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamkRunner
{
    public class PartSysBehavior : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        // Use this for initialization
        void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            if(!_particleSystem.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}