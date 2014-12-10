using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Port.Model.ClassModel;

namespace Port.Model.Repository
{
    public class CargoRepository : IRepository<Cargo>
    {
        readonly string _connStr = ConfigurationManager.ConnectionStrings["PortDb"].ConnectionString;

        public List<Cargo> GetItemsList()
        {
            var cargos = new List<Cargo>();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("GetAllCargos", cn))
                    {
                        cn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cargos.Add(new Cargo
                                    {
                                        Id = int.Parse(dr["Id"].ToString()),
                                        Number = int.Parse(dr["Number"].ToString()),
                                        TypeId = int.Parse(dr["TypeId"].ToString()),
                                        TripId = int.Parse(dr["TripId"].ToString()),
                                        WeightCargo = int.Parse(dr["WeightCargo"].ToString()),
                                        Price = double.Parse(dr["Price"].ToString()),
                                        InsurancePrice = double.Parse(dr["InsurancePrice"].ToString())
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
                return cargos;
            }
        }

        public void Create(Cargo item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("InsertCargo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@Number",
                            SqlDbType = SqlDbType.Int,
                            Value = item.Number,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@TripId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.TripId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@TypeId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.TypeId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@WeightCargo",
                            SqlDbType = SqlDbType.Int,
                            Value = item.WeightCargo,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@Price",
                            SqlDbType = SqlDbType.Money,
                            Value = item.Price,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@InsurancePrice",
                            SqlDbType = SqlDbType.Money,
                            Value = item.InsurancePrice,
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

        public void Update(Cargo item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("UpdateCargo", cn))
                    {
                                                cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter
                        {
                            ParameterName = "@Number",
                            SqlDbType = SqlDbType.Int,
                            Value = item.Number,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@TripId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.TripId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@TypeId",
                            SqlDbType = SqlDbType.Int,
                            Value = item.TypeId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@WeightCargo",
                            SqlDbType = SqlDbType.Int,
                            Value = item.WeightCargo,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@Price",
                            SqlDbType = SqlDbType.Money,
                            Value = item.Price,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter
                        {
                            ParameterName = "@InsurancePrice",
                            SqlDbType = SqlDbType.Money,
                            Value = item.InsurancePrice,
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
                    using (var cmd = new SqlCommand("RemoveCargo", cn))
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

        public Cargo SearchById(int id)
        {
            var item = new Cargo();
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = _connStr;
                try
                {
                    using (var cmd = new SqlCommand("SearchByIdCargo", cn))
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
                                while (dr.Read())
                                {
                                    item = new Cargo
                                    {
                                        Id = int.Parse(dr["Id"].ToString()),
                                        Number = int.Parse(dr["Number"].ToString()),
                                        TypeId = int.Parse(dr["TypeId"].ToString()),
                                        TripId = int.Parse(dr["TripId"].ToString()),
                                        WeightCargo = int.Parse(dr["WeightCargo"].ToString()),
                                        Price = double.Parse(dr["Price"].ToString()),
                                        InsurancePrice = double.Parse(dr["InsurancePrice"].ToString())
                                    };
                                }
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
