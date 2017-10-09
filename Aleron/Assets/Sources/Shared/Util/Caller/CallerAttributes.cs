// Workaround for bypassing compiler warning with .Net 2.0 compilation mode.
// This works as follows:
//
// Unity uses a modern Mono compiler & runtime (.Net Version around 4 for 4.5?), but compiles for .Net 2.0.
// These dummy attributes let the compilation for .Net 2.0 run without missing Assembly references.
// However, the modern compiler does write these string literals in the resulting IL code,
// so that we can reference them. This is just an additional behaviour of modern C# compilers.
// This workaround can be removed when Unity upgrades to .Net 4.5.

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CallerMemberNameAttribute : Attribute
    {
    }
 
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CallerFilePathAttribute : Attribute
    {
    }
 
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CallerLineNumberAttribute : Attribute
    {
    }
}