using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
        [SerializeField] private float totalPumps = 1;
        [SerializeField] private float pumpSpeed = 30;
        [SerializeField] private float tankAmount = 20;
        [SerializeField] private float loadGasSpeed = 25;
        [SerializeField] private float gasCapacity = 1000;

        [SerializeField] private float initialUpgradeCost = 200f;
        [SerializeField] private float upgradeCostMultiplier = 1.75f;

        [SerializeField] private int currentLot;

        [SerializeField] private GameObject upgradePanel;

        [SerializeField] private TextMeshProUGUI currentPumpsText;
        [SerializeField] private TextMeshProUGUI currentPumpSpeedText;
        [SerializeField] private TextMeshProUGUI currentTankAmountText;
        [SerializeField] private TextMeshProUGUI currentLoadGasSpeedText;
        [SerializeField] private TextMeshProUGUI currentGasCapacityText;

        [SerializeField] private TextMeshProUGUI currentLevelText;

        [SerializeField] private TextMeshProUGUI upgradeTotalPumpsText;
        [SerializeField] private TextMeshProUGUI upgradePumpSpeedText;
        [SerializeField] private TextMeshProUGUI upgradeTankAmountText;
        [SerializeField] private TextMeshProUGUI upgradeLoadGasSpeedText;
        [SerializeField] private TextMeshProUGUI upgradeGasCapacityText;

        [SerializeField] private GameObject starProgress;

        private float pumpIncrement = 1;
        private float speedMultiplier = 0.98f;
        private float tankMultiplier = 1.15f;
        private float loadSpeedMultiplier = 0.95f;
        private float capacityMultiplier = 1.05f;

        private float currentLevel = 1;

        public float CurrentLevel
        {
                get => currentLevel;
                set => currentLevel=value;
        }

        private void Start()
        {
                upgradePanel.SetActive(false);
                if (CurrentLevel != 1 && (CurrentLevel + 1) % 20 == 0)
                {
                        upgradeTotalPumpsText.text = "+ " + totalPumps.ToString();
                }
                else
                {
                        upgradeTotalPumpsText.text = "+ 0";
                }
                upgradePumpSpeedText.text = "- 2%";
                upgradeTankAmountText.text = "x 15%";
                upgradeLoadGasSpeedText.text = "- 5%";
                upgradeGasCapacityText.text = "x 5%";
        }

        private void Update()
        {
                currentPumpsText.text = totalPumps.ToString() + " / 4";
                currentPumpSpeedText.text = pumpSpeed.ToString("F2") + " sec";
                currentTankAmountText.text = "$" + tankAmount.ToString("F2") + " / car";
                currentLoadGasSpeedText.text = loadGasSpeed.ToString("F2") + " sec";
                currentGasCapacityText.text = gasCapacity.ToString("F0") + " gal";

                currentLevelText.text = "Level " + CurrentLevel.ToString();
        }

        public void Upgrade()
        {
                starProgress.GetComponent<StarProgress>().OnUpgrade();
                CurrentLevel++;
                if (CurrentLevel % 20 == 0)
                {
                        if (totalPumps < 4)
                        {
                                totalPumps += pumpIncrement;
                        }
                        else
                        {
                                Debug.Log("Max pumps purchased.");
                        }
                }
                pumpSpeed *= speedMultiplier;
                tankAmount *= tankMultiplier;
                loadGasSpeed *= loadSpeedMultiplier;
                gasCapacity *= capacityMultiplier;

                if ((CurrentLevel + 1) % 20 == 0)
                {
                        upgradeTotalPumpsText.text = "+ 1";
                }
                else
                {
                        upgradeTotalPumpsText.text = "+ 0";
                }
        }

        public void OpenPanel()
        {
                upgradePanel.SetActive(true);
        }

        public void ClosePanel()
        {
                upgradePanel.SetActive(false);
        }
}
