using Managers;
using System;
using System.Collections;
using TMPro;
using Type;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{

    public class LevelPanelController : MonoBehaviour
    {
        [SerializeField]
        private UIManager manager;

        [SerializeField]
        private TextMeshProUGUI gold;

        [SerializeField]
        private TextMeshProUGUI deadCount;

        [SerializeField]
        private Image image;


        internal void InitGoldScore(int value)
        {

            gold.text = value.ToString();

            image.fillAmount = 100;
        }

        internal void PrintHealth(float health)
        {
            image.fillAmount = health;
        }

        internal void InitDeathScore(int value)
        {
            deadCount.text = value.ToString();
        }
    }
}