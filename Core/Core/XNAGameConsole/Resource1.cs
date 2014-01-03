namespace XNAGameConsole
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resource1
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resource1()
        {
        }

        internal static byte[] ConsoleFont
        {
            get
            {
                return (byte[]) ResourceManager.GetObject("ConsoleFont", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("XNAGameConsole.Resource1", typeof(Resource1).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static byte[] roundedCorner
        {
            get
            {
                return (byte[]) ResourceManager.GetObject("roundedCorner", resourceCulture);
            }
        }
    }
}

