using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using a4aerotask.Models;
using System.Data.SqlClient;
using a4aerotask.DAL.DBCon;

namespace a4aerotask.DAL
{
    public class AgentDAL
    {
        List<Agent> listAgent = null;
        //List<Student> listState = null;
        //List<Student> listDis = null;
        //List<Student> listStd = null;
        Agent agent = null;
        SqlCommand cmd;

    

        sqlCon conn = new sqlCon();
        SqlConnection a = new SqlConnection();



        internal List<Agent> GetAgentInfo()
        {
            try
            {
                a = conn.getConnection();
                listAgent = new List<Agent>();
                cmd = new SqlCommand("test_GetAgentInfo", a);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                a.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    agent = new Agent();
                    agent.BusinessId = Convert.ToInt32(reader["BusinessId"].ToString());
                    agent.Code = Convert.ToString(reader["Code"]);
                    agent.Email = Convert.ToString(reader["Email"]);
                    agent.Name = Convert.ToString(reader["Name"]);
                    agent.Street = Convert.ToString(reader["Street"]);
                    agent.City = Convert.ToString(reader["City"].ToString());
                    agent.State = Convert.ToString(reader["State"]);
                    agent.Zip = Convert.ToString(reader["Zip"].ToString());
                    agent.Country = Convert.ToString(reader["Country"]);
                    agent.Mobile = Convert.ToString(reader["Mobile"]);
                    agent.Phone = Convert.ToString(reader["Phone"]);
                    agent.ContactPerson = Convert.ToString(reader["ContactPerson"].ToString());
                    agent.ReferredBy = Convert.ToString(reader["ReferredBy"].ToString());
                    //agent.Logo = Convert.ToString(reader["Logo"]);
                    agent.Status = Convert.ToInt32(reader["Status"].ToString());
                    agent.StatusIsActive = Convert.ToString(reader["STATUS"].ToString());
                    agent.Balance = Convert.ToDecimal(reader["Balance"].ToString());
                    agent.LoginUrl = Convert.ToString(reader["LoginUrl"]);
                    agent.SecurityCode = Convert.ToString(reader["SecurityCode"]);
                    agent.SMTPServer = Convert.ToString(reader["SMTPServer"]);
                    agent.SMTPPort = Convert.ToInt32(reader["SMTPPort"].ToString());
                    agent.SMTPUsername = Convert.ToString(reader["SMTPUsername"]);
                    agent.SMTPPassword = Convert.ToString(reader["SMTPPassword"]);
                    agent.Deleted = Convert.ToBoolean(reader["Deleted"]);
                    agent.CreatedOnUtc = Convert.ToDateTime(reader["CreatedOnUtc"]);
                    agent.UpdatedOnUtc = Convert.ToDateTime(reader["UpdatedOnUtc"]);
                    agent.CurrentBalance = Convert.ToDecimal(reader["CurrentBalance"].ToString());
                    agent.fulladdress = Convert.ToString(reader["fulladdress"]);

                    agent.PicPath = Convert.ToString(reader["Logo"]);
                    listAgent.Add(agent);
                }
            }
            catch
            {
                //throw new Exception("Error : " + ex.Message);
                return listAgent;
            }
            finally
            {
                a.Close();
            }
            return listAgent;
        }

