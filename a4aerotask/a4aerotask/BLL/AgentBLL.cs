using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using a4aerotask.Models;
using a4aerotask.DAL;

namespace a4aerotask.BLL
{
    public class AgentBLL
    {
        AgentDAL agentDAL = new AgentDAL();
        internal int SaveAgent(Agent objAgent)
        {
            return agentDAL.SaveAgent(objAgent);
        }

        internal List<Agent> GetAgentInfo()
        {
            return agentDAL.GetAgentInfo();
        }

        internal Agent GetAgentInfoById(Agent objAgent)
        {
            return agentDAL.GetAgentInfoById(objAgent);
        }

        internal int AgentUpdate(Agent objAgent)
        {
            return agentDAL.AgentUpdate(objAgent);
        }

        internal int DeleteAgent(Agent objAgent)
        {
            return agentDAL.DeleteAgent(objAgent);
        }
    }
}