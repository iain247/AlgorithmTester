#pragma checksum "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e4972a63322b76e20adbec4af6cce49d2f70a2f"
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
#line 1 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\_ViewImports.cshtml"
using AlgorithmTester;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\_ViewImports.cshtml"
using AlgorithmTester.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e4972a63322b76e20adbec4af6cce49d2f70a2f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34f66263af1f66ba319ce02a5bb05391a1cb0a2b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlgorithmTester.Models.FormModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e4972a63322b76e20adbec4af6cce49d2f70a2f4355", async() => {
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
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n\r\n<div class=\"text-center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e4972a63322b76e20adbec4af6cce49d2f70a2f5551", async() => {
                WriteLiteral("\r\n        <div>\r\n            <h5>Enter your code in the box below</h5>\r\n            <br />\r\n            <div class=\"container-fluid\" id=\"code-container\">\r\n                <textarea class=\"form-control\" id=\"code-input\" name=\"Code\">");
#nullable restore
#line 18 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                                                      Write(Model.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea>\r\n                <div class=\"topright\">\r\n                    <image id=\"reset\" src=\"images/reset.png\" alt=\"Reset Button\" />\r\n                </div>\r\n");
#nullable restore
#line 22 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                  
                    if (!(Model.UserMessage.Equals(String.Empty)))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <textarea class=\"form-control\" id=\"user-message\" name=\"UserMessage\" readonly>");
#nullable restore
#line 25 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                                                                                Write(Model.UserMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea>\r\n");
#nullable restore
#line 26 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </div>
        </div>

        <div>
            <h5>Enter input and expected output</h5>
            <div id=""data"" class=""row"">

                <div class=""input-group col-5"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Input Arguments</span>
                    </div>
                    <input class=""form-control"" id=""input-arguments"" type=""text"" />
                </div>

                <div class=""input-group col-5"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Output Arguments</span>
                    </div>
                    <input class=""form-control"" id=""output-arguments"" type=""text"" />
                </div>

                <div class=""input-group col"">
                    <input class=""btn btn-primary btn-sm btn-block"" id=""add-button"" type=""button"" value=""Add"" />
                </div>

            </div>
        </div>

   ");
                WriteLiteral("     <!-- Attach the number of rows from the model to a div to be accessed by javascript -->\r\n        <div id=\"rowNum\" data-name=\"");
#nullable restore
#line 57 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                Write(Model.NumData + 1);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"""></div>
        <div>
            <table class=""table table-striped"" id=""data-table"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Input Arguments</th>
                        <th scope=""col"">Output</th>
                        <th scope=""col"">Result</th>
                        <th scope=""col""></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 70 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                      
                        for (int i = 0; i < Model.InputData.Count; i++)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <th scope=\"row\">");
#nullable restore
#line 74 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                            Write(i+1);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                <td>");
#nullable restore
#line 75 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                               Write(Model.InputData[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("<input type=\"hidden\" name=\"InputData[]\"");
                BeginWriteAttribute("value", " value=\"", 2867, "\"", 2894, 1);
#nullable restore
#line 75 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
WriteAttributeValue("", 2875, Model.InputData[i], 2875, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                                <td>");
#nullable restore
#line 76 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                               Write(Model.OutputData[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("<input type=\"hidden\" name=\"OutputData[]\"");
                BeginWriteAttribute("value", " value=\"", 3001, "\"", 3029, 1);
#nullable restore
#line 76 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
WriteAttributeValue("", 3009, Model.OutputData[i], 3009, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                                <td>");
#nullable restore
#line 77 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                               Write(Model.Results[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>\r\n");
#nullable restore
#line 79 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                      
                                        if (Model.InputData[i] != "")
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <image class=\"delete-row\" src=\"images/delete.png\" alt=\"delete\" />\r\n");
#nullable restore
#line 83 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 87 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tbody>
            </table>
        </div>

        <div>
            <input type=""submit"" value=""Go"" class=""btn btn-success btn-lg btn-block"" id=""go"" />
            <div class=""form-group row"" id=""output"">
                <label class=""col-sm-2 col-form-label"" for=""accuracy"">Accuracy</label>
                <input class=""col-sm-4 form-control"" type=""text"" id=""accuracy"" name=""Accuracy""");
                BeginWriteAttribute("value", " value=\"", 4023, "\"", 4046, 1);
#nullable restore
#line 97 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
WriteAttributeValue("", 4031, Model.Accuracy, 4031, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly />\r\n                <label class=\"col-sm-2 col-form-label\" for=\"speed\">Speed</label>\r\n                <input class=\"col-sm-4 form-control\" type=\"text\" id=\"speed\" name=\"Speed\" readonly />\r\n            </div>\r\n        </div>\r\n\r\n");
#nullable restore
#line 103 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
          
            if (!(Model.Times is null))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <table class=\"table table-sm table-bordered\" id=\"speed-table\">\r\n                    <thead>\r\n                        <tr>\r\n                            <th scope=\"col\"");
                BeginWriteAttribute("colspan", " colspan=\"", 4533, "\"", 4586, 1);
#nullable restore
#line 109 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
WriteAttributeValue("", 4543, Model.TestArguments[0].ArgumentNames.Count, 4543, 43, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Testing Arguments</th>\r\n                            <th scope=\"col\" rowspan=\"2\">Times</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n                        <tr>\r\n");
#nullable restore
#line 115 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                              
                                for (int i = 0; i < Model.TestArguments[i].ArgumentNames.Count; i++)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <th scope=\"col\">");
#nullable restore
#line 118 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                               Write(Model.TestArguments[0].ArgumentNames[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n");
#nullable restore
#line 119 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 122 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                          
                            for (int i = 0; i < Model.Times.Count; i++)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n");
#nullable restore
#line 126 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                      
                                        for (int j = 0; j < Model.TestArguments[i].ArgumentNames.Count; j++)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td>");
#nullable restore
#line 129 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                           Write(Model.TestArguments[i].InputData[j]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 130 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <td>");
#nullable restore
#line 132 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                                   Write(Model.Times[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 134 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 138 "C:\Users\iainr\Documents\repos\AlgorithmTester\Views\Home\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlgorithmTester.Models.FormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
