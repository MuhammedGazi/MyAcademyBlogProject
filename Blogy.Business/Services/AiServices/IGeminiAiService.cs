using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.AiServices
{
    public interface IGeminiAiService
    {
        Task<bool> IsCommentSafeAsync(string comment);
    }
}
