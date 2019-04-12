using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    class NotesTesting
    {
        [Fact]
        public async void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            var postId = 2;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
    }
}
