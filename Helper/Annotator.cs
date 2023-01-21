using System.Net;
using System.Xml;
using HtmlAgilityPack;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Helper;

public class Annotator : CSharpSyntaxRewriter
{
    private string methodName = string.Empty;

    public Annotator() : base(true)
    {

    }

    public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        if ( node.Identifier.ToString().StartsWith("SDL_") )
        {
            methodName = node.Identifier.ToString();
        } else
        {
            return base.VisitMethodDeclaration(node);
        }



        if ( !node.HasLeadingTrivia ||
             node.GetLeadingTrivia().Where(x => x.Kind() is SyntaxKind.SingleLineDocumentationCommentTrivia).Count() ==
             0 )
        {



            Console.WriteLine($"Method {methodName} does not have trivia");
            var trivias = GetDocumentationFromWeb(methodName);
            var newNode = node.WithLeadingTrivia(trivias);
            return newNode;

        }

        return base.VisitMethodDeclaration(node);
    }

    private List<SyntaxTrivia> GetDocumentationFromWeb(string methodName)
    {
        Thread.Sleep(250);
        List<SyntaxTrivia> trivias = new List<SyntaxTrivia>();
        string url = $"https://wiki.libsdl.org/SDL2/{methodName}";

        string page = string.Empty;
        using ( WebClient client = new WebClient() )
        {
            page = client.DownloadString(url);
        }

        if ( string.IsNullOrEmpty(page) )
        {
            return trivias;
        }

        var doc = new HtmlDocument();
        doc.LoadHtml(page);

        var p = doc.DocumentNode.SelectSingleNode("//h1").NextSibling.NextSibling;

        var summary = p.InnerText;
        if ( !string.IsNullOrEmpty(summary) && summary.Contains("No such page") )
        {
            summary = string.Empty;
        }

        trivias.Add(
            SyntaxFactory.SyntaxTrivia(
                SyntaxKind.SingleLineCommentTrivia,
                $"///<summary>{summary}</summary>{Environment.NewLine}"));

        trivias.Add(
            SyntaxFactory.SyntaxTrivia(
                SyntaxKind.SingleLineCommentTrivia,
                $"///<remarks><a href=\"{url}\">SDL2 Documentation</a></remarks>{Environment.NewLine}"));

        return trivias;
    }

    /*public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
    {

        if ( string.IsNullOrEmpty(methodName) )
        {
            return base.VisitTrivia(trivia);
        }

        if ( trivia.Kind() != SyntaxKind.SingleLineDocumentationCommentTrivia )
        {
            return base.VisitTrivia(trivia);
        }


        var lineToAdd = $"///<remarks><a href=\"{methodName}\">SDL2 Documentation</a>{Environment.NewLine}";

        var expression = SyntaxFactory.SyntaxTrivia(
            SyntaxKind.SingleLineCommentTrivia, lineToAdd);


        return expression;
    }*/

    /*private string OriginalCode { get; }

    private CompilationUnitSyntax Root { get; }
    private FileScopedNamespaceDeclarationSyntax NamespaceDeclaration { get; }
    
    private ClassDeclarationSyntax ClassDeclaration { get; }
    
    public Annotator(string fileName)
    {
        OriginalCode = File.ReadAllText(fileName);
        
        SyntaxTree tree = CSharpSyntaxTree.ParseText(OriginalCode);
        Root = tree.GetCompilationUnitRoot();

        NamespaceDeclaration = (FileScopedNamespaceDeclarationSyntax)Root.Members[0];
        ClassDeclaration = (ClassDeclarationSyntax)NamespaceDeclaration.Members[0];

        HandleMethods(ClassDeclaration);

    }
    private void HandleMethods(ClassDeclarationSyntax classDeclarationSyntax)
    {
        var classMethods = ClassDeclaration.Members.Select(x => x)
                                                 .Where(x => x is MethodDeclarationSyntax);

        foreach ( var member in classMethods )
        {
            if ( member is not MethodDeclarationSyntax method )
            {
                continue;
            }
            
            var stringIdentifier = method.Identifier.ToString();
            
            // Skip non-SDL methods
            if ( !stringIdentifier.StartsWith(@"SDL_") )
            {
                continue;
            }

            var documentationUrl = @$"https://wiki.libsdl.org/SDL2/{stringIdentifier}";
            
            // Create new docblock

            var documentation =

            CSharpSyntaxRewriter
            
            var triviaEnumerable = new[] {
                SyntaxFactory.SyntaxTrivia(
                    SyntaxKind.SingleLineDocumentationCommentTrivia,
                    documentation)
            };
            var oldRoot = method.FindTrivia(0, false);

            var newMethod = SyntaxFactory.ParseSyntaxTree(method.GetText());
            newMethod.GetRoot().InsertTriviaAfter(
                oldRoot,
                triviaEnumerable   
            );
            
            Console.WriteLine(newMethod.GetText().ToString());
            Environment.Exit(0);

            

        }
        
        
        

    }

    public void HandleEnums(ClassDeclarationSyntax classDeclarationSyntax)
    {
        var classEnums = classDeclarationSyntax.Members.Select(x => x)
                                               .Where(x => x is EnumDeclarationSyntax);
    }

    public void HandleStructs(ClassDeclarationSyntax classDeclarationSyntax)
    {
        var classStructs = classDeclarationSyntax.Members.Select(x => x)
                                                 .Where(x => x is StructDeclarationSyntax);
    }

    public void HandleVariables(ClassDeclarationSyntax classDeclarationSyntax)
    {
        var classVars = classDeclarationSyntax.Members.Select(x => x)
                                              .Where(x => x is FieldDeclarationSyntax);
        
        
    }

    public string GetUpdatedCode()
    {
        throw new NotImplementedException();
    }

    private DocumentationNode GetDocumentationFromWeb(string url)
    {
        throw new NotImplementedException();
    }*/
}

internal class DocumentationNode
{
    /// <summary>
    /// 
    /// </summary>
    public string Summary { get; set; }

    public string ReturnValue { get; set; }
    public string Remarks { get; set; }

}
