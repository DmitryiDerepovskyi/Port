using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Port.Model.ClassModel;
using ManagerPort.SupportClass;

namespace Port.Model.Repository
{
    public class ShipRepository : IRepository<Ship>
    {
        readonly string _connStr = ConfigurationManager.ConnectionStrings["PortDb"].ConnectionString;

        public List<Ship> GetItemsList()
        {
            var ships = new List<Ship>();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("GetAllShips", cn))
                    {
                        cn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ships.Add(new Ship
                                        (
                                        int.Parse(dr["Id"].ToString()),
                                        ValidateInputData.ConvertToNullableInt(dr["CaptainId"].ToString()),
                                        int.Parse(dr["Number"].ToString()),
                                        int.Parse(dr["Capacity"].ToString()),
                                        DateTime.Parse(dr["CreateDate"].ToString()),
                                        int.Parse(dr["MaxDistance"].ToString()),
                                        int.Parse(dr["TeamCount"].ToString())
                                    ));
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
                return ships;
            }
        }

        public void Create(Ship item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("InsertShip", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@CaptainId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.CaptainId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@Number",
                            SqlDbType = SqlDbType.Int,
                            Value = item.Number,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@Capacity",
                            SqlDbType = SqlDbType.Int,
                            Value = item.Capacity,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@CreateDate",
                            SqlDbType = SqlDbType.DateTime,
                            Value = item.DateCreate,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@MaxDistance",
                            SqlDbType = SqlDbType.Int,
                            Value = item.MaxDistance,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@TeamCount",
                            SqlDbType = SqlDbType.Int,
                            Value = item.TeamCount,
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

        public void Update(Ship item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("UpdateShip", cn))
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
                            ParameterName = "@CaptainId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.CaptainId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@Number",
                            SqlDbType = SqlDbType.Int,
                            Value = item.Number,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@Capacity",
                            SqlDbType = SqlDbType.Int,
                            Value = item.Capacity,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@CreateDate",
                            SqlDbType = SqlDbType.DateTime,
                            Value = item.DateCreate,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@MaxDistance",
                            SqlDbType = SqlDbType.Int,
                            Value = item.MaxDistance,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@TeamCount",
                            SqlDbType = SqlDbType.Int,
                            Value = item.TeamCount,
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
                    using (var cmd = new SqlCommand("RemoveShip", cn))
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

        public Ship SearchById(int id)
        {
            Ship item = null;
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("SearchByIdShip", cn))
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
                            if (!dr.HasRows) return null;
                            dr.Read();
                            int? captainId;
                            if (dr["CaptainId"].ToString() == String.Empty)
                                captainId = null;
                            else
                                captainId = int.Parse(dr["CaptainId"].ToString());
                            item = new Ship
                                (
                                int.Parse(dr["Id"].ToString()),
                                captainId,
                                int.Parse(dr["Number"].ToString()),
                                int.Parse(dr["Capacity"].ToString()),
                                DateTime.Parse(dr["CreateDate"].ToString()),
                                int.Parse(dr["MaxDistance"].ToString()),
                                int.Parse(dr["TeamCount"].ToString())
                                );
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
