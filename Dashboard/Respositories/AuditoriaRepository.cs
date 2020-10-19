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
    public class AuditoriaRepository : IAuditoriaRepository
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        
        public AuditoriaRepository(IConfiguration config, IHubContext<ChartHub> hub)
        {
            _hub = hub;
            _config = config;
            _connectionString = _config.GetConnectionString("SIFA_PRUEBAS");
        }
        public AuditoriasPorEstatusModel ObtenerResultados()
        {
            AuditoriasPorEstatusModel res = null;
            SqlDependency dep = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_D_Auditorias", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Notification = null;

                    //sqlDependency
                    dep = new SqlDependency(cmd);
                    dep.OnChange += DetectarCambios;
                    SqlDependency.Start(_connectionString);

                    SqlDataReader dr = cmd.ExecuteReader();
                    //if (dr.Read())
                    //{
                    //    res = new AuditoriasPorEstatusModel();

                    //    res.autorizadas = dr.IsDBNull(dr.GetOrdinal("Autorizadas")) ? 0 : dr.GetInt32(dr.GetOrdinal("Autorizadas"));
                    //    res.propuestas = dr.IsDBNull(dr.GetOrdinal("Propuestas")) ? 0 : dr.GetInt32(dr.GetOrdinal("Propuestas"));
                    //    res.rechazadas = dr.IsDBNull(dr.GetOrdinal("Rechazadas")) ? 0 : dr.GetInt32(dr.GetOrdinal("Rechazadas"));
                    //}

                    return res;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void DetectarCambios(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                _hub.Clients.All.SendAsync("auditorias");
            }
            ObtenerResultados();
        }

        public IEnumerable<AuditoriasPorEstatusModel> Get()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
