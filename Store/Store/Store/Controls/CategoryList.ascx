﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" 
   Inherits="Store.Controls.CategoryList" %>

<%= CreateHomeLinkHtml() %>

<% foreach (string category in GetCategories()) {
       Response.Write(CreateLinkHtml(category));       
}%>
