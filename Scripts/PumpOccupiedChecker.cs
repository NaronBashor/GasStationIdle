using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpOccupiedChecker : MonoBehaviour
{
        [SerializeField] private int pumpNumber;
        [SerializeField] private int lotNumber;

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision != null)
                {
                        if (collision.CompareTag("Car"))
                        {
                                if (lotNumber == 1)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (1)").GetComponent<LotManager>().PumpOneEmpty = false;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (1)").GetComponent<LotManager>().PumpTwoEmpty = false;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (1)").GetComponent<LotManager>().PumpThreeEmpty = false;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (1)").GetComponent<LotManager>().PumpFourEmpty = false;
                                        }
                                }

                                if (lotNumber == 2)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (2)").GetComponent<LotManager>().PumpOneEmpty = false;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (2)").GetComponent<LotManager>().PumpTwoEmpty = false;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (2)").GetComponent<LotManager>().PumpThreeEmpty = false;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (2)").GetComponent<LotManager>().PumpFourEmpty = false;
                                        }
                                }

                                if (lotNumber == 3)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (3)").GetComponent<LotManager>().PumpOneEmpty = false;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (3)").GetComponent<LotManager>().PumpTwoEmpty = false;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (3)").GetComponent<LotManager>().PumpThreeEmpty = false;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (3)").GetComponent<LotManager>().PumpFourEmpty = false;
                                        }
                                }

                                if (lotNumber == 4)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (4)").GetComponent<LotManager>().PumpOneEmpty = false;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (4)").GetComponent<LotManager>().PumpTwoEmpty = false;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (4)").GetComponent<LotManager>().PumpThreeEmpty = false;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (4)").GetComponent<LotManager>().PumpFourEmpty = false;
                                        }
                                }

                                if (lotNumber == 5)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (5)").GetComponent<LotManager>().PumpOneEmpty = false;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (5)").GetComponent<LotManager>().PumpTwoEmpty = false;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (5)").GetComponent<LotManager>().PumpThreeEmpty = false;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (5)").GetComponent<LotManager>().PumpFourEmpty = false;
                                        }
                                }

                                if (lotNumber == 6)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (6)").GetComponent<LotManager>().PumpOneEmpty = false;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (6)").GetComponent<LotManager>().PumpTwoEmpty = false;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (6)").GetComponent<LotManager>().PumpThreeEmpty = false;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (6)").GetComponent<LotManager>().PumpFourEmpty = false;
                                        }
                                }
                        }
                }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
                if (collision != null)
                {
                        if (collision.CompareTag("Car"))
                        {
                                if (lotNumber == 1)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (1)").GetComponent<LotManager>().PumpOneEmpty = true;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (1)").GetComponent<LotManager>().PumpTwoEmpty = true;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (1)").GetComponent<LotManager>().PumpThreeEmpty = true;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (1)").GetComponent<LotManager>().PumpFourEmpty = true;
                                        }
                                }

                                if (lotNumber == 2)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (2)").GetComponent<LotManager>().PumpOneEmpty = true;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (2)").GetComponent<LotManager>().PumpTwoEmpty = true;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (2)").GetComponent<LotManager>().PumpThreeEmpty = true;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (2)").GetComponent<LotManager>().PumpFourEmpty = true;
                                        }
                                }

                                if (lotNumber == 3)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (3)").GetComponent<LotManager>().PumpOneEmpty = true;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (3)").GetComponent<LotManager>().PumpTwoEmpty = true;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (3)").GetComponent<LotManager>().PumpThreeEmpty = true;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (3)").GetComponent<LotManager>().PumpFourEmpty = true;
                                        }
                                }

                                if (lotNumber == 4)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (4)").GetComponent<LotManager>().PumpOneEmpty = true;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (4)").GetComponent<LotManager>().PumpTwoEmpty = true;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (4)").GetComponent<LotManager>().PumpThreeEmpty = true;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (4)").GetComponent<LotManager>().PumpFourEmpty = true;
                                        }
                                }

                                if (lotNumber == 5)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (5)").GetComponent<LotManager>().PumpOneEmpty = true;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (5)").GetComponent<LotManager>().PumpTwoEmpty = true;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (5)").GetComponent<LotManager>().PumpThreeEmpty = true;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (5)").GetComponent<LotManager>().PumpFourEmpty = true;
                                        }
                                }

                                if (lotNumber == 6)
                                {
                                        if (pumpNumber == 1)
                                        {
                                                GameObject.Find("Lot (6)").GetComponent<LotManager>().PumpOneEmpty = true;
                                        }
                                        else if (pumpNumber == 2)
                                        {
                                                GameObject.Find("Lot (6)").GetComponent<LotManager>().PumpTwoEmpty = true;
                                        }
                                        else if (pumpNumber == 3)
                                        {
                                                GameObject.Find("Lot (6)").GetComponent<LotManager>().PumpThreeEmpty = true;
                                        }
                                        else if (pumpNumber == 4)
                                        {
                                                GameObject.Find("Lot (6)").GetComponent<LotManager>().PumpFourEmpty = true;
                                        }
                                }
                        }
                }
        }
}
