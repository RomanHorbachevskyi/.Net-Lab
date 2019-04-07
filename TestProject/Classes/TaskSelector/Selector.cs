using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using TestProject.Common.Core.Classes;
using TestProject.Classes;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.Common.Core.Interfaces;
using TestProject.Properties;

namespace TestProject.Classes.TaskSelector
{
    /// <summary>
    /// Class that makes possible moving inside the assembly
    /// and executing runnable types(tasks).
    /// </summary>
    public class Selector:ITreeViewer
    {
        /// <summary>
        /// True if task was running, else - False.
        /// </summary>
        public bool TaskWasRunning { get; set; }

        /// <summary>
        /// Name of the assembly we work with.
        /// </summary>
        private readonly string _nameOfAssembly;

        /// <summary>
        /// Previous key (partial namespace) we were before.
        /// </summary>
        private string _previousKey;

        /// <summary>
        /// Partial namespace (key) where we are now.
        /// </summary>
        private string _currentKey;

        /// <summary>
        /// Name of the method that executes needed task.
        /// </summary>
        private readonly string _methodToRunTask;

        /// <summary>
        /// An indexer to count number of partial spaces inside
        /// the current partial namespace.
        /// </summary>
        private int _spaceIndexer;

        /// <summary>
        /// An indexer to count the total number of
        /// the partial spaces/tasks in the current namespace.
        /// </summary>
        private int _listIndexer;

        /// <summary>
        /// An instance of TaskManager class that we work with.
        /// </summary>
        private readonly TaskManager _taskManager;
        
        /// <summary>
        /// Creates an instance of class 'Selector'.
        /// </summary>
        /// <param name="nameOfAssembly">Name of the assembly we work with.</param>
        /// <param name="taskManager">An instance of the TaskManager class.</param>
        public Selector(string nameOfAssembly, TaskManager taskManager)
        {
            _methodToRunTask = ConfigurationManager.AppSettings.Get("MethodNameToRunTask");
            _nameOfAssembly = nameOfAssembly;
            _previousKey = nameOfAssembly;
            _currentKey = _previousKey;
            _taskManager = taskManager;
            TaskWasRunning = false;
            _spaceIndexer = -1;
        }

        /// <summary>
        /// Executes specified type(task).
        /// </summary>
        /// <param name="taskType">Type (task) to run.</param>
        public void Run(Type taskType)
        {
            try
            {
                var instance = Activator.CreateInstance(taskType);
                MethodInfo task = taskType.GetMethod(_methodToRunTask);
                task.Invoke(instance, null);
            }
            catch (Exception)
            {
                ConsIO.WriteLine(Resources.CannotRunSelectedTask);
            }
        }

        /// <summary>
        /// Shows the list of partial spaces and runnable
        /// tasks if they exist.
        /// </summary>
        public void Show()
        {
            ConsIO.WriteLine();
            ConsIO.WriteLine(_currentKey);
            ShowSpaces();
            ShowTasks();
            ConsIO.Write(Resources.ChooseNeededTaskFromListAbove + " " + Resources.numbersOnLeft + ": ",
                                _currentKey == _nameOfAssembly ? 1 : 0, _listIndexer);
            
        }

        /// <summary>
        /// Shows partial spaces (if exist) in
        /// the current partial namespace.
        /// </summary>
        private void ShowSpaces()
        {
            if (_taskManager.TreeOfSpaces[_currentKey].Count > 0)
            {
                _spaceIndexer += 1;
                if (_currentKey != _nameOfAssembly)
                {
                    ConsIO.WriteLine(_spaceIndexer + ". [...]");
                }
                
                foreach (var space in _taskManager.TreeOfSpaces[_currentKey])
                {
                    _spaceIndexer += 1;
                    ConsIO.WriteLine(_spaceIndexer + ". [" + space + "]");
                }
            }
            _listIndexer = _spaceIndexer;
        }

        /// <summary>
        /// Shows tasks (if exist) in current partial namespace.
        /// </summary>
        private void ShowTasks()
        {
            if (_taskManager.TreeOfTasks.ContainsKey(_currentKey)
                && _taskManager.TreeOfTasks[_currentKey].Count > 0)
            {
                _listIndexer += _listIndexer < 0 ? 1 : 0;
                
                // Show label to go level up
                if (_spaceIndexer < 0)
                {
                    _spaceIndexer += 1;
                    ConsIO.WriteLine((_spaceIndexer) + ". [...]");
                }
                
                // Show name of each task.
                foreach (var task in _taskManager.TreeOfTasks[_currentKey])
                {
                    _listIndexer += 1;
                    ConsIO.WriteLine(_listIndexer + ". " + task);
                }
            }
        }

