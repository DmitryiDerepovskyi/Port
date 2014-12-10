using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Port.Model.ClassModel;

namespace Port.Model.Repository
{
    public class CityRepository : IRepository<City>
    {
        readonly string _connStr = ConfigurationManager.ConnectionStrings["PortDb"].ConnectionString;

        public List<City> GetItemsList()
        {
            var cities = new List<City>();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("GetAllCities", cn))
                    {
                        cn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cities.Add(new City
                                    {
                                        Id = int.Parse(dr["Id"].ToString()),
                                        Name = dr["Name"].ToString(),
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
                return cities;
            }
        }

        public void Create(City item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("InsertCity", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@Name",
                            SqlDbType = SqlDbType.NVarChar,
                            Value = item.Name,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public void Update(City item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("UpdateCity", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@Id",
                            SqlDbType = SqlDbType.Int,
                            Value = item.Id,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@Name",
                            SqlDbType = SqlDbType.NVarChar,
                            Value = item.Name,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public void Remove(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("RemoveCity", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@Id",
                            SqlDbType = SqlDbType.Int,
                            Value = id,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public City SearchById(int id)
        {
            var item = new City();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("SearchByIdCity", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@Id",
                            SqlDbType = SqlDbType.Int,
                            Value = id,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        cn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                item.Id = int.Parse(dr["Id"].ToString());
                                item.Name = dr["Name"].ToString();
                            }
                            else
                            {
                                item = null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
                return item;
            }
        }
    }
}
