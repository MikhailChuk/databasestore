<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="Store.Pages.Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Store</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%
                foreach (Store.Models.Gadget gadget in GetGadgets())
                {
                    Response.Write(String.Format(@"
                        <div class='item'>
                            <h3>{0}</h3>
                            {1}
                            <h4>{2:c}</h4>
                        </div>", 
                        gadget.Name, gadget.Description, gadget.Price));
                }
            %>
        </div>
    </form>
</body>
</html>
