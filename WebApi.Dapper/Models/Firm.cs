namespace WebApi.Dapper.Models
{
    public class Firm
    {
        public int Id { get; set; }

        public string? NameShort { get; set; }

        public string? NameFull { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? HomeNumber { get; set; }

        public string? ApartmentNumber { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get; set; }
        public long? NIP { get; set; }
        public long? Regon { get; set; }
        public long? KRS { get; set; }
    }
}
