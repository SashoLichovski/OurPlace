namespace OurPlace.Data
{
    public class PostComment : Comment
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
