using Bmis.Class;
using Bmis.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Bmis.Services
{
    public class ClearanceServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;

        public ClearanceServices(AppDb constring, IConfiguration configuration)
        {
            _constring = constring;
            Configuration = configuration;
        }

        public async Task<List<clearance>> Clearance()
        {
            List<clearance> xclearance = new List<clearance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("viewclearance", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xclearance.Add(new clearance
                        {
                            clearID = Convert.ToInt32(rdr["clearID"]),
                            resID = Convert.ToInt32(rdr["resID"]),
                            date = Convert.ToDateTime(rdr["date"]),
                            purpose = rdr["purpose"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            purok = rdr["purok"].ToString(),
                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return xclearance;
        }

        public async Task<int> AddClearance(clearance xclearance)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddClearance", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_date", xclearance.date);
                    com.Parameters.AddWithValue("_resID", xclearance.resID);
                    com.Parameters.AddWithValue("_purpose", xclearance.purpose);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return 0;
        }
    }
}
