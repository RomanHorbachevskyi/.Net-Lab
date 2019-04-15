using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestProject.Common.Core.Classes.Utilities
{
    public interface IAssemblyLoader
    {
        /// <summary>
        /// Gets loaded assembly.
        /// </summary>
        Assembly Assembly { get; }
        string AssemblyName { get; }
        /// <summary>
        /// Gets a list of loaded pubic runnable types.
        /// </summary>
        IEnumerable<Type> LoadedPublicRunnableTypes { get; }

        /// <summary>
        /// Loads specified assembly.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        void Load(string assemblyName);

        void Init();
    }
}