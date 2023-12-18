using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public class EmpInfoRepository
    {
        private BlogContext context;

        public EmpInfoRepository()
        {
            this.context = new BlogContext();
        }

        public void SaveEmpInfo(EmpInfo empInfo)
        {
            context.EmpInfos.Add(empInfo);
            context.SaveChanges();
        }

        public List<EmpInfo> GetAllEmpInfo()
        {
            return context.EmpInfos.ToList();
        }

        public bool ValidateEmployee(string emailId, int passCode)
        {
            return context.EmpInfos.Any(e => e.EmailId == emailId && e.PassCode == passCode);
        }
    }
}
