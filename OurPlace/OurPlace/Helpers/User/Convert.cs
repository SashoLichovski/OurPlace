using OurPlace.Models.User;
using OurPlace.Data;

namespace OurPlace.Helpers.User
{
    public static class Convert
    {
        internal static UserLayoutPhotosModel ToUserLayoutPhotosModel(this Data.User x)
        {
            return new UserLayoutPhotosModel
            {
                UserId = x.Id,
                CoverPhoto = x.CoverPhoto,
                ProfilePhoto = x.ProfilePhoto
            };
        }

        internal static UserInfoModel ToUserInfoModel(this Data.User x)
        {
            return new UserInfoModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                UserId = x.Id
            };
        }

        internal static SearchUserModel ToSearchUserModel(this Data.User x)
        {
            return new SearchUserModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            };
        }

        internal static ListOfUserFriendModel ToUserFriendModel(this Data.User x)
        {
            return new ListOfUserFriendModel
            {
                Id = x.Id,
                FullName = x.UserName,
                Email = x.Email
            };
        }
    }
}
