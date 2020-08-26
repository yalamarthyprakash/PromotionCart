using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PromotionCart
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please give unit price for item A");
            if (int.TryParse(Console.ReadLine(), out int priceForItemA))
            {
                Console.WriteLine("Unit Price for A is : " + priceForItemA);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            Console.WriteLine("Please give unit price for item B");
            if (int.TryParse(Console.ReadLine(), out int priceForItemB))
            {
                Console.WriteLine("Unit Price for B is : " + priceForItemB);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            Console.WriteLine("Please give unit price for item C");
            if (int.TryParse(Console.ReadLine(), out int priceForItemC))
            {
                Console.WriteLine("Unit Price for C is : " + priceForItemC);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            Console.WriteLine("Please give unit price for item D");
            if (int.TryParse(Console.ReadLine(), out int priceForItemD))
            {
                Console.WriteLine("Unit Price for D is : " + priceForItemD);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            Console.WriteLine("Set Active Promotions");
            Console.WriteLine("For how many units of itemA you want to set promotion?");
            if (int.TryParse(Console.ReadLine(), out int unitsForItemA))
            {
                Console.WriteLine("Set promotional price for item A");
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            if (int.TryParse(Console.ReadLine(), out int promotionalpriceForItemA))
            {
                Console.WriteLine("Promotional price for {0} units of A is {1}", unitsForItemA, promotionalpriceForItemA);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            int totalpriceForItemA = 0;
            if (unitsForItemA > 0 && priceForItemA >= 0 && promotionalpriceForItemA >= 0)
            {
                totalpriceForItemA = CalculatePriceForNUnits(unitsForItemA, priceForItemA, promotionalpriceForItemA, 'A');
            }

            Console.WriteLine("For how many units of itemB you want to set promotion?");
            if (int.TryParse(Console.ReadLine(), out int unitsForItemB))
            {
                Console.WriteLine("Set promotional price for item B");
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            if (int.TryParse(Console.ReadLine(), out int promotionalpriceForItemB))
            {
                Console.WriteLine("Promotional price for {0} units of B is {1}", unitsForItemB, promotionalpriceForItemB);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            int totalpriceForItemB = 0;
            if (unitsForItemB > 0 && priceForItemB >= 0 && promotionalpriceForItemB >= 0)
            {
                totalpriceForItemB = CalculatePriceForNUnits(unitsForItemB, priceForItemB, promotionalpriceForItemB, 'B');
            }

            Console.WriteLine("Set promotional price for item C and D");
            int totalpriceForItemCAndD = 0;
            if (int.TryParse(Console.ReadLine(), out int promotionalpriceForItemCAndD))
            {
                if (priceForItemC + priceForItemD > promotionalpriceForItemCAndD)
                {
                    totalpriceForItemCAndD = CalculateTotalPriceForItemCAndDUnits(priceForItemC, priceForItemD, promotionalpriceForItemCAndD);
                }
                else
                {
                    Console.WriteLine("given wrong input");
                }
            }
            int totalprice = totalpriceForItemA + totalpriceForItemB + totalpriceForItemCAndD;
            Console.WriteLine("total amount " + totalprice);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
        private static int CalculatePriceForNUnits(int unitsForSKU, int priceForSKU, int promotionalPriceForSKU, char SKU)
        {
            //Calculates price for 'n' units for itemA and itemB
            int promotionalNUnits = 0;
            Console.WriteLine("Please give total no of units for {0}", SKU);
            if (int.TryParse(Console.ReadLine(), out int totalUnitsForSKU))
            {
                promotionalNUnits = totalUnitsForSKU / unitsForSKU;
            }
            int normalUnits = totalUnitsForSKU % unitsForSKU;
            int totalPrice = (promotionalNUnits * promotionalPriceForSKU) + (normalUnits * priceForSKU);
            return totalPrice;
        }

        private static int CalculateTotalPriceForItemCAndDUnits(int priceForItemC, int priceForItemD, int promotionalPriceForSKU)
        {
            //Calculates price for items C and D
            int totalUnitsForC = 0;
            int totalUnitsForD = 0;
            int totalPriceForItemCAndD = 0;
            int unitCount = 0;
            Console.WriteLine("Please give total no of units for C");
            int.TryParse(Console.ReadLine(), out totalUnitsForC);
            Console.WriteLine("Please give total no of units for D");
            int.TryParse(Console.ReadLine(), out totalUnitsForD);
            if (totalUnitsForC == totalUnitsForD)
            {
                totalPriceForItemCAndD = totalUnitsForC * promotionalPriceForSKU;
            }
            else if (totalUnitsForC < totalUnitsForD)
            {
                if (totalUnitsForC == 1)
                {
                    totalPriceForItemCAndD = priceForItemD * (totalUnitsForD - 1) + promotionalPriceForSKU;
                }
                else if (totalUnitsForC == 0)
                {
                    totalPriceForItemCAndD = totalUnitsForD * priceForItemD;
                }
                else
                {
                    unitCount = totalUnitsForD % totalUnitsForC;
                    totalPriceForItemCAndD = unitCount * priceForItemD + totalUnitsForC * promotionalPriceForSKU;
                }
            }
            else
            {
                if (totalUnitsForD == 1)
                {
                    totalPriceForItemCAndD = priceForItemC * (totalUnitsForC - 1) + promotionalPriceForSKU;
                }
                else if (totalUnitsForD == 0)
                {
                    totalPriceForItemCAndD = totalUnitsForC * priceForItemC;
                }
                else
                {
                    unitCount = totalUnitsForC % totalUnitsForD;
                    totalPriceForItemCAndD = unitCount * priceForItemC + totalUnitsForD * promotionalPriceForSKU;
                }
            }
            return totalPriceForItemCAndD;
        }
        private static void KeyToExit()
        {
            throw new ArgumentException("Given value is not integer");
        }
    }
}
