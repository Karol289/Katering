namespace Katering.Entities
{
    public class ContractorEntity(int contractorId, string companyName, int NIP,int id, string name, string surname, string email) : UserEntity(id, name, surname, email)
    {
        public readonly int ContractorId = contractorId;

        public string CompanyName { get; set; } = companyName;

        public int NIP { get; set; } = NIP;
    }
}
