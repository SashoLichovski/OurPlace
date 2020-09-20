using Microsoft.AspNetCore.Mvc;
using OurPlace.Models.Group;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;
        private readonly IFriendService friendService;
        private readonly IUserService userService;

        public GroupController(IGroupService groupService, IFriendService friendService, IUserService userService)
        {
            this.groupService = groupService;
            this.friendService = friendService;
            this.userService = userService;
        }

        public IActionResult Create(string userId, string groupName)
        {
            groupService.Create(userId, groupName);    
            return RedirectToAction("Groups", "User", new { UserId = userId });
        }

        public IActionResult AddPeople(int groupId, string userId)
        {
            var model = new AddPeopleToGroupViewModel()
            {
                Friends = userService.GetUserFriends(userId),
                GroupId = groupId
            };
            return View(model);
        }
    }
}
