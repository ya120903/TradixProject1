using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TradixProjectPresentationLayer.Models;

namespace TradixProjectPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        // Veritabanı bağlantı stringi
        private readonly string _connectionString = "Server=.\\SQLEXPRESS;Database=ExchangeRate;Integrated Security=True;TrustServerCertificate=True;";

        public IActionResult Index()
        {
            List<GunDoviz> gunDovizData = new();

            // Tablo adları
            var tableNames = new List<string>
            {
                "[dbo].[1.gündöviz]", "[dbo].[2.gündöviz]", "[dbo].[3.gündöviz]", "[dbo].[4.gündöviz]",
                "[dbo].[5.gündöviz]", "[dbo].[6.gündöviz]", "[dbo].[7.gündöviz]", "[dbo].[8.gündöviz]", "[dbo].[9.gündöviz]"
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Her bir tabloyu döngüyle sorgulama
                    foreach (var tableName in tableNames)
                    {
                        // SQL Sorgusu
                        string query = $"SELECT top 1000 [DövizAdi], [Alis], [Satis], [% Fark], [Tarih] FROM {tableName}";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    decimal alis = 0, satis = 0, fark = 0;
                                    DateTime tarih = DateTime.MinValue;

                                    decimal.TryParse(reader["Alis"]?.ToString(), out alis);
                                    decimal.TryParse(reader["Satis"]?.ToString(), out satis);
                                    decimal.TryParse(reader["% Fark"]?.ToString(), out fark);
                                    DateTime.TryParse(reader["Tarih"]?.ToString(), out tarih);

                                    var dovizAdi = reader["DövizAdi"] as string ?? string.Empty;

                                    // Tekrar kontrolü
                                    if (!gunDovizData.Exists(x =>
                                        x.DovizAdi == dovizAdi && x.Tarih == tarih))
                                    {
                                        gunDovizData.Add(new GunDoviz
                                        {
                                            DovizAdi = dovizAdi,
                                            Alis = alis,
                                            Satis = satis,
                                            Fark = fark,
                                            Tarih = tarih
                                        });
                                    }
                                }
                            }
                            }
                        }
                }
            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            // Verileri View'a gönderiyoruz
            return View(gunDovizData);
        }
    }
}
