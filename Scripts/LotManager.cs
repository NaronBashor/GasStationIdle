using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotManager : MonoBehaviour
{
        #region Inspector

        [SerializeField] private GameObject pumpSprite;

        [SerializeField] private Transform pumpOneLocation;
        [SerializeField] private Transform pumpTwoLocation;
        [SerializeField] private Transform pumpThreeLocation;
        [SerializeField] private Transform pumpFourLocation;

        public List<Sprite> lots = new List<Sprite>();

        public bool lotFull = false;

        public bool pumpOneEmpty = true;
        public bool pumpTwoEmpty = true;
        public bool pumpThreeEmpty = true;
        public bool pumpFourEmpty = true;

        private bool secondPumpUnlocked = false;
        private bool thirdPumpUnlocked = false;
        private bool fourthPumpUnlocked = false;

        int index = 0;

        #endregion

        #region Properties

        public bool LotFull
        {
                get => lotFull;
                set => lotFull=value;
        }
        public bool PumpOneEmpty
        {
                get => pumpOneEmpty;
                set => pumpOneEmpty=value;
        }
        public bool PumpTwoEmpty
        {
                get => pumpTwoEmpty;
                set => pumpTwoEmpty=value;
        }
        public bool PumpThreeEmpty
        {
                get => pumpThreeEmpty;
                set => pumpThreeEmpty=value;
        }
        public bool PumpFourEmpty
        {
                get => pumpFourEmpty;
                set => pumpFourEmpty=value;
        }
        public Transform PumpOneLocation
        {
                get => pumpOneLocation;
                set => pumpOneLocation=value;
        }
        public Transform PumpTwoLocation
        {
                get => pumpTwoLocation;
                set => pumpTwoLocation=value;
        }
        public Transform PumpThreeLocation
        {
                get => pumpThreeLocation;
                set => pumpThreeLocation=value;
        }
        public Transform PumpFourLocation
        {
                get => pumpFourLocation;
                set => pumpFourLocation=value;
        }
        public bool SecondPumpUnlocked
        {
                get => secondPumpUnlocked;
                set => secondPumpUnlocked=value;
        }
        public bool ThirdPumpUnlocked
        {
                get => thirdPumpUnlocked;
                set => thirdPumpUnlocked=value;
        }
        public bool FourthPumpUnlocked
        {
                get => fourthPumpUnlocked;
                set => fourthPumpUnlocked=value;
        }

        #endregion

        private void Start()
        {
                pumpSprite.GetComponent<SpriteRenderer>().sprite = lots[index];
        }

        private void Update()
        {
                // Control if lot is full or not automatically
                if (pumpOneEmpty || pumpTwoEmpty || pumpThreeEmpty || pumpFourEmpty)
                {
                        lotFull = false;
                }
                else
                {
                        lotFull = true;
                }

                if (!SecondPumpUnlocked && !pumpOneEmpty)
                {
                        lotFull = true;
                }
                else if (!ThirdPumpUnlocked && !pumpOneEmpty && !pumpTwoEmpty)
                {
                        lotFull = true;
                }
                else if (!FourthPumpUnlocked && !pumpThreeEmpty && !pumpTwoEmpty && !pumpOneEmpty)
                {
                        lotFull = true;
                }
        }

        public void UpgradeLot()
        {
                switch (index)
                {
                        case 0:
                        SecondPumpUnlocked = true;
                        break;

                        case 1:
                        ThirdPumpUnlocked = true;
                        break;

                        case 2:
                        FourthPumpUnlocked = true;
                        break;
                }
                index++;
                if (index == 4 || index == 5)
                {
                        pumpSprite.transform.localScale = new Vector3(0.325f , 0.3f , 1);
                }
                pumpSprite.GetComponent<SpriteRenderer>().sprite = lots[index];
        }
}
