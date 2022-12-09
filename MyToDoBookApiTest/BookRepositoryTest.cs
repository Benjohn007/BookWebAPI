using MyToDoBookAPI.Model.Data;
using MyToDoBookAPI.Model.Models;
using NUnit.Framework;
using Repository;
using System.Net;

namespace MyToDoBookApiTest
{
    
    public class BookRepositoryTests
    {
        [SetUp]
        public void GetBookByIdAsync()
        {
           string Book = "passion";
           string Description = "This is to be read";
        }

        [Test]
        public void Test1()
        {
            string Book = BookModel.;
            var actual = BookRepository.GetBookByIdAsync(bookId);
            Assert.Pass();
        }
    }
}