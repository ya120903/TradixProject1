using System.Data.SqlClient;
using TradixProject.DtoLayer.ExchangeRateDtos;

public class ExchangeRateRepository
{
    private readonly string _connectionString;

    public ExchangeRateRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<ResualtExhangeRateDto> GetExchangeRates()
    {
        var exchangeRates = new List<ResualtExhangeRateDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT Id, CurrencyCode, Unit, CurrencyName, ForexBuying, ForexSelling, CreatedDate FROM ExchangeRates";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exchangeRates.Add(new ResualtExhangeRateDto
                        {
                            Id = reader.GetInt32(0),
                            CurrencyCode = reader.GetString(1),
                            Unit = reader.GetString(2),
                            CurrencyName = reader.GetString(3),
                            ForexBuying = reader.IsDBNull(4) ? null : reader.GetDecimal(4),
                            ForexSelling = reader.IsDBNull(5) ? null : reader.GetDecimal(5),
                            CreatedDate = reader.GetDateTime(6)
                        });
                    }
                }
            }
        }

        return exchangeRates;
    }
}
