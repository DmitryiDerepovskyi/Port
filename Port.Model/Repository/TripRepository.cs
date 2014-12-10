using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Port.Model.ClassModel;

namespace Port.Model.Repository
{
    public class TripRepository : IRepository<Trip>
    {
        readonly string _connStr = ConfigurationManager.ConnectionStrings["PortDb"].ConnectionString;

        public List<Trip> GetItemsList()
        {
            var trips = new List<Trip>();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("GetAllTrips", cn))
                    {
                        cn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    trips.Add(new Trip
                                    {
                                        Id = int.Parse(dr["Id"].ToString()),
                                        ShipId = int.Parse(dr["ShipId"].ToString()),
                                        CaptainId = int.Parse(dr["CaptainId"].ToString()),
                                        PortToId = int.Parse(dr["PortToId"].ToString()),
                                        PortFromId = int.Parse(dr["PortFromId"].ToString()),
                                        StartDate = dr["StartDate"].ToString(),
                                        EndDate = dr["EndDate"].ToString()
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
                return trips;
            }
        }

        public void Create(Trip item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("InsertTrip", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@ShipId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.ShipId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@PortToId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.PortToId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@PortFromId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.PortFromId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@StartDate",
                            SqlDbType = SqlDbType.DateTime,
                            Value = item.StartDate,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@EndDate",
                            SqlDbType = SqlDbType.DateTime,
                            Value = item.EndDate,
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

        public void Update(Trip item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("UpdateTrip", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@ShipId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.ShipId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@PortToId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.PortToId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@PortFromId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.PortFromId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@StartDate",
                            SqlDbType = SqlDbType.DateTime,
                            Value = item.StartDate,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@EndDate",
                            SqlDbType = SqlDbType.DateTime,
                            Value = item.EndDate,
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
                    using (var cmd = new SqlCommand("RemoveTrip", cn))
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

        public Trip SearchById(int id)
        {
            var item = new Trip();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("SearchByIdTrip", cn))
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
                                item = new Trip
                                {
                                    Id = int.Parse(dr["Id"].ToString()),
                                    ShipId = int.Parse(dr["ShipId"].ToString()),
                                    CaptainId = int.Parse(dr["CaptainId"].ToString()),
                                    PortToId = int.Parse(dr["PortToId"].ToString()),
                                    PortFromId = int.Parse(dr["PortFromId"].ToString()),
                                    StartDate = dr["StartDate"].ToString(),
                                    EndDate = dr["EndDate"].ToString()
                                };
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
