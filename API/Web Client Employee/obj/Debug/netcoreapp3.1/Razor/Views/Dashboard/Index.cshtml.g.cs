#pragma checksum "D:\MCC\MVC\API2\API\Web Client Employee\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e19cfee631f0738590aa436ed87c7608d23f4c5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
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
#line 1 "D:\MCC\MVC\API2\API\Web Client Employee\Views\_ViewImports.cshtml"
using Web_Client_Employee;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MCC\MVC\API2\API\Web Client Employee\Views\_ViewImports.cshtml"
using Web_Client_Employee.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e19cfee631f0738590aa436ed87c7608d23f4c5b", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9575b606de4d8de6d57f884318209a743d29b3de", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Helper/Curency.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "D:\MCC\MVC\API2\API\Web Client Employee\Views\Dashboard\Index.cshtml"
  
    Layout = "_LayoutSBAdmin";
    ViewData["Title"] = "Data Account";

#line default
#line hidden
#nullable disable
            DefineSection("Header", async() => {
                WriteLiteral("\r\n    <div class=\"row mb-3\">\r\n        <div class=\"col-sm-4\">\r\n            <h1 class=\"h3 mb-1 text-info\"><i class=\"fas fa-fw fa-tachometer-alt\"></i> </h1>\r\n        </div>\r\n        <div class=\"col-sm-8\"></div>\r\n    </div>\r\n");
            }
            );
            WriteLiteral(@"<div class=""row justify-content-center"">
    <div class=""col-lg-3 mb-4"">
        <div class=""card bg-light text-black shadow"">
            <a href=""#"" ondblclick=""window.location.href='/Employees'"" class=""btn btn-block"">
                <div class=""card-body text-center"">
                    <h1 class=""h1 mb-1 text-secondary""><i class=""fas fa-user-tie""></i></h1>
                    Employeees
                </div>
            </a>
        </div>
    </div>
    <div class=""col-lg-3 mb-4"">
        <div class=""card bg-light text-black shadow"">
            <a href=""#"" ondblclick=""window.location.href='/Educations'"" class=""btn btn-block"">
                <div class=""card-body text-center"">
                    <h1 class=""h1 mb-1 text-warning""><i class=""fas fa-microscope""></i></h1>
                    Educations
                </div>
            </a>
        </div>
    </div>
    <div class=""col-lg-3 mb-4"">
        <div class=""card bg-light text-black shadow"">
            <a href=""#"" ondblcl");
            WriteLiteral(@"ick=""window.location.href='/Universities'"" class=""btn btn-block"">
                <div class=""card-body text-center"">
                    <h1 class=""h1 mb-1 text-primary""><i class=""fas fa-building""></i></h1>
                    Universities
                </div>
            </a>
        </div>
    </div>
    <div class=""col-lg-3 mb-4"">
        <div class=""card bg-light text-black shadow"">
            <a href=""#"" ondblclick=""window.location.href='/Employees/Jobs'"" class=""btn btn-block"">
                <div class=""card-body text-center"">
                    <h1 class=""h1 mb-1 text-success""><i class=""fas fa-laptop-code""></i></h1>
                    Employee Jobs
                </div>
            </a>
        </div>
    </div>
    <div class=""col-lg-3 mb-4"">
        <div class=""card bg-light text-black shadow"">
            <a href=""#"" ondblclick=""window.location.href='/Accounts'"" class=""btn btn-block"">
                <div class=""card-body text-center"">
                    <h1 class=""h1 ");
            WriteLiteral(@"mb-1 text-secondary""><i class=""fas fa-user-circle""></i></h1>
                    Users Accounts
                </div>
            </a>
        </div>
    </div>
    <div class=""col-lg-3 mb-4"">
        <div class=""card bg-light text-black shadow"">
            <a href=""#"" ondblclick=""window.location.href='/Roles'"" class=""btn btn-block"">
                <div class=""card-body text-center"">
                    <h1 class=""h1 mb-1 text-gray-800""><i class=""fas fa-users-cog""></i></h1>
                    Accounts Roles
                </div>
            </a>
        </div>
    </div>
    <div class=""col-lg-3 mb-4"">
        <div class=""card bg-light text-black shadow"">
            <a href=""#"" ondblclick=""window.location.href='/Employees/Chart'"" class=""btn btn-block"">
                <div class=""card-body text-center"">
                    <h1 class=""h1 mb-1 text-info""><i class=""fas fa-chart-pie""></i></h1>
                    Employees Report
                </div>
            </a>
        </div>");
            WriteLiteral(@"
    </div>
    <div class=""col-lg-3 mb-4"">
        <div class=""card bg-light text-black shadow"">
            <a href=""#"" ondblclick=""window.location.href='/Employees/JobChart'"" class=""btn btn-block"">
                <div class=""card-body text-center"">
                    <h1 class=""h1 mb-1 text-info""><i class=""fas fa-chart-line""></i></h1>
                    Jobs Report
                </div>
            </a>
        </div>
    </div>




</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e19cfee631f0738590aa436ed87c7608d23f4c5b7896", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/buttons/2.1.0/js/dataTables.buttons.min.js""></script>
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/buttons/2.1.0/js/buttons.html5.min.js""></script>
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/buttons/2.1.0/js/buttons.print.min.js""></script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591