        /// <summary>
        /// Checks if the specified index is inside bounds
        /// of the list of current members (spaces, tasks).
        /// </summary>
        /// <param name="index">Index to check.</param>
        /// <returns></returns>
        public bool IndexIsInsideBounds(int index)
        {
            int lower = _currentKey == _nameOfAssembly ? 1 : 0;
            if (index >= lower && index <= _listIndexer)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Selects member from the list by index.
        /// If member is runnable - will run,
        /// else goes level up or inside space.
        /// </summary>
        /// <param name="index">Index inside the list bounds.</param>
        public void SelectMemberByIndex(int index)
        {
            if (IndexIsInsideBounds(index) == false)
            {
                string tmpS = Resources.qToQuitTesting;
                Validators.CheckForExitTask(ref tmpS);
            }
            // Go level up
            if (index == 0)
            { GoLevelUp();}
            // Go inside partial space or run task.
            else
            {
                RunTaskOrGoInsideSpace(index);
            }
            ConsIO.WriteLine();
        }

        /// <summary>
        /// Resets indexers for correct display
        /// of all members inside partial space.
        /// </summary>
        private void ResetIndexers()
        {
            _spaceIndexer = -1;
            _listIndexer = 0;
        }

        /// <summary>
        /// Runs runnable task or goes inside partial space.
        /// </summary>
        /// <param name="index">An index of the member inside list.</param>
        private void RunTaskOrGoInsideSpace(int index)
        {
            string tmpKey;
            // Run task if we have no partial spaces before.
            if (_spaceIndexer == 0)
            {
                tmpKey = _currentKey + '.' + _taskManager.TreeOfTasks[_currentKey][index - 1];
                RunSpecifiedTask(tmpKey);
            }
            else
            {
                // Run task if we have partial spaces before.
                if (_spaceIndexer < index)
                {
                    tmpKey = _currentKey + '.' + _taskManager.TreeOfTasks[_currentKey][index - _spaceIndexer - 1];
                    RunSpecifiedTask(tmpKey);
                }
                // Go inside partial space
                else
                {
                    tmpKey = _currentKey + '.' + _taskManager.TreeOfSpaces[_currentKey][index - 1];
                    GoIntoSpace(tmpKey);
                }
            }
        }

        /// <summary>
        /// Goes level up from the current partial namespace.
        /// </summary>
        private void GoLevelUp()
        {
            string tempPreviousKey = _previousKey;
            _currentKey = _previousKey;
            _previousKey = tempPreviousKey.Substring(0, tempPreviousKey.LastIndexOf('.'));
            ResetIndexers();
            Show();
            TaskWasRunning = false;
        }

        /// <summary>
        /// Gets type(task) to execute and executes it.
        /// </summary>
        /// <param name="taskFullName"></param>
        private void RunSpecifiedTask(string taskFullName)
        {
            ResetIndexers();
            Run(_taskManager.AllTasks[taskFullName]);
            TaskWasRunning = true;
        }

        /// <summary>
        /// Enters into the partial space the current
        /// partial namespace.
        /// </summary>
        /// <param name="fullNameOfPartialSpace">Consists of the full name of current partial namespace
        /// and partial space to go inside.</param>
        private void GoIntoSpace(string fullNameOfPartialSpace)
        {
            _previousKey = _currentKey;
            _currentKey = fullNameOfPartialSpace;
            ResetIndexers();
            Show();
            TaskWasRunning = false;
        }

        /// <summary>
        /// Gets from the user correct value of the list index.
        /// </summary>
        /// <param name="temp">The temporary input value.</param>
        /// <param name="index">An output value of the index.</param>
        public void TryGetIndex(ref string temp, ref int index)
        {
            while ((!Int32.TryParse(temp, out index)) || !IndexIsInsideBounds(index))
            {
                ConsIO.WriteLine(Resources.EnteredIncorrectValue);
                ConsIO.WriteLine($"{Resources.EnterOnlyDigitsInsideBounds} ");
                temp = ConsIO.ReadLine();
                Validators.CheckForExitTask(ref temp);
            }
        }

        /// <summary>
        /// Gets from the user correct value to make
        /// possible run all tasks or specified.
        /// </summary>
        /// <returns></returns>
        public string WhatToDo()
        {
            ConsIO.WriteLine($"{Resources.HowRunTasks}");
            string temp = ConsIO.ReadLine();

            //checking entered text
            while ((temp.ToLower() != Resources.LetterAToCheckAllTasks) & (temp.ToLower() != Resources.LetterSForSpecificTask))
            {
                Validators.CheckForExitTask(ref temp);
                ConsIO.WriteLine(Resources.EnteredIncorrectValue);
                ConsIO.WriteLine(Resources.EnterQOrAOrS);
                temp = ConsIO.ReadLine();
            }

            return temp;
        }
    }
}
