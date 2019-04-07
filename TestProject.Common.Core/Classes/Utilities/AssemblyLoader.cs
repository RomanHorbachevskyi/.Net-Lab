using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using TestProject.Common.Core.Interfaces;


namespace TestProject.Common.Core.Classes.Utilities
{
    /// <summary>
    /// Class to load assembly and get public runnable types.
    /// </summary>
    public class AssemblyLoader
    {
        /// <summary>
        /// Name of the loaded assembly.
        /// </summary>
        public readonly string AssemblyName;

        private Assembly _loadedAssembly;

        private readonly IEnumerable<Type> _loadedPublicRunnableTypes;

        /// <summary>
        /// Initializes an instance of the AssemblyLoader class.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly</param>
        public AssemblyLoader(string assemblyName)
        {
            Load(assemblyName);
            _loadedPublicRunnableTypes = Assembly.GetExportedTypes()
                    .OrderBy(t => t.FullName)
                    .Where(typeof(IRunnable).IsAssignableFrom)
                ;
        }

        /// <summary>
        /// Initializes an instance of the AssemblyLoader class.
        /// </summary>
        public AssemblyLoader()
        {
            AssemblyName = ConfigurationManager.AppSettings.Get("AssemblyName");
            Load(AssemblyName);
            _loadedPublicRunnableTypes = Assembly.GetExportedTypes()
                    .OrderBy(t=>t.FullName)
                    .Where(typeof(IRunnable).IsAssignableFrom)
                    ;
        }

        /// <summary>
        /// Gets loaded assembly.
        /// </summary>
        public Assembly Assembly
        {
            get { return _loadedAssembly; }
        }

        /// <summary>
        /// Gets a list of loaded pubic runnable types.
        /// </summary>
        public IEnumerable<Type> LoadedPublicRunnableTypes
        {
            get { return _loadedPublicRunnableTypes; }
        }
        
        /// <summary>
        /// Loads specified assembly.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        private void Load(string assemblyName)
        {
            _loadedAssembly = Assembly.Load(assemblyName);
        }
    }
}
