using OurPlace.Models.Post;

namespace OurPlace.Helpers.Post
{
    public static class Convert
    {
        internal static PostViewModel ToPostViewModel(this Data.Post x)
        {
            var model = new PostViewModel()
            {
                Id = x.Id,
                UserId = x.UserId,
                User = x.User,
                Message = x.Message,
                DatePosted = x.DatePosted
            };
            if (x.Image != null)
            {
                model.Image = x.Image;
            }
            return model;
        }
    }
}
