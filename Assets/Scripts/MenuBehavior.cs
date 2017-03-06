using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TamkRunner
{
    public class MenuBehavior : MonoBehaviour
    {
        MainMenu_In menuStateObject;

        public Camera MainCamera;

        public List<Image> Dickbutts;

        Color StartColor;
        Color EndColor;

        public float m_fEventTime;
        public float m_fLerpDuration = 0.5f;

        void Awake()
        {
            m_fEventTime = Time.time;

            menuStateObject = GameObject.Find("MainMenu_In").GetComponent<MainMenu_In>();
            StartColor = new Color(Random.value, Random.value, Random.value);
            EndColor = new Color(Random.value, Random.value, Random.value);
        }

        void Update()
        {
            float fRatio = (Time.time - m_fEventTime) / m_fLerpDuration;

            Color rng = Color.Lerp(StartColor, EndColor, fRatio);

            foreach (Image dickbutt in Dickbutts)
            {
                dickbutt.color = rng;
            }

            MainCamera.backgroundColor = rng;

            if (fRatio >= 1.0f)
            {
                StartColor = EndColor;
                EndColor = new Color(Random.value, Random.value, Random.value);
                m_fEventTime = Time.time;
            }
        }

        public void StartGameButton()
        {
            menuStateObject.ChangeScene();
        }

        public void ExitGameButton()
        {
            Application.Quit();
        }
    }
}
