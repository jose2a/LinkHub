using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class AdminBs : BaseBs
    {
        public void ApproveOrReject(List<int> ids, string Status)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in ids)
                    {
                        var myUrl = urlBs.GetById(item);
                        myUrl.IsApproved = Status;
                        urlBs.Update(myUrl);
                    }
                    Trans.Complete();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
    }
}
