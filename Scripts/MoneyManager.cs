using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
        private int moneyTotal;

        public void AddMoney(int amount)
        {
                moneyTotal += amount;
        }

        public void RemoveMoney(int amount)
        {
                moneyTotal -= amount;
        }
}
