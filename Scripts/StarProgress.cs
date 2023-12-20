using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarProgress : MonoBehaviour
{
        [SerializeField] private Sprite fullStar;
        [SerializeField] private Sprite emptyStar;

        public Image starOne;
        public Image starTwo;
        public Image starThree;
        public Image starFour;
        public Image starFive;

        [SerializeField] private GameObject upgradeManager;
        [SerializeField] private UnityEngine.UI.Slider slider;

        private float value;

        private void Start()
        {
                value = ((upgradeManager.GetComponent<UpgradeManager>().CurrentLevel) / 100);
                slider.value = value;
        }

        public void OnUpgrade()
        {
                value = ((upgradeManager.GetComponent<UpgradeManager>().CurrentLevel) / 100);
                slider.value = value;
                if (slider.value >= 0.20)
                {
                        starOne.sprite = fullStar;
                }
                if (slider.value >= 0.40)
                {
                        starTwo.sprite = fullStar;
                }
                if (slider.value >= 0.60)
                {
                        starThree.sprite = fullStar;
                }
                if (slider.value >= 0.80)
                {
                        starFour.sprite = fullStar;
                }
                if (slider.value >= 1)
                {
                        starFive.sprite = fullStar;
                }
        }
}
