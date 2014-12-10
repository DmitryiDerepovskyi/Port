using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Port.Model.Repository
{
    public class PortRepository : IRepository<ClassModel.Port>
    {
        readonly string _connStr = ConfigurationManager.ConnectionStrings["PortDb"].ConnectionString;

        public List<ClassModel.Port> GetItemsList()
        {
            var ports = new List<ClassModel.Port>();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("GetAllPorts", cn))
                    {
                        cn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ports.Add(new ClassModel.Port
                                    {
                                        Id = int.Parse(dr["Id"].ToString()),
                                        Name = dr["Name"].ToString(),
                                        CityId = int.Parse(dr["CityId"].ToString())
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
                return ports;
            }
        }

        public void Create(ClassModel.Port item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("InsertPort", cn))
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
                        param = new SqlParameter
                        {
                            ParameterName = "@CityId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.CityId,
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

        public void Update(ClassModel.Port item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("UpdatePort", cn))
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
                        param = new SqlParameter
                        {
                            ParameterName = "@CityId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.CityId,
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
                    using (var cmd = new SqlCommand("RemovePort", cn))
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

        public ClassModel.Port SearchById(int id)
        {
            var item = new ClassModel.Port();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("SearchByIdPort", cn))
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
                                item.CityId = int.Parse(dr["CityId"].ToString());
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
