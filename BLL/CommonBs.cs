using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Transactions;

namespace BLL
{
    public class CommonBs : BaseBs
    {
        public void InsertQuickUrl(QuickURLSubmitModel myQuickUrl)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    tbl_User user = myQuickUrl.MyUser;
                    user.Password = user.ConfirmPassword = "123456";
                    user.Role = "U";
                    userBs.Insert(user);

                    tbl_Url myUrl = myQuickUrl.MyUrl;
                    myUrl.UserId = user.UserId;
                    myUrl.UrlDesc = myUrl.UrlTitle;
                    myUrl.IsApproved = "P";
                    urlBs.Insert(myUrl);

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
