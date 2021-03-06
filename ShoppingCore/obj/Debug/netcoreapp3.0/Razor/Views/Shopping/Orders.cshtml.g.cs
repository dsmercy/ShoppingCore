#pragma checksum "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33e27f153ff0eb5a6e5f58ae69d3c89d4a4b2d66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shopping_Orders), @"mvc.1.0.view", @"/Views/Shopping/Orders.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\_ViewImports.cshtml"
using ShoppingCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\_ViewImports.cshtml"
using ShoppingCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33e27f153ff0eb5a6e5f58ae69d3c89d4a4b2d66", @"/Views/Shopping/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"536112eb7e754cf3972e0d14be0374e1ea555c1a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shopping_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShoppingCore.Models.Shippingdetail>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("cartform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("clearfix"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
  
    ViewData["Title"] = "Orders";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .cart-wrapper .cart-items .remove {
        width: 80px;
        float: left;
        padding: 3px 0px 5px 8px;
        margin: 38px 0px 0 -8px;
        background-color: darkred;
        border-radius: 10px;
    }

    .item-image p {
        font-size: large;
    }
</style>
<!-- BEGIN .main-content-wrapper -->
<div class=""main-content-wrapper"">

    <!-- BEGIN .cart-wrapper -->
    <div class=""cart-wrapper"">
        <div class=""main-title"">
            <p class=""custom-font-1"">All Orders</p>
            <a href=""Home/Catalog"" class=""continue"">continue shopping</a>
        </div>

        <div class=""cart-titles"">
            <p class=""item-image"" style=""font-size:larger"">Product name</p>
            <p class=""quantity"" style=""font-size:larger"">Reciever Name</p>
            <p class=""price"" style=""font-size:larger;width: 15%;"" >Amount Paid</p>
            <p class=""price"" style=""font-size:larger"">Ordered Date</p>
        </div>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33e27f153ff0eb5a6e5f58ae69d3c89d4a4b2d665876", async() => {
                WriteLiteral("\r\n\r\n            <div class=\"cart-items\">\r\n\r\n");
#nullable restore
#line 40 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"item-image\">\r\n                        <div class=\"image-wrapper-1\">\r\n                            <div class=\"image\">\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 1525, "\"", 1568, 2);
                WriteAttributeValue("", 1532, "/Home/ProductDetails/", 1532, 21, true);
#nullable restore
#line 46 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
WriteAttributeValue("", 1553, item.ProductId, 1553, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><img class=\"product-image-resizable-94x94\"");
                BeginWriteAttribute("src", " src=\"", 1612, "\"", 1659, 1);
#nullable restore
#line 46 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
WriteAttributeValue("", 1618, Url.Content("/ProductImage/"+item.Image), 1618, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" alt=""Item Image"" style=""position: absolute; left: -3px; top: 13px; display: block;""></a>
                            </div>
                        </div>
                        <div class=""clear""></div>
                    </div>
                    <div class=""desc"">
                        <h3 class=""custom-font-1""><a");
                BeginWriteAttribute("href", " href=\"", 1990, "\"", 2033, 2);
                WriteAttributeValue("", 1997, "/Home/ProductDetails/", 1997, 21, true);
#nullable restore
#line 52 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
WriteAttributeValue("", 2018, item.ProductId, 2018, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 52 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
                                                                                            Write(item.ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></h3>\r\n\r\n                    </div>\r\n                    <div class=\"price custom-font-1\" style=\"width: 19%;\">\r\n                        <span class=\"money\">");
#nullable restore
#line 56 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
                                       Write(item.RecieverName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"price custom-font-1\">\r\n                        <span class=\"money\">");
#nullable restore
#line 59 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
                                       Write(item.AmountPaid);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"price custom-font-1\">\r\n                        <span class=\"money\">");
#nullable restore
#line 62 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
                                       Write(item.OrderDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    </div>\r\n\r\n                    <div class=\"clear\"></div>\r\n                </div>\r\n");
#nullable restore
#line 67 "C:\Users\dsmer\source\repos\ShoppingCore\ShoppingCore\Views\Shopping\Orders.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"clear\"></div>\r\n    <!-- END .cart-wrapper -->\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShoppingCore.Models.Shippingdetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
