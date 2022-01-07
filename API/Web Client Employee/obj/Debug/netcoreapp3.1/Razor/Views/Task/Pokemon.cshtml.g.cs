#pragma checksum "D:\MCC\MVC\API2\API\Web Client Employee\Views\Task\Pokemon.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0493bfa0781017db2e75d438e635636e1eea773"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Task_Pokemon), @"mvc.1.0.view", @"/Views/Task/Pokemon.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0493bfa0781017db2e75d438e635636e1eea773", @"/Views/Task/Pokemon.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9575b606de4d8de6d57f884318209a743d29b3de", @"/Views/_ViewImports.cshtml")]
    public class Views_Task_Pokemon : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\MCC\MVC\API2\API\Web Client Employee\Views\Task\Pokemon.cshtml"
  
    Layout = "_LayoutLatihan";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""javaScriptExercise"">
    <div class=""row "">
        <section class=""headerbar"">...</section>
        <section class=""thumbnail "">
            <div class=""cycleFrame wow slideInRight"">
                <img src=""https://cdn.dribbble.com/users/264162/screenshots/16734417/media/282a4351c33576bb1d47b05b59e24a52.png?compress=1&resize=1200x900&vertical=top""
                     alt=""Lama"" />
            </div>
            <h1 class=""title-thumbnail"">
                Amet Consectetur
            </h1>
            <p class=""desc-thumbnail"">
                Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.
            
            </p>
        </section>
        <section class=""menubox"">
            <h1 class=""title-menubox"">
");
            WriteLiteral(@"            </h1>
            <ul id=""menues"" class=""menues"">
                <li class=""box"">HOME</li>
                <li class=""box"">ANIMAL'S</li>
                <li class=""box"">CAT</li>
            </ul>
        </section>
        <section class=""expandList"">
            <h1 class=""title-menubox"">
                Animal's List
            </h1>
            <table class=""table "">
                <thead>
                    <tr class=""table-success"">
                        <th scope=""col"">No</th>
                        <th scope=""col"">Name</th>
                        <th scope=""col""></th>
                    </tr>
                </thead>
                <tbody class=""TableList"">
                </tbody>
            </table>
        </section>
    </div>

</div>
<!-- Modal -->
<div class=""modal fade"" id=""details"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content");
            WriteLiteral(@""">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Modal title</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body spiretes-content"">

            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>
<script>
    var dataArray = [];
    $.ajax({
        url: ""https://pokeapi.co/api/v2/pokemon"",
        success: function (e) {
            console.log(e);
            var tableBody = """";
            $.each(e.results, (key, val) => {
                tableBody += `
              <tr class=""${key % 2 == 0 ? 'table-Active' : 'table-success'} "">
                  <th scope=""row"">${key + 1}</th>
                  ");
            WriteLiteral(@"<td>${val.name}</td>
                   <td><button type=""button"" class=""btn btn-outline-secondary buttonCircle ""`;
                tableBody += `onclick=""DetailsAccess('${val.url}')""`;
                tableBody += `data-toggle=""modal"" data-target=""#details"">Detail</button></td>
                </tr>`;
            });
            $('.TableList').html(tableBody);

        }
    });

    const DetailsAccess = (url) => {
        console.log(""---------From Results------------"");
        console.log(url);
        $.ajax({
            url: url,
            success: function (e) {
                var tableBody = """";
                console.log(""---------Details Results------------"");
                Abilty = getAbilty(e.abilities);
                tableBody += ContentSpirets(e.forms[0].name, e.sprites.other.dream_world.front_default,Abilty);
                new WOW().init();
                
                tableBody += EachStats(e.stats);
                $('.spiretes-content').html(tableBody");
            WriteLiteral(@");

            }
        });
    }
    const EachStats = (stats) => {
        let data = ``;
        $.each(stats, (i, val) => {
            data += `
              <div class=""card-body"">
                 <div class=""progress"">
                  <div class=""progress-bar"" role=""progressbar"" style=""width: ${val.base_stat}%;opacity: ${0.1+(val.base_stat/100)};"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100"">  ${val.base_stat} ${val.stat.name}</div>
                </div>
               </div>
                    `;
        });
           return ContentStats(data);
    }
    const getAbilty=(dataAblity)=>{
        let htmDispaly = """";
        $.each(dataAblity, (i, value) => {
            console.log(""---------From dataAblity Each------------"");
            console.log(value);
            htmDispaly += `<button type=""button"" class=""btn ${i % 2 == 1 ? 'btn-secondary' :'btn-info'}"">${value.ability.name}</button>`;
        });
        return htmDispaly ;
    }
    const Content");
            WriteLiteral(@"Spirets = (name, url,abilty) => {
        return `
                                            <section class=""thumbnail"">
                                                <h1 class=""title-thumbnail"">
                                                    ${name}
                                                </h1>
                                                <div class=""cycleFrame mini  "">
                                                    <img class=""miniImg"" src=""${url}""
                                                         alt=""Lama"" />
                                                </div>
                                                <h2 class=""title-thumbnail"">
                                                   Abilty :<br>
                                                    <div class=""btn-group"" role=""group"" aria-label=""Basic example"">
                                                    ${abilty}
                                                    </div>
                         ");
            WriteLiteral(@"                       </h2>


                                            </section>
`;
    }
    const ContentStats = (data) => {
        return `
            <div class=""card"">
             <div class=""card-header"">Stats</div>
                        ${data}
            </div>
`;
    }
</script>
");
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
