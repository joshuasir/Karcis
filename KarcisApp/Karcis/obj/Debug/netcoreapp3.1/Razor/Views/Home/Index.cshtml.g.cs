#pragma checksum "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4969ad7f24a9d9b88dba2385d24f24ed5094685"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4969ad7f24a9d9b88dba2385d24f24ed5094685", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e6f190ad19e2292ffa81e9cf26bf665e92e1e14", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/index.css?ver=1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    if (Model.User.UserName!=null)
    {

        Layout = "_LoggedinLayout";

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("stylesheets", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c4969ad7f24a9d9b88dba2385d24f24ed50946854520", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("<div class=\"banner-image overlay w-100 vh-100 d-flex align-items-center\">\r\n    <div class=\"content text-start text-home container\">\r\n        <h1 id=\"EventName\" class=\"text-white\">");
#nullable restore
#line 18 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Home\Index.cshtml"
                                         Write(Model.Event.EventName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <h4>");
#nullable restore
#line 19 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Home\Index.cshtml"
       Write(Model.Event.EventEndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
            WriteLiteral("@");
#nullable restore
#line 19 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Home\Index.cshtml"
                                     Write(Model.Event.EventLocation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4><br><br>\r\n        <div class=\"20day\">\r\n            <h5>\r\n                <span>");
#nullable restore
#line 22 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Home\Index.cshtml"
                 Write(Model.Event.Days);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>days left
            </h5>
        </div><br><br><br>
        <a target=""_blank"" href=""https://wa.me/6285156615076?text=Halo%20Saya%20Ingin%20Bertanya%20Mengenai%20FESTGLORY"">Contact Us</a>
    </div>
</div>
<!-- Home Part 2 -->
<div id=""AboutFestGlory"">
    <h1 class=""TitleDescription"">ABOUT ");
#nullable restore
#line 30 "C:\Users\Joshua\Desktop\KarcisApp\Karcis\Views\Home\Index.cshtml"
                                  Write(Model.Event.EventName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    <div class=""Description"">
        FESTGLORY 2022 is back to town with unpredictable innovations! Our stage will be sparked by your favorite artists: Taylor Swift, Hardwell, Lany, and Justin Bieber
    </div>
</div>

<div id=""mainTicketContainer"">
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4969ad7f24a9d9b88dba2385d24f24ed50946857966", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        //Navbar scroll
        var navbar = document.querySelector('nav')
        navbar.classList.remove('background-navbar', 'shadow');
        window.addEventListener('scroll', function () {
            if (window.pageYOffset > 100) {
                navbar.classList.add('background-navbar', 'shadow');
            } else {
                navbar.classList.remove('background-navbar', 'shadow')
            }
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
