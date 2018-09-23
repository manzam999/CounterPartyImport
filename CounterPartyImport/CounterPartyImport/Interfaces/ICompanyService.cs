using CounterPartyImport.Dto;
using System.IO;

namespace CounterPartyImport.Interfaces
{
    public interface ICompanyService
    {
        ImportResponseDto ImportCounterParties(Stream stream);
    }
}
