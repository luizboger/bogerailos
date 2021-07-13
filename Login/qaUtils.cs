using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geral.qaSetUp;

namespace qaUtils
{
    public abstract class qaUtils
    {
        public static string txtUserName = driver.FindElement(By.Id("user-name"));
        public static string txtPassword = driver.FindElement(By.Id("password"));
        public static string txtFirstName = driver.FindElement(By.Id("first-name"));
        public static string txtLastName = driver.FindElement(By.Id("last-name"));
        public static string txtPostalCode = driver.FindElement(By.Id("postal-code"));
        public static string btnLogin = driver.FindElement(By.Id("login-button"));
        public static string btnVoltarParaProdutos = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public static string btnAddProduto = driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public static string btnRemoveProduto = driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        public static string btnCarrinho = driver.FindElement(By.XPath("//div[@id='shopping_cart_container']/a"));
        public static string btnCheckout = driver.FindElement(By.Id("checkout"));
        public static string btnContinue = driver.FindElement(By.Id("continue"));
        public static string btnFinish = driver.FindElement(By.Id("finish"));
        public static string btnBackHome = driver.FindElement(By.Id("back-to-products"));

        public static void login(String user, String password) 
        {
            txtUserName.Click();
            txtUserName.Clear();
            txtUserName.SendKeys("locked_out_user");
            txtPassword.Clear();
            txtPassword.SendKeys("secret_sauce");
            btnLogin.Click();
        }

        public static void addItemCarrinho(int indexItem)
        {
            driver.FindElement(By.XPath("//a[@id='item_"+indexItem+"_title_link']/div")).Click();
            btnAddProduto.Click();
            btnVoltarParaProdutos.Click();
        }

        public static void removeItemCarrinho(int id)
        {
            driver.FindElement(By.XPath("//a[@id='item_"+id+"_title_link']/div")).Click();
            btnRemoveProduto.Click();
            btnVoltarParaProdutos.Click();
        }

        public static void finalizaCompra(String firstName, String lastName, String postalCode)
        {
            btnCarrinho.Click();
            btnCheckout.Click();
            txtFirstName.Click();
            txtFirstName.Clear();
            txtFirstName.SendKeys(firstName);
            txtLastName.Click();
            txtLastName.Clear();
            txtLastName.SendKeys(lastName);
            txtPostalCode.Click();
            txtPostalCode.Clear();
            txtPostalCode.SendKeys(postalCode);
            btnContinue.Click();
            btnFinish.Click();
            btnBackHome.Click();
        }

        public static void addTodosProdutos()
        {
            int id = 0;
            while(existsElement(id))
            {
                addItemCarrinho(id);
            }
        }

        public static void validaValorFinal()
        {
            
            btnCarrinho.Click();
            btnCheckout.Click();
            txtFirstName.Click();
            txtFirstName.Clear();
            txtFirstName.SendKeys(firstName);
            txtLastName.Click();
            txtLastName.Clear();
            txtLastName.SendKeys(lastName);
            txtPostalCode.Click();
            txtPostalCode.Clear();
            txtPostalCode.SendKeys(postalCode);
            btnContinue.Click();
            String textoElement = driver.findElement(By.xpath("html/body/div[1]/div/div[4]/article/div[1]/div/header/div[1]/h1\n")).getText();
            Assert.AreEqual("140.34", textoElement);
        }

        public static Boolean existsElement(String id)
        {
            try{
                driver.FindElement(By.XPath("//a[@id='item_"+id+"_title_link']/div"));
            } catch (NoSuchElementException e) {
                return false;
            }
            return true;
        }
    }
}