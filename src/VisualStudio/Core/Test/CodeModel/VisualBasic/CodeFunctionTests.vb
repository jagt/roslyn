' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis
Imports Microsoft.VisualStudio.LanguageServices.VisualBasic.CodeModel.Extenders
Imports Microsoft.VisualStudio.LanguageServices.VisualBasic.CodeModel.Interop
Imports Roslyn.Test.Utilities

Namespace Microsoft.VisualStudio.LanguageServices.UnitTests.CodeModel.VisualBasic
    Public Class CodeFunctionTests
        Inherits AbstractCodeFunctionTests

#Region "GetStartPoint() tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub GetStartPoint_MustOverride1()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Sub $$M()
End Class
</Code>

            TestGetStartPoint(code,
                Part(EnvDTE.vsCMPart.vsCMPartAttributes,
                     NullTextPoint),
                Part(EnvDTE.vsCMPart.vsCMPartAttributesWithDelimiter,
                     NullTextPoint),
                Part(EnvDTE.vsCMPart.vsCMPartBody,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartBodyWithDelimiter,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartHeader,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartHeaderWithAttributes,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartName,
                     TextPoint(line:=2, lineOffset:=22, absoluteOffset:=42, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartNavigate,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartWhole,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartWholeWithAttributes,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=24)))
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub GetStartPoint_MustOverride2()
            Dim code =
<Code>
MustInherit Class C
    &lt;System.CLSCompliant(True)&gt;
    MustOverride Sub $$M()
