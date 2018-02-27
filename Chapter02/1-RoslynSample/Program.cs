using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = CSharpSyntaxTree.ParseText("class Foo { void Bar() {  } }");
            var node = tree.GetRoot();

            var res = SyntaxFactory.ClassDeclaration("Foo")
                                   .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(new[]
                                   {
                                       SyntaxFactory.MethodDeclaration(
                                           SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)), "Bar"
                                       ).WithBody(SyntaxFactory.Block())
                                   }))
                                   .NormalizeWhitespace();

            Console.WriteLine(res.ToString());
        }
    }
}
