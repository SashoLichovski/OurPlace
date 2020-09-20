using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace OurPlace.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepo;
        private readonly IUserService userService;

        public GroupService(IGroupRepository groupRepo, IUserService userService)
        {
            this.groupRepo = groupRepo;
            this.userService = userService;
        }

        public void Create(string userId, string groupName)
        {
            var newGroup = new Group()
            {
                GroupAdminId = userId,
                Name = groupName,
                MembersCount = 1,
                DateCreated = DateTime.Now,
                GroupAdminName = userService.GetById(userId).UserName
            };
            groupRepo.Add(newGroup);
            var relation = new GroupUser()
            {
                UserId = userId,
                GroupId = groupRepo.GetMostRecentByName(groupName).Id
            };
            groupRepo.Add(relation);
        }

        public List<Group> GetGroups(string userId)
        {
            return groupRepo.GetGroups(userId);
        } 
    }
}
