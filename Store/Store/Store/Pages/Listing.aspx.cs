using Store.Models;
using Store.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        private int pageSize = 4;

        protected int CurrentPage
        {
            get
            {
                int page;
                return int.TryParse(Request.QueryString["page"], out page) ? page : 1;
            }
        }

        protected IEnumerable<Gadget> GetGadgets()
        {
            return repository.Gadgets
                .OrderBy(g => g.GadgetId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}