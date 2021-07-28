using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTest
{
    public partial class AllUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AllData();
        }

        private void AllData()
        {
            var list = DAL.UsersDAL.FetchList();
            if (list.Count <= 0)
            {
                return;
            }
            gvlist.DataSource = list;
            gvlist.DataBind();

            gvlist.UseAccessibleHeader = true;
            gvlist.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvlist.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}