using TiredEagle.Domain.Abstraction;
using TiredEagle.Domain.SharedKernel;

namespace TiredEagle.Domain.ChannelOwner.Entities
{

    public class TelegramChannelOwner : Entity<Guid>, IAggregateRoot
    {
        public TelegramChannelOwner(string name, string nationalCode, int bankAccountNumber, int phoneNumber)
        {
            Name = name;
            NationalCode = nationalCode;
            BankAccountNumber = bankAccountNumber;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string NationalCode { get; private set; }
        public int BankAccountNumber { get; private set; }
        public int PhoneNumber { get; private set; }
        public IReadOnlyList<TelegramChannel> TelegramChannels => _ownedChannels.AsReadOnly();
        private List<TelegramChannel> _ownedChannels { get; }
        public CostStrategy CostStrategy { get; private set; }
        public TelegramChannelOwner SetCostingStrategy(CostStrategy costMethod)
        {
            CostStrategy = costMethod;
            return this;
        }
        public void AddChannel(TelegramChannel channel)
        {
            if (TelegramChannels.Count == 5) // todo specification maybe
            {
                throw new BusinessException("max channel creation limit exeeded");
            }
            _ownedChannels.Add(channel);
        }
    }
}
