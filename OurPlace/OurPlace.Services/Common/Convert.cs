using OurPlace.Data;
using OurPlace.Services.DtoModels;

namespace OurPlace.Services.Common
{
    public static class Convert
    {
        internal static NotificationDto ToNotificationDto(this Notification x)
        {
            return new NotificationDto
            {
                Id = x.Id,
                Message = x.Message,
                Type = x.Type,
                DateSent = x.DateSent,
                User = x.User,
                UserId = x.UserId,
                SentBy = x.SentBy,
                SenderId = x.SenderId
            };
        }

        internal static ImageCommentDto ToImageCommentDto(this ImageComment x)
        {
            return new ImageCommentDto
            {
                Id = x.Id,
                Message = x.Message,
                DateSent = x.DateSent,
                UserId = x.UserId
            };
        }

        internal static PostCommentDto ToPostCommentDto(this PostComment x)
        {
            return new PostCommentDto
            {
                Id = x.Id,
                Message = x.Message,
                DateSent = x.DateSent,
                UserId = x.UserId
            };
        }
    }
}
