#pragma checksum "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5822692d8b60c78fc246ac829211166cac5224d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Payments), @"mvc.1.0.view", @"/Views/Admin/Payments.cshtml")]
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
#line 1 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\_ViewImports.cshtml"
using Karcis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\_ViewImports.cshtml"
using Karcis.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5822692d8b60c78fc246ac829211166cac5224d4", @"/Views/Admin/Payments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e6f190ad19e2292ffa81e9cf26bf665e92e1e14", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Payments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BookingViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
      
        Layout = null;
        var number = 1;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
     foreach (var booking in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"paymentsContent\">\r\n        <div class=\"contentTextNumber\">\r\n            <p class=\"contentText\">");
#nullable restore
#line 10 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
                              Write(number);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</p>\r\n");
#nullable restore
#line 11 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
               number = number + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"contentTextId\">\r\n            <p class=\"contentText\">Booking #");
#nullable restore
#line 14 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
                                       Write(booking.BookingNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"contentTextUsername\">\r\n            <p class=\"contentText\">");
#nullable restore
#line 17 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
                              Write(booking.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"contentTextStatus\">\r\n            <p class=\"contentText\">Status: ");
#nullable restore
#line 20 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
                                      Write(booking.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"contentTextAction\">\r\n");
#nullable restore
#line 23 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
             if(booking.Status != "Declined" && booking.Status != "Approved"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button class=\"bookingDetail\"");
            BeginWriteAttribute("onclick", " onclick=\"", 851, "\"", 899, 3);
            WriteAttributeValue("", 861, "getBookingByID(", 861, 15, true);
#nullable restore
#line 24 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
WriteAttributeValue("", 876, booking.BookingNumber, 876, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 898, ")", 898, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Detail</button>\r\n");
#nullable restore
#line 25 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n");
#nullable restore
#line 28 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Admin\Payments.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BookingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591