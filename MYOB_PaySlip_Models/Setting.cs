using System;
using System.Configuration;

namespace MYOB_PaySlip_Models
{
    public class Setting
    {
        private static Setting _instance;

        private Setting()
        {
        }

        public static Setting Instance
        {
            get { return _instance ?? (_instance = new Setting()); }
        }

        //Zero Slab
        public double SlabZeroLowerVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabZeroLowerVal"]); }
        }

        public double SlabZeroUpperVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabZeroUpperVal"]); }
        }

        public double SlabZeroExemptIncome
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabZeroExemptIncome"]); }
        }

        public double SlabZeroTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabZeroTax"]); }
        }

        public double SlabZeroBaseTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabZeroBaseTax"]); }
        }

        //First Slab

        public double SlabOneLowerVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabOneLowerVal"]); }
        }

        public double SlabOneUpperVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabOneUpperVal"]); }
        }

        public double SlabOneExemptIncome
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabOneExemptIncome"]); }
        }

        public double SlabOneTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabOneTax"]); }
        }

        public double SlabOneBaseTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabOneBaseTax"]); }
        }

        //Slab Two
        public double SlabTwoLowerVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabTwoLowerVal"]); }
        }

        public double SlabTwoUpperVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabTwoUpperVal"]); }
        }

        public double SlabTwoExemptIncome
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabTwoExemptIncome"]); }
        }

        public double SlabTwoTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabTwoTax"]); }
        }

        public double SlabTwoBaseTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabTwoBaseTax"]); }
        }

        //Slab Three
        public double SlabThreeLowerVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabThreeLowerVal"]); }
        }

        public double SlabThreeUpperVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabThreeUpperVal"]); }
        }

        public double SlabThreeExemptIncome
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabThreeExemptIncome"]); }
        }

        public double SlabThreeTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabThreeTax"]); }
        }

        public double SlabThreeBaseTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabThreeBaseTax"]); }
        }

        //Slab Four
        public double SlabFourLowerVal
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabFourLowerVal"]); }
        }

        public double SlabFourUpperVal
        {
            get
            {
                return ConfigurationManager.AppSettings["SlabFourUpperVal"].Equals("Maximum",
                    StringComparison.OrdinalIgnoreCase)
                    ? double.MaxValue
                    : double.Parse(ConfigurationManager.AppSettings["SlabFourUpperVal"]);
            }
        }

        public double SlabFourExemptIncome
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabFourExemptIncome"]); }
        }

        public double SlabFourTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabFourTax"]); }
        }

        public double SlabFourBaseTax
        {
            get { return double.Parse(ConfigurationManager.AppSettings["SlabFourBaseTax"]); }
        }
    }
}