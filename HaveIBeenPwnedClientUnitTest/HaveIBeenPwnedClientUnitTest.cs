using System.Collections.Generic;
using System.Threading.Tasks;
using HaveIBeenPwned.Client;
using HaveIBeenPwned.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaveIBeenPwnedClientUnitTest
{
    [TestClass]
    public class HaveIBeenPwnedClientUnitTest
    {
        [TestMethod]
        public async Task GetBreach_WhenCalledWithBreachedSite_ReturnsBreachDetails()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            Breach breach = await client.GetBreach("Adobe");

            // Assert
            Assert.AreEqual("Adobe", breach.Name);
            Assert.AreEqual("In October 2013, 153 million Adobe accounts were breached with each containing an internal ID, username, email, <em>encrypted</em> password and a password hint in plain text. The password cryptography was poorly done and <a href=\"http://stricture-group.com/files/adobe-top100.txt\" target=\"_blank\" rel=\"noopener\">many were quickly resolved back to plain text</a>. The unencrypted hints also <a href=\"http://www.troyhunt.com/2013/11/adobe-credentials-and-serious.html\" target=\"_blank\" rel=\"noopener\">disclosed much about the passwords</a> adding further to the risk that hundreds of millions of Adobe customers already faced.", breach.Description);
        }

        [TestMethod]
        public async Task GetBreach_WhenCalledWithUnknownSite_ReturnsNull()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            Breach breach = await client.GetBreach("DOES NOT EXIST");

            // Assert
            Assert.IsNull(breach);
        }

        [TestMethod]
        public async Task GetAllBreaches_WhenCalled_ReturnsAllBreaches()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            List<Breach> breaches = await client.GetAllBreaches();

            // Assert
            Assert.IsTrue(breaches.Count >= 365);
        }

        [TestMethod]
        public async Task GetAccountBreaches_WhenCalledWithBreachedAccount_ReturnsBreaches()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            List<Breach> breaches = await client.GetAccountBreaches("test@test.com");

            // Assert
            Assert.IsTrue(breaches.Count >= 1);
        }

        [TestMethod]
        public async Task GetAccountBreaches_WhenCalledWithUnknownAccount_ReturnsNull()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            List<Breach> breaches = await client.GetAccountBreaches("thisemailaddressdoesnotexist@test.com");

            // Assert
            Assert.IsNull(breaches);
        }

        [TestMethod]
        public async Task IsPasswordPwned_WhenCalledWithPwnedPassword_ReturnsTrue()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            bool isPwnedPassword = await client.IsPasswordPwned("password123");

            // Assert
            Assert.IsTrue(isPwnedPassword);
        }

        [TestMethod]
        public async Task IsPasswordPwned_WhenCalledWithSecurePassword_ReturnsFalse()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            bool isPwnedPassword = await client.IsPasswordPwned("AV3ryLongS3cureP4ssw0rd(H0p3fully)");

            // Assert
            Assert.IsFalse(isPwnedPassword);
        }

        [TestMethod]
        public async Task GetPasteAccount_WhenCalledWithBreachedAccount_ReturnsPastes()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            List<Paste> pastes = await client.GetPasteAccount("test@test.com");

            // Assert
            Assert.IsTrue(pastes.Count >= 1);
        }

        [TestMethod]
        public async Task GetPasteAccount_WhenCalledWithUnknownAccount_ReturnsNull()
        {
            // Arrange
            IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();

            // Act
            List<Paste> pastes = await client.GetPasteAccount("thisemailaddressdoesnotexist@test.com");

            // Assert
            Assert.IsNull(pastes);
        }
    }
}