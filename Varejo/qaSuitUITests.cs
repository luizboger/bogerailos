using NUnit.Framework;
using Geral.qaSetUp;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using qaUtils.qaUtils;

namespace qaTelaLoginUI
{
    [TestFixture]
    class qaTelaLoginUI : qaSetup
    {
        [Test]
        public void ExecutarDriver()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void testLoginUsuarioBloqueado()
        {
            qaUtils.qaUtils.login("locked_out_user", "secret_sauce");
            Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", driver.FindElement(By.XPath("//div[@id='login_button_container']/div/form/div[3]/h3")).getText());
        }

        public void testCompraItensCompleta()
        {
            qaUtils.qaUtils.addItemCarrinho(0);
            qaUtils.qaUtils.addItemCarrinho(4);
            qaUtils.qaUtils.addItemCarrinho(1);
            qaUtils.qaUtils.RemoveItemCarrinho(1);
            qaUtils.qaUtils.finalizaCompra("Teste", "Boger", "89010-001");
        }
        
        public void testCompraSemItens()
        {
            qaUtils.qaUtils.finalizaCompra("Teste", "Boger", "89010-001");
            qaUtils.qaUtils.finalizaCompra("Teste", "Boger", "89010-001");
        }

        public void testValidaValorTodosItens()
        {
            qaUtils.qaUtils.addTodosProdutos();
            qaUtils.qaUtils.validaValorFinal();
        }
    }
}