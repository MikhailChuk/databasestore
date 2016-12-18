using Store.Models;
using Store.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Pages.Helpers;
using System.Web.Routing;

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
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterGadgets().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            return FilterGadgets()
                .OrderBy(g => g.GadgetId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Gadget> FilterGadgets()
        {
            IEnumerable<Gadget> gadget = repository.Gadgets;
            string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
            return currentCategory == null ? gadget :
                gadget.Where(p => p.Category == currentCategory);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedGadgetId;
                if (int.TryParse(Request.Form["add"], out selectedGadgetId))
                {
                    Gadget selectedGadget = repository.Gadgets
                        .Where(g => g.GadgetId == selectedGadgetId).FirstOrDefault();

                    if (selectedGadget != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedGadget, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                            Request.RawUrl);

                        Response.Redirect(RouteTable.Routes
                            .GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }

            }
        }
    }
}