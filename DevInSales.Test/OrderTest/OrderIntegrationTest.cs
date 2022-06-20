using DevInSales.Test.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Test.OrderTest
{
    public class OrderIntegrationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task RetornoEndPoint()
        {
            OrderFactory factory = new OrderFactory();

            // given

            var client = factory.CreateClient();

            // when

            var response = await client.GetAsync("/api/order/user/1/order");

            // then

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Unauthorized));
        }

        [Test]
        public async Task PermissionamentoGet()
        {
            OrderFactory factory = new OrderFactory();
            var client = factory.CreateClient();
            var clientAdmin = factory.CreateClient();
            var clientGerente = factory.CreateClient();
            var clientUsuario = factory.CreateClient();

            // given

            var tokenAdmin = TokenGenerator.GenerateToken(Security.EProfileType.Admin);
            var tokenGerente = TokenGenerator.GenerateToken(Security.EProfileType.Gerente);
            var tokenUsuario = TokenGenerator.GenerateToken(Security.EProfileType.Usuario);

            clientAdmin.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAdmin);
            clientGerente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenGerente);
            clientUsuario.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenUsuario);

            // when

            var response = await client.GetAsync("/api/order/user/1/order");
            var responseAdmin = await clientAdmin.GetAsync("/api/order/user/1/order");
            var responseGerente = await clientGerente.GetAsync("/api/order/user/1/order");
            var responseUsuario = await clientUsuario.GetAsync("/api/order/user/1/order");

            // then

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Unauthorized));
            Assert.That(responseAdmin.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(responseGerente.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(responseUsuario.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task PermissionamentoGetBuyId()
        {
            OrderFactory factory = new OrderFactory();
            var client = factory.CreateClient();
            var clientAdmin = factory.CreateClient();
            var clientGerente = factory.CreateClient();
            var clientUsuario = factory.CreateClient();

            // given

            var tokenAdmin = TokenGenerator.GenerateToken(Security.EProfileType.Admin);
            var tokenGerente = TokenGenerator.GenerateToken(Security.EProfileType.Gerente);
            var tokenUsuario = TokenGenerator.GenerateToken(Security.EProfileType.Usuario);

            clientAdmin.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAdmin);
            clientGerente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenGerente);
            clientUsuario.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenUsuario);

            // when

            var response = await client.GetAsync("/api/order/user/1/buy");
            var responseAdmin = await clientAdmin.GetAsync("/api/order/user/1/buy");
            var responseGerente = await clientGerente.GetAsync("/api/order/user/1/buy");
            var responseUsuario = await clientUsuario.GetAsync("/api/order/user/1/buy");

            // then

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Unauthorized));
            Assert.That(responseAdmin.StatusCode, Is.Not.EqualTo(System.Net.HttpStatusCode.Unauthorized));
            Assert.That(responseAdmin.StatusCode, Is.Not.EqualTo(System.Net.HttpStatusCode.Forbidden));
            Assert.That(responseGerente.StatusCode, Is.Not.EqualTo(System.Net.HttpStatusCode.Unauthorized));
            Assert.That(responseGerente.StatusCode, Is.Not.EqualTo(System.Net.HttpStatusCode.Forbidden));
            Assert.That(responseUsuario.StatusCode, Is.Not.EqualTo(System.Net.HttpStatusCode.Unauthorized));
            Assert.That(responseUsuario.StatusCode, Is.Not.EqualTo(System.Net.HttpStatusCode.Forbidden));
        }
    }
}
