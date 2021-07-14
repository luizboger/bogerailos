using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qaRelCampos
{
    public abstract class qaRelCampos
    {
        //Text
        public static string txtUserName = driver.FindElement(By.Id("user-name"));
        public static string txtPassword = driver.FindElement(By.Id("password"));
        public static string txtFirstName = driver.FindElement(By.Id("first-name"));
        public static string txtLastName = driver.FindElement(By.Id("last-name"));
        public static string txtPostalCode = driver.FindElement(By.Id("postal-code"));

        //Button
        public static string btnLogin = driver.FindElement(By.Id("login-button"));
        public static string btnVoltarParaProdutos = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public static string btnAddProduto = driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public static string btnRemoveProduto = driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        public static string btnCarrinho = driver.FindElement(By.XPath("//div[@id='shopping_cart_container']/a"));
        public static string btnCheckout = driver.FindElement(By.Id("checkout"));
        public static string btnContinue = driver.FindElement(By.Id("continue"));
        public static string btnFinish = driver.FindElement(By.Id("finish"));
        public static string btnBackHome = driver.FindElement(By.Id("back-to-products"));
    }
}