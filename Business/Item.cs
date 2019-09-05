using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Item
    {
        private string itemName;
        private string unit;
        private decimal cost;
        private string itemType;
        private string provider;

        public string ItemName
        {
            get { return itemName; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Input. Please check all information has been entered.");
                }
                else
                {
                    itemName = value;
                }
            }
        }

        public string Unit
        {
            get { return unit; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Input. Please check all information has been entered.");
                }
                else
                {
                    unit = value;
                }
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentException("Invalid Input. Please check all information has been entered.");
                }
                else
                {
                    cost = value;
                }
            }
        }

        public string ItemType
        {
            get { return itemType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Input. Please check all information has been entered.");
                }
                else
                {
                    itemType = value;
                }
            }
        }

        public string Provider
        {
            get { return provider; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Input. Please check all information has been entered.");
                }
                else
                {
                    provider = value;
                }
            }
        }
    }
}
