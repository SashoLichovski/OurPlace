using OurPlace.Data;
using OurPlace.Repositories.Interfaces;

namespace OurPlace.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext context;

        public MessageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }
    }
}
