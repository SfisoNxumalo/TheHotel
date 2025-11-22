using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHotel.Domain.Interfaces.Integrations
{
    public interface IAIContentService
    {
        Task<string> VerifyContentAsync(string prompt);
        Task<string> SummarizeAsync(string text);
        Task<string> RewriteAsync(string text, string style);
    }
}
