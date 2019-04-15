using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace TestProject.Common.Core.Classes.Utilities
{
    public class TaskManager
    {
        private SortedDictionary<string, List<string>> _treeOfSpaces;
        private Dictionary<string, List<string>> _tempTree;
        private SortedDictionary<string, List<string>> _treeOfTasks;

        private string _assemblyName;
        private List<string> _tempList;
        private List<string> _tempTaskList;

        private string _lastPartialNamespace="";
        private bool _workedInLastPartialNamespace = false;
        private bool _canAddNewSpace = true;
        private bool _canBreakSpaceLoop = false;

        /// <summary>
        /// Dictionary of Lessons
        /// </summary>
        public SortedDictionary<string, Type> Lessons;

        /// <summary>
        /// Dictionary of all tasks in the assembly
        /// </summary>
        public SortedDictionary<string, Type> AllTasks;

        /// <summary>
        /// Dictionary of partial Spaces in the Namespace.
        /// Key - parent space, Value - list of nested spaces (if exist).
        /// </summary>
        public SortedDictionary<string, List<string>> TreeOfSpaces
        {
            get { return _treeOfSpaces; }
        }

        /// <summary>
        /// Dictionary of Tasks in the partial Spaces in the Namespace.
        /// Key - parent space, Value - list of nested Tasks (if exist).
        /// </summary>
        public SortedDictionary<string, List<string>> TreeOfTasks
        {
            get { return _treeOfTasks; }
        }

        /// <summary>
        /// Initializes an instance of the TaskManager class.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly we work with.</param>
        /// <param name="runnableTypes">List of runnable types from assembly.</param>
        public TaskManager(string assemblyName, IEnumerable<Type> runnableTypes)
        {
            _assemblyName = assemblyName;

            // Adding all partial namespaces to the dictionary
            FillTreeOfNamespaces(runnableTypes);

            // Adding all tasks to the dictionary
            FillTreeOfTasks(runnableTypes);
        }

        /// <summary>
        /// Gets list of nested partial spaces (if exists)
        /// in the parent partial namespace.
        /// </summary>
        /// <param name="parentPartialSpace">Full parent partial namespace.</param>
        /// <param name="nameSpaces">List of namespaces.</param>
        /// <returns></returns>
        private List<string> GetPartialSpaces(string parentPartialSpace, IEnumerable<string> nameSpaces)
        {
            int startIndex = parentPartialSpace.Length+1;
            int dotIndex;
            string partialSpace;
            var tmpList=new List<string>();

            foreach (var space in nameSpaces)
            {
                if (space.Length <= parentPartialSpace.Length) continue;
                dotIndex = space.IndexOf('.', startIndex);
                if (dotIndex >= 0)
                {
                    partialSpace = SetPartialSpaceElse(parentPartialSpace, space, startIndex, dotIndex);
                }
                else
                {
                    partialSpace = SetPartialSpaceIfDotIndexLessZero(parentPartialSpace, space, startIndex);
                }

                if (tmpList.Contains(partialSpace)==false && partialSpace != "")
                { tmpList.Add(partialSpace); }
            }

            return  tmpList.Distinct().ToList();
        }

        /// <summary>
        /// Gets name of nested partial space (if exists)
        /// in the case of last nesting.
        /// </summary>
        /// <param name="parentPartialSpace">Full parent partial namespace.</param>
        /// <param name="space">Name of full namespace.</param>
        /// <param name="startIndex">Zero-based index of char to
        /// start get name of the nested partial space.</param>
        /// <returns></returns>
        private string SetPartialSpaceIfDotIndexLessZero(string parentPartialSpace, string space, int startIndex)
        {
            var tmpStr = space.Substring(0, startIndex - 1);

            if (tmpStr == parentPartialSpace)
            {
                return space.Substring(startIndex);
            }

            return "";
        }

        /// <summary>
        /// Gets name of nested partial space (if exists) in the
        /// case when nesting is not finished.
        /// </summary>
        /// <param name="parentPartialSpace">Full parent partial namespace.</param>
        /// <param name="space">Name of full namespace.</param>
        /// <param name="startIndex">Zero-based index of char '.' after
        /// which get name of nested partial space.</param>
        /// <param name="dotIndex">Zero-based index of char in the full namespace
        /// to start get name of the nested partial space.</param>
        /// <returns></returns>
        private string SetPartialSpaceElse(string parentPartialSpace, string space, int startIndex, int dotIndex)
        {
            var tmpStr = space.Substring(0, startIndex - 1);
            var tmpChar = space.Substring(startIndex, 1);

            if (tmpStr == parentPartialSpace & tmpChar != ".")
            { return space.Substring(startIndex, dotIndex - startIndex); }

            return "";
        }

        /// <summary>
        /// Fills the sorted dictionaries of full partial namespaces.
        /// </summary>
        /// <param name="runnableTypes">List of runnable types.</param>
        private void FillTreeOfNamespaces(IEnumerable<Type> runnableTypes)
        {
            _treeOfSpaces = new SortedDictionary<string, List<string>>();
            _tempList = new List<string>();
            _tempTree = new Dictionary<string, List<string>>();
            
            var tempNamespaces = runnableTypes.OrderBy(t => t.Namespace).Select(t => t.Namespace).Distinct();

            _tempList = GetPartialSpaces(_assemblyName, tempNamespaces);

            _lastPartialNamespace = "";

            if (_tempList.Count > 1)
            {
                _lastPartialNamespace = _assemblyName + "." + _tempList[_tempList.Count - 1];
            }

            _tempTree.Add(_assemblyName, _tempList);
            
            do
            {
                AddKeysMain(ref tempNamespaces);
            } while (_canBreakSpaceLoop == false);

            foreach (var (key, list) in _tempTree)
            {
                _treeOfSpaces.Add(key, list);
            }
        }

        /// <summary>
        /// Adds keys/values to the temporary tree.
        /// Key - full partial namespace, value - list of nested spaces (if exists).
        /// </summary>
        /// <param name="tempNamespaces">List of full namespaces.</param>
        private void AddKeysMain(ref IEnumerable<string> tempNamespaces)
        {
            foreach (var (key, list) in _tempTree.ToList().OrderBy(k => k.Key))
            {
                if (_lastPartialNamespace == "")
                {
                    if (list.Count > 1)
                    {
                        _lastPartialNamespace = key + "." + _tempList[list.Count - 1];
                    }
                }
                else
                {
                    TrySetEndOfLoop(key);
                }

                AddKeysSecondary(key, list, ref tempNamespaces);
            }
        }

        /// <summary>
        /// Adds keys/values of nested spaces to the temporary tree (if exists)
        /// and 
        /// </summary>
        /// <param name="parentKey">Full partial namespace where is list of partial nested spaces.</param>
        /// <param name="listOfSpaces">List of partial nested spaces.</param>
        /// <param name="tempNamespaces">List of full namespaces.</param>
        private void AddKeysSecondary(string parentKey, List<string> listOfSpaces, ref IEnumerable<string> tempNamespaces) 
        {
            foreach (var partialSpace in listOfSpaces)
            {
                CheckEndOfLoop(parentKey);
                
                if (partialSpace != "")
                {
                    _tempList = new List<string>();
                    _tempList = GetPartialSpaces(parentKey + '.' + partialSpace, tempNamespaces);
                    if (_tempTree.ContainsKey(parentKey + '.' + partialSpace) == false)
                    {
                        _tempTree.Add(parentKey + '.' + partialSpace, _tempList);
                        //ConsIO.WriteLine(parentKey + '.' + partialSpace);
                    }
                }
            }
        }

        /// <summary>
        /// Checks conditions to make possible break of dictionary generation loop.
        /// </summary>
        /// <param name="key">Key from dictionary.</param>
        private void TrySetEndOfLoop(string key)
        {
            if (_lastPartialNamespace == key)
            {

                if (_workedInLastPartialNamespace)
                {
                    _canAddNewSpace = false;
                }
                else
                {
                    _workedInLastPartialNamespace = true;
                }
            }
        }

        /// <summary>
        /// Checks if already made list of all nested spaces.
        /// </summary>
        /// <param name="parentKey">Full partial namespace where is list of partial nested spaces.</param>
        private void CheckEndOfLoop(string parentKey)
        {
            if (_canAddNewSpace == false)
            {
                if (parentKey.StartsWith(_lastPartialNamespace) == false)
                {
                    _canBreakSpaceLoop = true;
                }
            }
        }

        /// <summary>
        /// Gets lists of tasks names in each namespace.
        /// </summary>
        /// <param name="runnableTypes">List of runnable types.</param>
        /// <returns></returns>
        private SortedDictionary<string, List<string>> GetTasksInNamespaces(IEnumerable<Type> runnableTypes)
        {
            var tmpDict = new SortedDictionary<string, List<string>>();
            var tmpList = new List<string>();

            var nameSpaces = runnableTypes.Select(t => t.Namespace).Distinct().ToList();

            foreach (var nameSpace in nameSpaces)
            {
                tmpList = runnableTypes.Where(t => t.Namespace == nameSpace).Select(t => t.Name).ToList();
                tmpDict.Add(nameSpace, tmpList);
            }

            return tmpDict;
        }

        /// <summary>
        /// Fills the sorted dictionaries of tasks.
        /// </summary>
        /// <param name="runnableTypes">List of runnable types.</param>
        private void FillTreeOfTasks(IEnumerable<Type> runnableTypes)
        {
            _treeOfTasks = GetTasksInNamespaces(runnableTypes);
            AllTasks=new SortedDictionary<string, Type>();

            foreach (var runnableType in runnableTypes)
            {
                AllTasks.Add(runnableType.ToString(), runnableType);
            }
        }
    }
}
