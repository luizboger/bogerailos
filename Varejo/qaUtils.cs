using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geral.qaSetUp;
using Geral.qaRelCampos;

namespace qaUtils
{
    public abstract class qaUtils
    {
        public static void login(String user, String password) 
        {
            qaRelCampos.qaRelCampos.txtUserName.Click();
            qaRelCampos.qaRelCampos.txtUserName.Clear();
            qaRelCampos.qaRelCampos.txtUserName.SendKeys("locked_out_user");
            qaRelCampos.qaRelCampos.txtPassword.Clear();
            qaRelCampos.qaRelCampos.txtPassword.SendKeys("secret_sauce");
            qaRelCampos.qaRelCampos.btnLogin.Click();
        }

        public static void addItemCarrinho(int indexItem)
        {
            driver.FindElement(By.XPath("//a[@id='item_"+indexItem+"_title_link']/div")).Click();
            qaRelCampos.qaRelCampos.btnAddProduto.Click();
            qaRelCampos.qaRelCampos.btnVoltarParaProdutos.Click();
        }

        public static void removeItemCarrinho(int id)
        {
            driver.FindElement(By.XPath("//a[@id='item_"+id+"_title_link']/div")).Click();
            qaRelCampos.qaRelCampos.btnRemoveProduto.Click();
            qaRelCampos.qaRelCampos.btnVoltarParaProdutos.Click();
        }

        public static void finalizaCompra(String firstName, String lastName, String postalCode)
        {
            qaRelCampos.qaRelCampos.btnCarrinho.Click();
            qaRelCampos.qaRelCampos.btnCheckout.Click();
            qaRelCampos.qaRelCampos.txtFirstName.Click();
            qaRelCampos.qaRelCampos.txtFirstName.Clear();
            qaRelCampos.qaRelCampos.txtFirstName.SendKeys(firstName);
            qaRelCampos.qaRelCampos.txtLastName.Click();
            qaRelCampos.qaRelCampos.txtLastName.Clear();
            qaRelCampos.qaRelCampos.txtLastName.SendKeys(lastName);
            qaRelCampos.qaRelCampos.txtPostalCode.Click();
            qaRelCampos.qaRelCampos.txtPostalCode.Clear();
            qaRelCampos.qaRelCampos.txtPostalCode.SendKeys(postalCode);
            qaRelCampos.qaRelCampos.btnContinue.Click();
            qaRelCampos.qaRelCampos.btnFinish.Click();
            qaRelCampos.qaRelCampos.btnBackHome.Click();
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
            qaRelCampos.qaRelCampos.btnCarrinho.Click();
            qaRelCampos.qaRelCampos.btnCheckout.Click();
            qaRelCampos.qaRelCampos.txtFirstName.Click();
            qaRelCampos.qaRelCampos.txtFirstName.Clear();
            qaRelCampos.qaRelCampos.txtFirstName.SendKeys(firstName);
            qaRelCampos.qaRelCampos.txtLastName.Click();
            qaRelCampos.qaRelCampos.txtLastName.Clear();
            qaRelCampos.qaRelCampos.txtLastName.SendKeys(lastName);
            qaRelCampos.qaRelCampos.txtPostalCode.Click();
            qaRelCampos.qaRelCampos.txtPostalCode.Clear();
            qaRelCampos.qaRelCampos.txtPostalCode.SendKeys(postalCode);
            qaRelCampos.qaRelCampos.btnContinue.Click();
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