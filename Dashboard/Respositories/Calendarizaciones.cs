using Dashboard.HubConfig;
using Dashboard.Respositories.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Respositories
{
    public class Calendarizaciones
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        public Calendarizaciones(IConfiguration config,IHubContext<ChartHub> hub)
        {
            _hub = hub;
            _config = config;
            _connectionString = _config.GetConnectionString("SIFA_PRUEBAS");
        }
        public void Get()
        {
            List<CalendarizacionModel> lst = null;
            SqlDependency dep = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Test_Obtener_Calendarizaciones", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Notification = null;
                    
                    //sqlDependency
                    dep = new SqlDependency();
                    dep.OnChange += DetectarCambios;
                    SqlDependency.Start(_connectionString);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        lst = new List<CalendarizacionModel>();
                        // =(
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    throw;
                }
            }
        }

        private void DetectarCambios(object sender, SqlNotificationEventArgs e)
        {
            //al detectar cambios se notifica por socket 
            throw new NotImplementedException();
        }
    }

}
