namespace OurPlace.Data
{
    public class CommentLike : Like
    {
        public int CommentId { get; set; }
        public PostComment Comment { get; set; }

    }
}
