namespace WebApi.Dapper.Models
{
    public class Contractor
    {
        public int Id { get; set; }

        public int FirmId { get; set; }

        public string? ContractorCode { get; set; }

        public string? ContractorName { get; set; }

        public long? NIP { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? HomeNumber { get; set; }

        public string? ApartmentNumber { get; set; }

        public string? Country { get; set; }

        public string? ZipNumber { get; set; }

        public string? BankAccountNumber { get; set; }

        public bool IsDefault { get; set; }

        public int? ParentContractorId { get; set; }

        public bool IsVatPayer { get; set; }
    }
}