        internal int DeleteAgent(Agent objAgent)
        {
            int result = 0;
            try
            {
                a = conn.getConnection();
                cmd = new SqlCommand("test_DeleteAgentInfo", a);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BusinessId", objAgent.BusinessId);
                cmd.Parameters.AddWithValue("@Deleted", objAgent.Deleted);
                a.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch
            {
                return result;
            }

            finally
            {
                a.Close();
            }
            return result;
        }

        internal int AgentUpdate(Agent objAgent)
        {
            int result = 0;
            try
            {
                a = conn.getConnection();
                cmd = new SqlCommand("test_AgentUpdateInfo", a);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BusinessId", objAgent.BusinessId);
                cmd.Parameters.AddWithValue("@PicPath", objAgent.PicPath);
                cmd.Parameters.AddWithValue("@Code", objAgent.Code);
                cmd.Parameters.AddWithValue("@Email", objAgent.Email);
                cmd.Parameters.AddWithValue("@Name", objAgent.Name);
                cmd.Parameters.AddWithValue("@Street", objAgent.Street);
                cmd.Parameters.AddWithValue("@City", objAgent.City);
                cmd.Parameters.AddWithValue("@State", objAgent.State);
                cmd.Parameters.AddWithValue("@Zip", objAgent.Zip);
                cmd.Parameters.AddWithValue("@Country", objAgent.Country);
                cmd.Parameters.AddWithValue("@Mobile", objAgent.Mobile);
                cmd.Parameters.AddWithValue("@Phone", objAgent.Phone);
                cmd.Parameters.AddWithValue("@ContactPerson", objAgent.ContactPerson);
                cmd.Parameters.AddWithValue("@ReferredBy", objAgent.ReferredBy);
                cmd.Parameters.AddWithValue("@Status", objAgent.Status);
                cmd.Parameters.AddWithValue("@Balance", objAgent.Balance);
                cmd.Parameters.AddWithValue("@LoginUrl", objAgent.LoginUrl);
                cmd.Parameters.AddWithValue("@SecurityCode", objAgent.SecurityCode);
                cmd.Parameters.AddWithValue("@SMTPServer", objAgent.SMTPServer);
                cmd.Parameters.AddWithValue("@SMTPPort", objAgent.SMTPPort);
                cmd.Parameters.AddWithValue("@SMTPUsername", objAgent.SMTPUsername);
                cmd.Parameters.AddWithValue("@SMTPPassword", objAgent.SMTPPassword);
                cmd.Parameters.AddWithValue("@Deleted", objAgent.Deleted);
                cmd.Parameters.AddWithValue("@CreatedOnUtc", objAgent.CreatedOnUtc);
                cmd.Parameters.AddWithValue("@UpdatedOnUtc", objAgent.UpdatedOnUtc);
                cmd.Parameters.AddWithValue("@CurrentBalance", objAgent.CurrentBalance);

                a.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch
            {
                //throw new Exception(ex.Message);
                return result;
            }

            finally
            {
                a.Close();
            }
            return result;
        }

        internal Agent GetAgentInfoById(Agent objAgent)
        {
            try
            {
                a = conn.getConnection();
              
                cmd = new SqlCommand("test_GetAgentInfoById", a);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BusinessId", objAgent.BusinessId);
                a.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    agent = new Agent();
                    agent.BusinessId = Convert.ToInt32(reader["BusinessId"].ToString());
                    agent.Code = Convert.ToString(reader["Code"]);
                    agent.Email = Convert.ToString(reader["Email"]);
                    agent.Name = Convert.ToString(reader["Name"]);
                    agent.Street = Convert.ToString(reader["Street"]);
                    agent.City = Convert.ToString(reader["City"].ToString());
                    agent.State = Convert.ToString(reader["State"]);
                    agent.Zip = Convert.ToString(reader["Zip"].ToString());
                    agent.Country = Convert.ToString(reader["Country"]);
                    agent.Mobile = Convert.ToString(reader["Mobile"]);
                    agent.Phone = Convert.ToString(reader["Phone"]);
                    agent.ContactPerson = Convert.ToString(reader["ContactPerson"].ToString());
                    agent.ReferredBy = Convert.ToString(reader["ReferredBy"].ToString());
                    //agent.Logo = Convert.ToString(reader["Logo"]);
                    agent.Status = Convert.ToInt32(reader["Status"].ToString());
                    agent.StatusIsActive = Convert.ToString(reader["STATUS"].ToString());
                    agent.Balance = Convert.ToDecimal(reader["Balance"].ToString());
                    agent.LoginUrl = Convert.ToString(reader["LoginUrl"]);
                    agent.SecurityCode = Convert.ToString(reader["SecurityCode"]);
                    agent.SMTPServer = Convert.ToString(reader["SMTPServer"]);
                    agent.SMTPPort = Convert.ToInt32(reader["SMTPPort"].ToString());
                    agent.SMTPUsername = Convert.ToString(reader["SMTPUsername"]);
                    agent.SMTPPassword = Convert.ToString(reader["SMTPPassword"]);
                    agent.Deleted = Convert.ToBoolean(reader["Deleted"]);
                    agent.CreatedOnUtc = Convert.ToDateTime(reader["CreatedOnUtc"].ToString());
                    agent.UpdatedOnUtc = Convert.ToDateTime(reader["UpdatedOnUtc"]);
                    agent.CurrentBalance = Convert.ToDecimal(reader["CurrentBalance"].ToString());

                    agent.PicPath = Convert.ToString(reader["Logo"]);
                }
            }
            catch
            {
                //throw new Exception("Error : " + ex.Message);
                return agent;
            }
            finally
            {
                a.Close();
            }
            return agent;
        }

        internal int SaveAgent(Agent objAgent)
        {
            int result = 0;
            try
            {
                a = conn.getConnection();
                cmd = new SqlCommand("test_SaveAgentInfo", a);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentPicPath", objAgent.PicPath);
                cmd.Parameters.AddWithValue("@Code", objAgent.Code);
                cmd.Parameters.AddWithValue("@Email", objAgent.Email);
                cmd.Parameters.AddWithValue("@Name", objAgent.Name);
                cmd.Parameters.AddWithValue("@Street", objAgent.Street);
                cmd.Parameters.AddWithValue("@City", objAgent.City);
                cmd.Parameters.AddWithValue("@State", objAgent.State);
                cmd.Parameters.AddWithValue("@Zip", objAgent.Zip);
                cmd.Parameters.AddWithValue("@Country", objAgent.Country);
                cmd.Parameters.AddWithValue("@Mobile", objAgent.Mobile);
                cmd.Parameters.AddWithValue("@Phone", objAgent.Phone);
                cmd.Parameters.AddWithValue("@ContactPerson", objAgent.ContactPerson);
                cmd.Parameters.AddWithValue("@ReferredBy", objAgent.ReferredBy);
                cmd.Parameters.AddWithValue("@Status", objAgent.Status);
                cmd.Parameters.AddWithValue("@Balance", objAgent.Balance);
                cmd.Parameters.AddWithValue("@LoginUrl", objAgent.LoginUrl);
                cmd.Parameters.AddWithValue("@SecurityCode", objAgent.SecurityCode);
                cmd.Parameters.AddWithValue("@SMTPServer", objAgent.SMTPServer);
                cmd.Parameters.AddWithValue("@SMTPPort", objAgent.SMTPPort);
                cmd.Parameters.AddWithValue("@SMTPUsername", objAgent.SMTPUsername);
                cmd.Parameters.AddWithValue("@SMTPPassword", objAgent.SMTPPassword);
                cmd.Parameters.AddWithValue("@Deleted", objAgent.Deleted);
                cmd.Parameters.AddWithValue("@CreatedOnUtc", objAgent.CreatedOnUtc);
                cmd.Parameters.AddWithValue("@UpdatedOnUtc", objAgent.UpdatedOnUtc);
                cmd.Parameters.AddWithValue("@CurrentBalance", objAgent.CurrentBalance);

                a.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch
            {
                //throw new Exception(ex.Message);
                return result;
            }

            finally
            {
                a.Close();
            }
            return result;
        }
    }
}