using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using ASPApi.Models;

namespace ASPApi
{
    public class GraphController : ApiController
    {
		public readonly string _connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        [HttpGet]
        [Route("api/MonthlyVisitors")]
        public IHttpActionResult GetAllMonthlyVisitors()
        {
			List<MonthlyVisitors> visitors = GetMonthlyYears();
			if (visitors == null)
            {
                return NotFound();
            }
			return Json(visitors);
		}

		[HttpGet]
		[Route("api/RadiationRates")]
		public IHttpActionResult GetAllRadationRates()
		{
			List<RadiationRates> rates = GetRadiationRates();
			if (rates == null)
			{
				return NotFound();
			}
			return Json(rates);
		}

		[HttpGet]
		[Route("api/OccupationRates")]
		public IHttpActionResult GetAllOccupationRates()
		{
			List<OccupationRates> rates = GetOccupationRates();
			if (rates == null)
			{
				return NotFound();
			}
			return Json(rates);
		}

		public List<MonthlyVisitors> GetMonthlyYears()
		{
			List<MonthlyVisitors> visitors = new List<MonthlyVisitors>();
			var connection = new SqlConnection(_connectionString);
			try
			{
				connection.Open();
				var sql = new SqlCommand("select * from [dbo].[monthlyVisits];", connection);
				var reader = sql.ExecuteReader();
				var dataTable = new DataTable();
				dataTable.Load(reader);
			
				foreach (DataRow row in dataTable.Rows)
				{
					var monthlyYear5Visitors = new MonthlyVisitors()
					{
						Month = row["Month"].ToString(),
						Year1 = row["Year1"].ToString(),
						Year2 = row["Year2"].ToString(),
						Year3 = row["Year3"].ToString(),
						Year4 = row["Year4"].ToString(),
						Year5 = row["Year5"].ToString()
					};
					visitors.Add(monthlyYear5Visitors);
				}
			}
			finally
			{
				connection.Close();
			}
			return visitors;
		}

		public List<RadiationRates> GetRadiationRates()
		{
			List<RadiationRates> rates = new List<RadiationRates>();
			var connection = new SqlConnection(_connectionString);
			try
			{
				connection.Open();
				var sql = new SqlCommand("select * from [dbo].[mean_daily_global_radiation_];", connection);
				var reader = sql.ExecuteReader();
				var dataTable = new DataTable();
				dataTable.Load(reader);
				// You can also use an ArrayList instead of List<>
				foreach (DataRow row in dataTable.Rows)
				{
					var radiationRates = new RadiationRates()
					{
						Month = row["Month"].ToString() == "" ? "" : row["Month"].ToString(),
						AverageRadiation = row["AverageRadiation"].ToString() == "" ? 0.00 : Convert.ToDouble(row["AverageRadiation"]),

					};
					rates.Add(radiationRates);
				}
			}
			finally
			{
				connection.Close();
			}
			return rates;
		}

		public List<OccupationRates> GetOccupationRates()
		{
			List<OccupationRates> rates = new List<OccupationRates>();
			var connection = new SqlConnection(_connectionString);
			try
			{
				connection.Open();
				var sql = new SqlCommand("select * from [dbo].[occupancyRate];", connection);
				var reader = sql.ExecuteReader();
				var dataTable = new DataTable();
				dataTable.Load(reader);
				// You can also use an ArrayList instead of List<>
				foreach (DataRow row in dataTable.Rows)
				{
					var occupationRate = new OccupationRates()
					{
						Month = row["Month"].ToString() == "" ? "" : row["Month"].ToString(),
						OccupationRate = row["Occupancy rate"].ToString() == "" ? 0.00 : Convert.ToDouble(row["Occupancy rate"]),

					};
					rates.Add(occupationRate);
				}
			}
			finally
			{
				connection.Close();
			}
			return rates;
		}
	}
}