End Class
</Code>

            TestGetStartPoint(code,
                Part(EnvDTE.vsCMPart.vsCMPartAttributes,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=31)),
                Part(EnvDTE.vsCMPart.vsCMPartAttributesWithDelimiter,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=31)),
                Part(EnvDTE.vsCMPart.vsCMPartBody,
                     TextPoint(line:=3, lineOffset:=5, absoluteOffset:=57, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartBodyWithDelimiter,
                     TextPoint(line:=3, lineOffset:=5, absoluteOffset:=57, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartHeader,
                     TextPoint(line:=3, lineOffset:=5, absoluteOffset:=57, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartHeaderWithAttributes,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=31)),
                Part(EnvDTE.vsCMPart.vsCMPartName,
                     TextPoint(line:=3, lineOffset:=22, absoluteOffset:=74, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartNavigate,
                     TextPoint(line:=3, lineOffset:=5, absoluteOffset:=57, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartWhole,
                     TextPoint(line:=3, lineOffset:=5, absoluteOffset:=57, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartWholeWithAttributes,
                     TextPoint(line:=2, lineOffset:=5, absoluteOffset:=25, lineLength:=31)))
        End Sub

#End Region

#Region "GetEndPoint() tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub GetEndPoint_MustOverride1()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Sub $$M()
End Class
</Code>

            TestGetEndPoint(code,
                Part(EnvDTE.vsCMPart.vsCMPartAttributes,
                     NullTextPoint),
                Part(EnvDTE.vsCMPart.vsCMPartAttributesWithDelimiter,
                     NullTextPoint),
                Part(EnvDTE.vsCMPart.vsCMPartBody,
                     TextPoint(line:=2, lineOffset:=25, absoluteOffset:=45, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartBodyWithDelimiter,
                     TextPoint(line:=2, lineOffset:=25, absoluteOffset:=45, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartHeader,
                     TextPoint(line:=2, lineOffset:=25, absoluteOffset:=45, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartHeaderWithAttributes,
                     TextPoint(line:=2, lineOffset:=25, absoluteOffset:=45, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartName,
                     TextPoint(line:=2, lineOffset:=23, absoluteOffset:=43, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartNavigate,
                     TextPoint(line:=2, lineOffset:=25, absoluteOffset:=45, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartWhole,
                     TextPoint(line:=2, lineOffset:=25, absoluteOffset:=45, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartWholeWithAttributes,
                     TextPoint(line:=2, lineOffset:=25, absoluteOffset:=45, lineLength:=24)))
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub GetEndPoint_MustOverride2()
            Dim code =
<Code>
MustInherit Class C
    &lt;System.CLSCompliant(True)&gt;
    MustOverride Sub $$M()
End Class
</Code>

            TestGetEndPoint(code,
                Part(EnvDTE.vsCMPart.vsCMPartAttributes,
                     TextPoint(line:=2, lineOffset:=32, absoluteOffset:=52, lineLength:=31)),
                Part(EnvDTE.vsCMPart.vsCMPartAttributesWithDelimiter,
                     TextPoint(line:=2, lineOffset:=32, absoluteOffset:=52, lineLength:=31)),
                Part(EnvDTE.vsCMPart.vsCMPartBody,
                     TextPoint(line:=3, lineOffset:=25, absoluteOffset:=77, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartBodyWithDelimiter,
                     TextPoint(line:=3, lineOffset:=25, absoluteOffset:=77, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartHeader,
                     TextPoint(line:=3, lineOffset:=25, absoluteOffset:=77, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartHeaderWithAttributes,
                     TextPoint(line:=3, lineOffset:=25, absoluteOffset:=77, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartName,
                     TextPoint(line:=3, lineOffset:=23, absoluteOffset:=75, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartNavigate,
                     TextPoint(line:=3, lineOffset:=25, absoluteOffset:=77, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartWhole,
                     TextPoint(line:=3, lineOffset:=25, absoluteOffset:=77, lineLength:=24)),
                Part(EnvDTE.vsCMPart.vsCMPartWholeWithAttributes,
                     TextPoint(line:=3, lineOffset:=25, absoluteOffset:=77, lineLength:=24)))
        End Sub

#End Region

#Region "Access tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Access1()
            Dim code =
    <Code>
Class C
    Function $$F() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestAccess(code, EnvDTE.vsCMAccess.vsCMAccessPublic)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Access2()
            Dim code =
    <Code>
Class C
    Private Function $$F() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestAccess(code, EnvDTE.vsCMAccess.vsCMAccessPrivate)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Access3()
            Dim code =
    <Code>
Class C
    Protected Function $$F() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestAccess(code, EnvDTE.vsCMAccess.vsCMAccessProtected)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Access4()
            Dim code =
    <Code>
Class C
    Protected Friend Function $$F() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestAccess(code, EnvDTE.vsCMAccess.vsCMAccessProjectOrProtected)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Access5()
            Dim code =
    <Code>
Class C
    Friend Function $$F() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestAccess(code, EnvDTE.vsCMAccess.vsCMAccessProject)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Access6()
            Dim code =
    <Code>
Class C
    Public Function $$F() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestAccess(code, EnvDTE.vsCMAccess.vsCMAccessPublic)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Access7()
            Dim code =
<Code>
Interface I
    Function $$F() As Integer
End Interface
</Code>

            TestAccess(code, EnvDTE.vsCMAccess.vsCMAccessPublic)
        End Sub

#End Region

#Region "CanOverride tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub CanOverride1()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Sub $$Foo()
End Class
</Code>

            TestCanOverride(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub CanOverride2()
            Dim code =
<Code>
Interface I
    Sub $$Foo()
End Interface
</Code>

            TestCanOverride(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub CanOverride3()
            Dim code =
<Code>
Class C
    Protected Overridable Sub $$Foo()

    End Sub
End Class
</Code>

            TestCanOverride(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub CanOverride4()
            Dim code =
<Code>
Class C
    Protected Sub $$Foo()

    End Sub
End Class
</Code>

            TestCanOverride(code, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub CanOverride5()
            Dim code =
<Code>
Class B
    Protected Overridable Sub Foo()

    End Sub
End Class

Class C
    Inherits B

    Protected Overrides Sub $$Foo()

    End Sub
End Class
</Code>

            TestCanOverride(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub CanOverride6()
            Dim code =
<Code>
Class B
    Protected Overridable Sub Foo()

    End Sub
End Class

Class C
    Inherits B

    Protected NotOverridable Overrides Sub $$Foo()

    End Sub
End Class
</Code>

            TestCanOverride(code, False)
        End Sub

#End Region

#Region "MustImplement tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub MustImplement1()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Sub $$Foo()
End Class
</Code>

            TestMustImplement(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub MustImplement2()
            Dim code =
<Code>
Interface I
    Sub $$Foo()
End Interface
</Code>

            TestMustImplement(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub MustImplement3()
            Dim code =
<Code>
Class C
    Protected Overridable Sub $$Foo()

    End Sub
End Class
</Code>

            TestMustImplement(code, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub MustImplement4()
            Dim code =
<Code>
Class C
    Protected Sub $$Foo()

    End Sub
End Class
</Code>

            TestMustImplement(code, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub MustImplement5()
            Dim code =
<Code>
Class B
    Protected Overridable Sub Foo()

    End Sub
End Class

Class C
    Inherits B

    Protected Overrides Sub $$Foo()

    End Sub
End Class
</Code>

            TestMustImplement(code, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub MustImplement6()
            Dim code =
<Code>
Class B
    Protected Overridable Sub Foo()

    End Sub
End Class

Class C
    Inherits B

    Protected NotOverridable Overrides Sub $$Foo()

    End Sub
End Class
</Code>

            TestMustImplement(code, False)
        End Sub

#End Region

#Region "Name tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Name1()
            Dim code =
<Code>
Class C
    MustOverride Sub $$Foo()
End Class
</Code>

            TestName(code, "Foo")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Name_NoParens()
            Dim code =
<Code>
Class C
    Sub $$Foo
End Class
</Code>

            TestName(code, "Foo")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Name_Constructor1()
            Dim code =
<Code>
Class C
    Sub $$New()
    End Sub
End Class
</Code>

            TestName(code, "New")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Name_Constructor2()
            Dim code =
<Code>
Class C
    Sub $$New()
End Class
</Code>

            TestName(code, "New")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Name_Operator1()
            Dim code =
<Code>
Class C
    Shared Narrowing Operator $$CType(i As Integer) As C
    End Operator
End Class
</Code>

            TestName(code, "CType")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Name_Operator2()
            Dim code =
<Code>
Class C
    Shared Narrowing Operator $$CType(i As Integer) As C
End Class
</Code>

            TestName(code, "CType")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Name_Operator3()
            Dim code =
<Code>
Class C
    Shared Operator $$*(i As Integer, c As C) As C
    End Operator
End Class
</Code>

            TestName(code, "*")
        End Sub

#End Region

#Region "OverrideKind tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub OverrideKind_Abstract()
            Dim code =
<Code>
MustInherit Class C
    Protected MustOverride Sub $$Foo()
End Class
</Code>

            TestOverrideKind(code, EnvDTE80.vsCMOverrideKind.vsCMOverrideKindAbstract)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub OverrideKind_Virtual()
            Dim code =
<Code>
Class C
    Protected Overridable Sub $$Foo()
    End Sub
End Class
</Code>

            TestOverrideKind(code, EnvDTE80.vsCMOverrideKind.vsCMOverrideKindVirtual)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub OverrideKind_Sealed()
            Dim code =
<Code>
Class C
    Protected NotOverridable Sub $$Foo()
    End Sub
End Class
</Code>

            TestOverrideKind(code, EnvDTE80.vsCMOverrideKind.vsCMOverrideKindSealed)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub OverrideKind_Override()
            Dim code =
<Code>
MustInherit Class B
    Protected MustOverride Sub Foo()
End Class

Class C
    Inherits B

    Protected Overrides Sub $$Foo()
    End Sub
End Class
</Code>

            TestOverrideKind(code, EnvDTE80.vsCMOverrideKind.vsCMOverrideKindOverride)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub OverrideKind_New()
            Dim code =
<Code>
MustInherit Class B
    Protected MustOverride Sub Foo()
End Class

Class C
    Inherits B

    Protected Shadows Sub $$Foo()
    End Sub
End Class
</Code>

            TestOverrideKind(code, EnvDTE80.vsCMOverrideKind.vsCMOverrideKindNew)
        End Sub

#End Region

#Region "Prototype tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Prototype_UniqueSignature()
            Dim code =
<Code>
Namespace N
    Class C
        Sub $$Foo()
        End Sub
    End Class
End Namespace
</Code>

            TestPrototype(code, EnvDTE.vsCMPrototype.vsCMPrototypeUniqueSignature, "M:N.C.Foo")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Prototype_FullName()
            Dim code =
<Code>
Namespace N
    Class C
        Sub $$Foo()
        End Sub
    End Class
End Namespace
</Code>

            TestPrototype(code, EnvDTE.vsCMPrototype.vsCMPrototypeFullname, "N.C.Foo()")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Prototype_ClassName()
            Dim code =
<Code>
Namespace N
    Class C
        Sub $$Foo()
        End Sub
    End Class
End Namespace
</Code>

            TestPrototype(code, EnvDTE.vsCMPrototype.vsCMPrototypeClassName, "C.Foo()")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Prototype_Type1()
            Dim code =
<Code>
Namespace N
    Class C
        Sub $$Foo()
        End Sub
    End Class
End Namespace
</Code>

            TestPrototype(code, EnvDTE.vsCMPrototype.vsCMPrototypeType, "Foo()")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Prototype_Type2()
            Dim code =
<Code>
Namespace N
    Class C
        Function $$Foo() As Integer
        End Function
    End Class
End Namespace
</Code>

            TestPrototype(code, EnvDTE.vsCMPrototype.vsCMPrototypeType, "Foo() As Integer")
        End Sub

#End Region

#Region "Type tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Type1()
            Dim code =
<Code>
Class C
    Sub $$Foo()
    End Sub
End Class
</Code>

            TestTypeProp(code,
                         New CodeTypeRefData With {
                             .AsString = "Void",
                             .AsFullName = "System.Void",
                             .CodeTypeFullName = "System.Void",
                             .TypeKind = EnvDTE.vsCMTypeRef.vsCMTypeRefVoid
                         })
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Type2()
            Dim code =
<Code>
Class C
    Function $$Foo$()
    End Function
End Class
</Code>

            TestTypeProp(code,
                         New CodeTypeRefData With {
                             .AsString = "String",
                             .AsFullName = "System.String",
                             .CodeTypeFullName = "System.String",
                             .TypeKind = EnvDTE.vsCMTypeRef.vsCMTypeRefString
                         })
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Type3()
            Dim code =
<Code>
Class C
    Function $$Foo() As String
    End Function
End Class
</Code>

            TestTypeProp(code,
                         New CodeTypeRefData With {
                             .AsString = "String",
                             .AsFullName = "System.String",
                             .CodeTypeFullName = "System.String",
                             .TypeKind = EnvDTE.vsCMTypeRef.vsCMTypeRefString
                         })
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub Type4()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Function $$Foo() As String
End Class
</Code>

            TestTypeProp(code,
                         New CodeTypeRefData With {
                             .AsString = "String",
                             .AsFullName = "System.String",
                             .CodeTypeFullName = "System.String",
                             .TypeKind = EnvDTE.vsCMTypeRef.vsCMTypeRefString
                         })
        End Sub

#End Region

#Region "AddParameter tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub AddParameter1()
            Dim code =
<Code>
Class C
    Sub $$M()
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub M(a As Integer)
    End Sub
End Class
</Code>

            TestAddParameter(code, expected, New ParameterData With {.Name = "a", .Type = "Integer"})
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub AddParameter2()
            Dim code =
<Code>
Class C
    Sub $$M(a As Integer)
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub M(b As String, a As Integer)
    End Sub
End Class
</Code>

            TestAddParameter(code, expected, New ParameterData With {.Name = "b", .Type = "String"})
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub AddParameter3()
            Dim code =
<Code>
Class C
    Sub $$M(a As Integer, b As String)
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub M(a As Integer, c As Boolean, b As String)
    End Sub
End Class
</Code>

            TestAddParameter(code, expected, New ParameterData With {.Name = "c", .Type = "System.Boolean", .Position = 1})
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub AddParameter4()
            Dim code =
<Code>
Class C
    Sub $$M(a As Integer)
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub M(a As Integer, b As String)
    End Sub
End Class
</Code>

            TestAddParameter(code, expected, New ParameterData With {.Name = "b", .Type = "String", .Position = -1})
        End Sub

#End Region

#Region "RemoveParamter tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub RemoveParameter1()
            Dim code =
<Code>
Class C
    Sub $$M(a As Integer)
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub M()
    End Sub
End Class
</Code>

            TestRemoveChild(code, expected, "a")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub RemoveParameter2()
            Dim code =
<Code>
Class C
    Sub $$M(a As Integer, b As String)
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub M(a As Integer)
    End Sub
End Class
</Code>

            TestRemoveChild(code, expected, "b")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub RemoveParameter3()
            Dim code =
<Code>
Class C
    Sub $$M(a As Integer, b As String)
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub M(b As String)
    End Sub
End Class
</Code>

            TestRemoveChild(code, expected, "a")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub RemoveParameter4()
            Dim code =
<Code>
Class C
    Sub $$M(a As Integer, b As String, c As Integer)
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub M(a As Integer, c As Integer)
    End Sub
End Class
</Code>

            TestRemoveChild(code, expected, "b")
        End Sub

#End Region

#Region "Set Access tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetAccess1()
            Dim code =
<Code>
Class C
    Function $$Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Public Function Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestSetAccess(code, expected, EnvDTE.vsCMAccess.vsCMAccessPublic)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetAccess2()
            Dim code =
<Code>
Class C
    Public Function $$Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Friend Function Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestSetAccess(code, expected, EnvDTE.vsCMAccess.vsCMAccessProject)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetAccess3()
            Dim code =
<Code>
Class C
    Protected Friend Function $$Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Public Function Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestSetAccess(code, expected, EnvDTE.vsCMAccess.vsCMAccessPublic)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetAccess4()
            Dim code =
<Code>
Class C
    Public Function $$Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Protected Friend Function Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestSetAccess(code, expected, EnvDTE.vsCMAccess.vsCMAccessProjectOrProtected)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetAccess5()
            Dim code =
<Code>
Class C
    Public Function $$Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Function Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestSetAccess(code, expected, EnvDTE.vsCMAccess.vsCMAccessDefault)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetAccess6()
            Dim code =
<Code>
Interface C
    Function $$Foo() As Integer
End Class
</Code>

            Dim expected =
<Code>
Interface C
    Function Foo() As Integer
End Class
</Code>

            TestSetAccess(code, expected, EnvDTE.vsCMAccess.vsCMAccessProjectOrProtected, ThrowsArgumentException(Of EnvDTE.vsCMAccess)())
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetAccess7()
            Dim code =
<Code>
Interface C
    Function $$Foo() As Integer
End Class
</Code>

            Dim expected =
<Code>
Interface C
    Function Foo() As Integer
End Class
</Code>

            TestSetAccess(code, expected, EnvDTE.vsCMAccess.vsCMAccessPublic)
        End Sub

#End Region

#Region "Set CanOverride tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetCanOverride1()
            Dim code =
<Code>
MustInherit Class C
    Overridable Sub $$Foo()

    End Sub
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    Overridable Sub Foo()

    End Sub
End Class
</Code>

            TestSetCanOverride(code, expected, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetCanOverride2()
            Dim code =
<Code>
MustInherit Class C
    Overridable Sub $$Foo()

    End Sub
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    Sub Foo()

    End Sub
End Class
</Code>

            TestSetCanOverride(code, expected, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetCanOverride3()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Sub $$Foo()
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    Overridable Sub Foo()

    End Sub
End Class
</Code>

            TestSetCanOverride(code, expected, True)
        End Sub

#End Region

#Region "Set MustImplement tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetMustImplement1()
            Dim code =
<Code>
MustInherit Class C
    Overridable Sub $$Foo()

    End Sub
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    MustOverride Sub Foo()
End Class
</Code>

            TestSetMustImplement(code, expected, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetMustImplement2()
            Dim code =
<Code>
MustInherit Class C
    Overridable Sub $$Foo()

    End Sub
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    Sub Foo()

    End Sub
End Class
</Code>

            TestSetMustImplement(code, expected, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetMustImplement3()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Sub $$Foo()
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    MustOverride Sub Foo()
End Class
</Code>

            TestSetMustImplement(code, expected, True)
        End Sub

#End Region

#Region "Set IsShared tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetIsShared1()
            Dim code =
<Code>
Class C
    Function $$Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Shared Function Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestSetIsShared(code, expected, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetIsShared2()
            Dim code =
<Code>
Class C
    Shared Function $$Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Function Foo() As Integer
        Throw New NotImplementedException()
    End Function
End Class
</Code>

            TestSetIsShared(code, expected, False)
        End Sub

#End Region

#Region "Set Name tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub SetName1()
            Dim code =
<Code>
Class C
    Sub $$Foo()
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub Bar()
    End Sub
End Class
</Code>

            TestSetName(code, expected, "Bar", NoThrow(Of String)())
        End Sub

#End Region

#Region "Set OverrideKind tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetOverrideKind1()
            Dim code =
<Code>
MustInherit Class C
    Sub $$Foo()

    End Sub
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    Sub Foo()

    End Sub
End Class
</Code>

            TestSetOverrideKind(code, expected, EnvDTE80.vsCMOverrideKind.vsCMOverrideKindNone)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetOverrideKind2()
            Dim code =
<Code>
MustInherit Class C
    Sub $$Foo()

    End Sub
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    MustOverride Sub Foo()
End Class
</Code>

            TestSetOverrideKind(code, expected, EnvDTE80.vsCMOverrideKind.vsCMOverrideKindAbstract)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetOverrideKind3()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Sub $$Foo()
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    Sub Foo()

    End Sub
End Class
</Code>

            TestSetOverrideKind(code, expected, EnvDTE80.vsCMOverrideKind.vsCMOverrideKindNone)
        End Sub

#End Region

#Region "Set Type tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetType1()
            Dim code =
<Code>
Class C
    Sub $$Foo()
        Dim i As Integer
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub Foo()
        Dim i As Integer
    End Sub
End Class
</Code>

            TestSetTypeProp(code, expected, CType(Nothing, EnvDTE.CodeTypeRef))
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetType2()
            Dim code =
<Code>
Class C
    Sub $$Foo()
        Dim i As Integer
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Function Foo() As Integer
        Dim i As Integer
    End Function
End Class
</Code>

            TestSetTypeProp(code, expected, "System.Int32")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetType3()
            Dim code =
<Code>
Class C
    Function $$Foo() As System.Int32
        Dim i As Integer
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Function Foo() As String
        Dim i As Integer
    End Function
End Class
</Code>

            TestSetTypeProp(code, expected, "System.String")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetType4()
            Dim code =
<Code>
Class C
    Function $$Foo() As System.Int32
        Dim i As Integer
    End Function
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub Foo()
        Dim i As Integer
    End Sub
End Class
</Code>

            TestSetTypeProp(code, expected, CType(Nothing, EnvDTE.CodeTypeRef))
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetType5()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Function $$Foo() As System.Int32
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    MustOverride Sub Foo()
End Class
</Code>

            TestSetTypeProp(code, expected, CType(Nothing, EnvDTE.CodeTypeRef))
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetType6()
            Dim code =
<Code>
MustInherit Class C
    MustOverride Sub $$Foo()
End Class
</Code>

            Dim expected =
<Code>
MustInherit Class C
    MustOverride Function Foo() As Integer
End Class
</Code>

            TestSetTypeProp(code, expected, "System.Int32")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetType7()
            Dim code =
<Code>
Class C
    Sub $$New()
    End Sub
End Class
</Code>

            Dim expected =
<Code>
Class C
    Sub New()
    End Sub
End Class
</Code>

            TestSetTypeProp(code, expected, "System.Int32")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Public Sub SetType8()
            Dim code =
<Code>
Class C
    Shared Narrowing Operator $$CType(i As Integer) As C
    End Operator
End Class
</Code>

            Dim expected =
<Code>
Class C
    Shared Narrowing Operator CType(i As Integer) As C
    End Operator
End Class
</Code>

            TestSetTypeProp(code, expected, "System.Int32")
        End Sub

#End Region

#Region "PartialMethodExtender"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub PartialMethodExtender_IsPartial1()
            Dim code =
<Code>
Partial Public Class Class2
    Public Sub $$M(i As Integer)
    End Sub

    Partial Private Sub M()
    End Sub

    Private Sub M()
    End Sub
End Class
</Code>

            TestPartialMethodExtender_IsPartial(code, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub PartialMethodExtender_IsPartial2()
            Dim code =
<Code>
Partial Public Class Class2
    Public Sub M(i As Integer)
    End Sub

    Partial Private Sub $$M()
    End Sub

    Private Sub M()
    End Sub
End Class
</Code>

            TestPartialMethodExtender_IsPartial(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub PartialMethodExtender_IsPartial3()
            Dim code =
<Code>
Partial Public Class Class2
    Public Sub M(i As Integer)
    End Sub

    Partial Private Sub M()
    End Sub

    Private Sub $$M()
    End Sub
End Class
</Code>

            TestPartialMethodExtender_IsPartial(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub PartialMethodExtender_IsDeclaration1()
            Dim code =
<Code>
Partial Public Class Class2
    Public Sub $$M(i As Integer)
    End Sub

    Partial Private Sub M()
    End Sub

    Private Sub M()
    End Sub
End Class
</Code>

            TestPartialMethodExtender_IsDeclaration(code, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub PartialMethodExtender_IsDeclaration2()
            Dim code =
<Code>
Partial Public Class Class2
    Public Sub M(i As Integer)
    End Sub

    Partial Private Sub $$M()
    End Sub

    Private Sub M()
    End Sub
End Class
</Code>

            TestPartialMethodExtender_IsDeclaration(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub PartialMethodExtender_IsDeclaration3()
            Dim code =
<Code>
Partial Public Class Class2
    Public Sub M(i As Integer)
    End Sub

    Partial Private Sub M()
    End Sub

    Private Sub $$M()
    End Sub
End Class
</Code>

            TestPartialMethodExtender_IsDeclaration(code, False)
        End Sub

#End Region

#Region "Overloads Tests"

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub IsOverloaded1()
            Dim code =
<Code>
Class C
    Sub $$Foo(x As C)
    End Sub
End Class
</Code>
            TestIsOverloaded(code, False)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub IsOverloaded2()
            Dim code =
<Code>
Class C
    Sub Foo()
    End Sub

    Sub $$Foo(x As C)
    End Sub
End Class
</Code>
            TestIsOverloaded(code, True)
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub TestOverloads1()
            Dim code =
<Code>
Class C
    Sub $$Foo()
    End Sub

    Sub Foo(x As C)
    End Sub
End Class

</Code>
            TestOverloadsUniqueSignatures(code, "M:C.Foo", "M:C.Foo(C)")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub TestOverloads2()
            Dim code =
<Code>
Class C
    Sub $$Foo()
    End Sub
End Class

</Code>
            TestOverloadsUniqueSignatures(code, "M:C.Foo")
        End Sub

        <ConditionalFact(GetType(x86)), Trait(Traits.Feature, Traits.Features.CodeModel)>
        Sub TestOverloads3()
            Dim code =
<Code>
Class C
    Shared Operator $$*(i As Integer, c As C) As C
    End Operator
End Class
</Code>
            TestOverloadsUniqueSignatures(code, "M:C.op_Multiply(System.Int32,C)")
        End Sub

#End Region

        Private Function GetPartialMethodExtender(codeElement As EnvDTE80.CodeFunction2) As IVBPartialMethodExtender
            Return CType(codeElement.Extender(ExtenderNames.VBPartialMethodExtender), IVBPartialMethodExtender)
        End Function

        Protected Overrides Function PartialMethodExtender_GetIsPartial(codeElement As EnvDTE80.CodeFunction2) As Boolean
            Return GetPartialMethodExtender(codeElement).IsPartial
        End Function

        Protected Overrides Function PartialMethodExtender_GetIsDeclaration(codeElement As EnvDTE80.CodeFunction2) As Boolean
            Return GetPartialMethodExtender(codeElement).IsDeclaration
        End Function

        Protected Overrides ReadOnly Property LanguageName As String
            Get
                Return LanguageNames.VisualBasic
            End Get
        End Property
    End Class
End Namespace
