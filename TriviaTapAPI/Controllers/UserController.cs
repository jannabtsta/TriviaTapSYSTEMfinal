
using BLTriviaTap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AccountManagement.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : Controller
    {
        UserGetServices _userGetServices;
        UserTransactionServices _userTransactionServices;

        public UserController()
        {
            _userGetServices = new UserGetServices();
            _userTransactionServices = new UserTransactionServices();
        }

        [HttpGet]
        public IEnumerable<AccountManagement.API.User> GetUsers()
        {
            var activeusers = _userGetServices.GetAllUsers();

            List<AccountManagement.API.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new API.User { username = item.username, password = item.password });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = _userTransactionServices.CreateUser(request.username, request.password);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(User request)
        {
            var result = _userTransactionServices.UpdateUser(request.username, request.password);

            return new JsonResult(result);
        }


    }
}
