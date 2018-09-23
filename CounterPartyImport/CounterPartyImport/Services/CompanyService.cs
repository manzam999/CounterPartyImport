using System.Collections.Generic;
using System.IO;
using System.Linq;
using CounterPartyImport.Dto;
using CounterPartyImport.Entities;
using CounterPartyImport.Interfaces;
using CounterPartyImport.Utils;

namespace CounterPartyImport.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryBase<Company> _companyRepository;

        public CompanyService(IRepositoryBase<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public ImportResponseDto ImportCounterParties(Stream stream)
        {
            var companies = new List<Company>();
            var result = new ImportResponseDto();

            using (var reader = new StreamReader(stream))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var isBuyer = values[2].ToBoolean();
                    var isSeller = values[3].ToBoolean();

                    companies.Add(new Company
                    {
                        ExternalId = values[0],
                        LegalName = values[1],
                        TradingName = values[1],
                        Fax = values[5],
                        Phone = values[4],
                        IsActive = isBuyer || isSeller,
                        IsForwarder = isBuyer && isSeller
                    });
                }
            }

            var externalIds = companies.Select(c => c.ExternalId);
            var alreadyAdded = _companyRepository.GetAll(c => externalIds.Contains(c.ExternalId));

            if (alreadyAdded.Any())
            {
                result.Errors.AddRange(alreadyAdded.Select(a => $"Company with external id {a.ExternalId} is already added"));
                companies = companies.Where(c => !externalIds.Contains(c.ExternalId)).ToList();
            }

            if (companies.Any())
            {
                _companyRepository.BulkInsert(companies);
            }

            return result;
        }
    }
}
