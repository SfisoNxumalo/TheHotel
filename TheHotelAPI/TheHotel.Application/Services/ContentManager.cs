using TheHotel.Domain.Interfaces.Integrations;

namespace TheHotel.Application.Interfaces
{
    public class ContentManager
    {
        private readonly IAIContentService _contentManagerAI;
        public ContentManager(IAIContentService contentManagerAI) {
             _contentManagerAI = contentManagerAI;
        }

        public async Task<string> VerifyContentAsync(string text)
        {
            return await _contentManagerAI.VerifyContentAsync(text);
        }
    }
}
