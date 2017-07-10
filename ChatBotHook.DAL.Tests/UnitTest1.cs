using System;
using Xunit;
using ChatBotHook.DAL;

namespace ChatBotHook.DAL.Tests
{
    public class UnitTest1
    {

        [Fact]
        public async void Test1()
        {
            DynomoDatabaseDAL c1 = new DynomoDatabaseDAL();
            c1.GetUser("User1");

            await c1.AddDeckAsync("User1", "D1");
            await c1.AddDeckAsync("User1", "D2");
            c1.GetDecks("User1");
        }
    }
}
