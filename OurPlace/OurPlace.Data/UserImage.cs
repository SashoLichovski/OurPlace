namespace OurPlace.Data
{
    public class UserImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
