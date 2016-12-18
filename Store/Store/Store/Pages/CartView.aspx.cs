using System;
using System.Collections.Generic;
using Store.Models;
using Store.Pages.Helpers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Models.Repository;
using System.Web.Routing;
using System.Linq;

namespace Store.Pages
{
    public partial class CartView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int gadgetId;
                if (int.TryParse(Request.Form["remove"], out gadgetId))
                {
                    Gadget gadgetToRemove = repository.Gadgets
                        .Where(g => g.GadgetId == gadgetId).FirstOrDefault();
                    if (gadgetToRemove != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(gadgetToRemove);
                    }
                }
            }

        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }
        public string CheckoutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "checkout",
                    null).VirtualPath;
            }
}