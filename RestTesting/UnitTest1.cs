using RA;

namespace RestTesting
{
    public class Tests
    {
        RestAssured tester = new RestAssured();

        [SetUp]
        public void Setup()
        {
            tester.Given()
                .Name("Test Get call")
                .Header("Content-Type", "application/json")
                .Host("https://jsonplaceholder.typicode.com");
        }

        [Test]
        public void TestGet()
        {            
            tester.Given()
                .When()
                    .Get("https://jsonplaceholder.typicode.com/todos/1")
                .Then()
                    .TestBody("Id testing", x => x.id == 1).Assert("Id testing")
                    .TestBody("User Id Testing", x => x.userId == 1).Assert("User Id Testing")
                    .TestBody("Title Testing", x => x.title == "delectus aut autem").Assert("Title Testing");
        }

        [Test]
        public void TestPost()
        {
            var body = new
            {
                title = "maestriaTesting",
                body = "maestriaBody",
                userId = 500
            };

            tester
                .Given()
                    .Body(body)
                .When()
                    .Post("https://jsonplaceholder.typicode.com/posts")
                .Then()
                    .TestStatus("Status testing", x => x == 201).Assert("Status testing")
                    .TestBody("Id testing", x => x.id == 101).Assert("Id testing");
        }

        [Test]
        public void TestPut()
        {
            var body = new
            {
                title = "maestriaTesting",
                body = "maestriaBody",
                userId = 500
            };

            tester
                .Given()
                    .Body(body)
                .When()
                    .Put("https://jsonplaceholder.typicode.com/posts/1")
                .Then()
                    .TestStatus("Status testing", x => x == 200).Assert("Status testing")
                    .TestBody("Id testing", x => x.id == 1).Assert("Id testing");
        }

        [Test]
        public void TestDelete()
        {
            tester
                .Given()
                .When()
                    .Delete("https://jsonplaceholder.typicode.com/posts/1")
                .Then()
                    .TestStatus("Status testing", x => x == 200).Assert("Status testing");
        }
    }
}