using System;

namespace Net_Salart_Calc
{
    class Program
    {
        public const int LowestTaxableAmount = 1000;//imagiaria Dolars (IDR)
        public const int MAXContributions = 3000;//contributions never apply to amounts higher then given value
        public const int SocialContributionsPercent = 15;//Social contributions % value
        public const int IncomTax = 10;//Income tax Value
        static void Main(string[] args)
        {
            Console.WriteLine("Please Input Gross Salary Value");
            string GrossINput = Console.ReadLine();
            int GrossValue = Convert.ToInt32(GrossINput);
            if (GrossValue >= LowestTaxableAmount)//Income is same or higher then Taxable amount defined.
            {
                int TaxValue = Convert.ToInt32(Math.Round(((decimal)IncomTax / 100) * GrossValue, 0));

                Console.WriteLine("Salary After Incom Tax Of : " + IncomTax + "% Is: " + TaxValue);
                GrossValue = GrossValue - TaxValue;//update
                int SociCon = 0;
                if (GrossValue <= MAXContributions)
                {
                    SociCon = Convert.ToInt32(Math.Round(((decimal)SocialContributionsPercent / 100) * GrossValue, 0));
                    Console.WriteLine("Salary After Social Contributions Of : " + SocialContributionsPercent + "% Is: " + SociCon);
                    GrossValue = GrossValue - SociCon;
                }
                else Console.WriteLine("Contributions Do Not Applly");                
                Console.WriteLine("Total Tax Amount : " + (TaxValue + SociCon));
                Console.WriteLine("Final Pay : " + GrossValue);
            }
            else
            {
                Console.WriteLine("Net Income: " + GrossValue);
            }
        }
    }
}
//new taxes could be added to the system by either changed the constant defiend variables at the top of the class.
//or to further add more tax calculation, the same principle can be used, add a new Constant
//and simply follow the same rules for working out the % (defined constant /Devided by 100 ) and multiplioed by the "GrossValue"