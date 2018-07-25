using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class Account
    {
        int accountId; //private access modifier
        string customerName;
        string accountType;
        int totalAmount;
        public Account()  //default constructor
        {
            accountId = 0;
            totalAmount=0;
            customerName="";
            accountType="";
        }
        public int displayAccountId() //public access modifier
        {
            return accountId;
        }
        public void inputAccountId(int accountId) //call by value method
        {
            this.accountId = accountId;
        }
        public string displayCustomerName()
        {
            return customerName;
        }
        public void inputCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string displayAccountType()
        {
            return accountType;
        }
        public void inputAccountType(string accountType)
        {
            this.accountType = accountType;
        }
        public void SetWithdrawAmount(int amount)
        {
            totalAmount = amount;
        }
        public int displayTotalAmount()
        {
            return totalAmount;
        }
        public void inputTotalAmount(int totalAmount)
        {
            this.totalAmount += totalAmount;
        }
       
    }
}


