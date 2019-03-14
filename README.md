# .Net-Lab
The most interesting task at this moment is Lesson8.Task1.

Also when you start TestProject you can select any task you want to see how it works.


Short contents:
Lesson1 - Hello world; task from udemy.org
Lesson2 - Work with Classes
Lesson3 - Work with structures
Lesson4 - Inheritance
Lesson5 - Arrays
Lesson6 - Collections
Lesson8 - Style Coding. Tasks that summarizes knowledge from Lesson1..8, 9
Lesson9 - LINQ
Lesson11 - Exceptions


Detailed contents:

*** Lesson1: ***
 Task1: Hello world!
 Task2: Creating X-0 game in WinForms. Open solution "X_0" to see it.

*** Lesson2: ***
  Work with Classes
	Task1: Calculate 'Perimeter' and 'Area' of rectangle using fields.
	Task2: Calculate 'Perimeter' and 'Area' of rectangle using Auto-implemented Properties.
	Task3: Calculate 'Length' and 'Area' of circle using methods of instance.
	Task4: Calculate 'Length' and 'Area' of circle; Perimeter and Area of rectangle using Static classes.
	Task5: Implement class ComplexNumber. Overload operators "*" and "/".


*** Lesson3: ***
  Work with structures
	Task1: Create structure Person and compare Age with entered number (age).

  
*** Lesson4: ***
  Inheritance
	Task1: Implement base class Figure with abstract method Draw(); Create classes Rectangle and Square (inherited from Figure) with overloaded implementation of method Draw().
	Task2: Using previous task add readonly properties X and Y to class Figure. Add constructor with parameters to set these properties.
	Task3: Using previous task change abstract method Draw() to virtual. Make sure that 3 implementations of method Draw() work.
	Task4: Using previous task elevate method Draw() into separate interface IDrawable. Create method DrawAll() which calls correct method Draw().
	OptTask1: (Optional task, checking example from the lecture) Compare BubbleSorting algorithms
  

*** Lesson5: ***
  Arrays
	Task1: Get new array from cubed values of defined one.
	Task2: Get quantity of simple numbers in the defined array.
	Task3: Check entered array of integers for symmetry.
	Task4: On the basis of the array (MxN, M>1, N>1) create the vector which contains elements with maximum value from every row.
	Task5: Make previous task using jagged array.


*** Lesson6: ***
  Collections
	Task1: Create a list of persons (>5); Each person has >2 phone numbers. Print Name and Age of each person from the list.
	Task2: Add to list 2 more persons using method "AddRange". Print phone numbers of all persons without LINQ.
	Task3: Create list with randomly generated strings (n>100), string length = 4, all letters are capital. Remove elements: all repeated and which starts with 'Z'. Sort descending. Print list before and after modifications. Create method DisplayPage() that prints specified page of modified list. If entered value invalid - break task.
	OptTask1: (optional) Work with Dictionary. Checking at home an example from the lecture.
	OptTask2: (optional) Work with Observable Collection. Checking at home an example from the lecture.
	CW_Task1: ClassWork. Checking how works example from lecture. List.Count(), List.Capacity().
	CW_Task2: Classwork. Checking how works example from lecture. SortedDictionary.


*** Lesson8: ***
  Style Coding
	Task1: Implement a class of rectangles with sides parallel to the coordinate axes taking into account the rules of StyleCop. Predict the ability to move rectangles on a plane, change their sizes, create the smallest rectangle containing two and a rectangle as the result of intersection of two rectangles. Make possible their drawing.
	OptTask1: Create parallelepiped and make possible its drawing.


*** Lesson9: ***
  LINQ
	Task1: -> Lesson6, Task1
	Task2: -> Lesson6, Task2
	Task3: -> Lesson6, Task2
	Task4: Using LINQ get the phone numbers of persons with Age<20 into separate list.
	Task5: -> Lesson6, Task3
	CW_LINQ: ClassWork. Checking at home an example from the lecture. (query -> .TakeWhile() )


*** Lesson11: ***
  Exceptions
	Task1: Generate StackOverflowException by recursion.
	Task2: Generate IndexOutOfRangeException using 1 dim array.
	Task3: Catch StackOverflowException and IndexOutOfRangeException.
	Task4: Catch ArgumentException by parameter. To make exception enter a<0 or b>0.

*** Lesson12: ***
  I/O Streams, working with file system, serialization
	Task1: Show contents of the specified folder as list of files, subdirectories and their contents.
	Task2: Create an application that can search a '.txt' file, with specified partial name of the file.