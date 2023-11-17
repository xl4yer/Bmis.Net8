using Bmis.Class;
using Bmis.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Bmis.Services
{
    public class ResidentServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;

        public ResidentServices(AppDb constring, IConfiguration configuration)
        {
            _constring = constring;
            Configuration = configuration;
        }
        public async Task<List<residents>> Residents()
        {
            List<residents> xres = new List<residents>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("Viewresidents", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xres.Add(new residents
                        {
                            resID = Convert.ToInt32(rdr["resID"]),
                            photo = (byte[])rdr["photo"],
                            fname = rdr["fname"].ToString(),
                            mname = rdr["mname"].ToString(),
                            lname = rdr["lname"].ToString(),
                            ext = rdr["ext"].ToString(),
                            purok = rdr["purok"].ToString(),
                            gender = rdr["gender"].ToString(),
                            bdate = Convert.ToDateTime(rdr["bdate"]),
                            status = rdr["status"].ToString(),
                            contact = rdr["contact"].ToString(),
                            fullname = rdr["fullname"].ToString(),
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
            return xres;
        }

        public async Task<int> AddResident(residents xres)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddResident", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_photo", xres.photo);
                    com.Parameters.AddWithValue("_fname", xres.fname);
                    com.Parameters.AddWithValue("_mname", xres.mname);
                    com.Parameters.AddWithValue("_lname", xres.lname);
                    com.Parameters.AddWithValue("_ext", xres.ext);
                    com.Parameters.AddWithValue("_purok", xres.purok);
                    com.Parameters.AddWithValue("_gender", xres.gender);
                    com.Parameters.AddWithValue("_bdate", xres.bdate);
                    com.Parameters.AddWithValue("_status", xres.status);
                    com.Parameters.AddWithValue("_contact", xres.contact);
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

        public async Task<int> UpdateResident(residents xres)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("updateresident", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_resID", xres.resID);
                    com.Parameters.AddWithValue("_photo", xres.photo);
                    com.Parameters.AddWithValue("_fname", xres.fname);
                    com.Parameters.AddWithValue("_mname", xres.mname);
                    com.Parameters.AddWithValue("_lname", xres.lname);
                    com.Parameters.AddWithValue("_ext", xres.ext);
                    com.Parameters.AddWithValue("_purok", xres.purok);
                    com.Parameters.AddWithValue("_gender", xres.gender);
                    com.Parameters.AddWithValue("_bdate", xres.bdate);
                    com.Parameters.AddWithValue("_status", xres.status);
                    com.Parameters.AddWithValue("_contact", xres.contact);
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

        public async Task<List<residents>> SearchResident(string search)
        {
            List<residents> xres = new List<residents>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchResident", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("search", search);
                    com.Parameters.AddWithValue("@searchWildcard", $"{search}%");
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xres.Add(new residents
                        {
                            resID = Convert.ToInt32(rdr["resID"]),
                            photo = (byte[])rdr["photo"],
                            fname = rdr["fname"].ToString(),
                            mname = rdr["mname"].ToString(),
                            lname = rdr["lname"].ToString(),
                            ext = rdr["ext"].ToString(),
                            purok = rdr["purok"].ToString(),
                            gender = rdr["gender"].ToString(),
                            bdate = Convert.ToDateTime(rdr["bdate"]),
                            status = rdr["status"].ToString(),
                            contact = rdr["contact"].ToString(),
                            fullname = rdr["fullname"].ToString(),
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
            return xres;
        }

    }

}

