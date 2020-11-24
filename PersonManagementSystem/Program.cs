using System;
using System.Collections.Generic;

namespace PersonManagementSystem
{
    class Program
    {
        class Person
        {
            public string name { get; protected set; }
            public int age { get; protected set; }

            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public string returnDetails()
            {
                //return name + " - " + age;
                return $"{name} - {age}";
            }
            public void setName(string name)
            {
                this.name = name;
            }
            public void setAge(int age)
            {
                this.age = age;
            }
        }
        class Manager
        {
            public List<Person> people;
            
            public Manager()
            {
                people = new List<Person>()
                /*{
                    new Person("Aba", 23),
                    new Person("Test", 10)
                }*/;
                printMenu();
            }
            public void printMenu()
            {
                string[] menuOptions = new string[]
                {
                    "Print all users",
                    "Add user",
                    "Edit user",
                    "Search user",
                    "Remove user",
                    "Exit",
                };

                Console.WriteLine("Welcome to my management system!" + Environment.NewLine);

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine(i + 1 + ". " + menuOptions[i]);
                }

                Console.Write("Enter your menu option: ");

                bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);

                if (tryParse)
                {
                    if (menuOption == 1)
                    {
                        PrintAll();
                    }
                    else if (menuOption == 2)
                    {
                        AddPerson();
                    }
                    else if (menuOption == 3)
                    {
                        EditPerson();
                    }
                    else if (menuOption == 4)
                    {
                        SearchPerson();
                    }
                    else if (menuOption == 5)
                    {
                        RemovePerson();
                    }

                    if (menuOption >= 1 && menuOption <= menuOptions.Length - 1)
                    {
                        printMenu();
                    }
                }
                else
                {
                    OutputMessage("Incorrect menu choice."); //hi
                    printMenu();
                }
            }
            public void PrintAll()
            {
                StartOption("Printing all users:");

                if (!isSystemEmpty())
                {
                    PrintAllUsers();
                }

                FinishOption();

                /*
                int i = 0;
                people.ForEach(delegate (Person person)
                {
                    i++;
                    Console.WriteLine(i + ". " + person.returnDetails());
                });

                people.ForEach(person =>
                {
                    i++;
                    Console.WriteLine(i + ". " + person.returnDetails());
                });

                foreach (Person person in people)
                {
                    i++;
                    Console.WriteLine(i + ". " + person.returnDetails());
                }*/

            }
            public void AddPerson()
            {
                StartOption("Adding a user:");

                //enter a name
                //enter an age
                //create a person class
                //add to the list

                try
                {
                    Person person = returnPerson();

                    if (person != null)
                    {
                        people.Add(person);
                        Console.WriteLine("Successfully added a person.");
                        FinishOption();
                    }
                    else
                    {
                        OutputMessage("Something has went wrong.");
                        AddPerson();
                    }
                }
                catch (Exception)
                {
                    OutputMessage("Something has went wrong.");
                    AddPerson();
                }
            }
            public void EditPerson()
            {
                StartOption("Editing a user:");

                //check if people in the system
                //print all
                //allow selection
                //validate selection
                //edit user, print message
                //return back to menu

                if (!isSystemEmpty())
                {
                    PrintAllUsers(); //1. 2.

                    try
                    {
                        Console.Write("Enter an index: ");
                        int indexSelection = Convert.ToInt32(Console.ReadLine());
                        //indexSelection = indexSelection - 1;
                        //indexSelection -= 1;
                        indexSelection--;

                        //1-2
                        //0-1  2

                        if (indexSelection >= 0 && indexSelection <= people.Count - 1)
                        {
                            try
                            {
                                Person person = returnPerson();

                                if (person != null)
                                {
                                    people[indexSelection] = person;
                                    Console.WriteLine("Successfully edited a person.");
                                    FinishOption();
                                }
                                else
                                {
                                    OutputMessage("Something has went wrong.");
                                    EditPerson();
                                }
                            }
                            catch (Exception)
                            {
                                OutputMessage("Something has went wrong.");
                                EditPerson();
                            }
                        }
                        else
                        {
                            OutputMessage("Enter a valid index range.");
                            EditPerson();
                        }
                    }
                    catch (Exception)
                    {
                        OutputMessage("Something went wrong.");
                        EditPerson();
                    }
                }
                else
                {
                    OutputMessage("");
                }
            }
            public void SearchPerson()
            {
                StartOption("Searching users:");

                //check if people in system
                //get name input
                //validate name
                //loop and check for name
                //output results
                //return back to menu

                if (!isSystemEmpty())
                {
                    Console.Write("Enter a name: ");
                    string nameInput = Console.ReadLine();

                    bool bFound = false;

                    if (!string.IsNullOrEmpty(nameInput)) // "" null
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (people[i].name.ToLower().Contains(nameInput.ToLower())) //Aba aba
                            {
                                Console.WriteLine(people[i].returnDetails());
                                bFound = true;
                            }
                        }

                        if (!bFound)
                        {
                            Console.WriteLine("No users found with that name.");
                        }

                        FinishOption();
                    }
                    else
                    {
                        OutputMessage("Please enter a name.");
                        SearchPerson();
                    }
                }
                else
                {
                    OutputMessage("");
                }
            }
            public void RemovePerson()
            {
                StartOption("Removing a user:");

                //check if people in system
                //output list of users
                //input selection
                //validation selection
                //print message
                //return back to menu

                if (!isSystemEmpty())
                {
                    PrintAllUsers();

                    Console.Write("Enter an index: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    index--;
                    //1-2
                    //0-1 2

                    if (index >= 0 && index <= people.Count - 1)
                    {
                        people.RemoveAt(index);
                        Console.WriteLine("Successfully removed a person.");

                        FinishOption();
                    }
                    else
                    {
                        OutputMessage("Enter a valid index inside the range.");
                        RemovePerson();
                    }
                }
                else
                {
                    OutputMessage("");
                }
            }
            public void FinishOption()
            {
                Console.WriteLine(Environment.NewLine + "You have finished this option. Press <Enter> to return to the menu.");
                Console.ReadLine();
                Console.Clear();    
            }
            public void StartOption(string message)
            {
                Console.Clear();
                Console.WriteLine(message + Environment.NewLine);
            }
            public void OutputMessage(string message)
            {
                if (message.Equals(string.Empty)) //message == "", message == string.Empty
                {
                    Console.Write("Press <Enter> to return to the menu.");
                }
                else
                {
                    Console.WriteLine(message + " Press <Enter> to try again.");
                }
                Console.ReadLine();
                Console.Clear();
            }
            public void PrintAllUsers()
            {
                for (int i = 0; i < people.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + people[i].returnDetails());
                }
            }
            public Person returnPerson()
            {
                Console.Write("Enter a name: ");
                string nameInput = Console.ReadLine(); //12312lasjdljask

                Console.Write("Enter a age: ");
                int ageInput = Convert.ToInt32(Console.ReadLine()); //hi

                if (!string.IsNullOrEmpty(nameInput)) //"a"
                {
                    if (ageInput >= 0 && ageInput <= 150) //-1
                    {
                        return new Person(nameInput, ageInput);
                    }
                    else
                    {
                        OutputMessage("Enter a sensible age.");
                    }
                }
                else
                {
                    OutputMessage("You didn't enter a name.");
                }

                return null;
            }
            public bool isSystemEmpty()
            {
                if (people.Count == 0)
                {
                    Console.WriteLine("There are no users in the system.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        static void Main(string[] args)
        {
            /*Person person = new Person("Aba", 23);

            Console.WriteLine(person.returnDetails());

            person.setName("Ab");
            person.setAge(20);
            Console.WriteLine(person.returnDetails());*/
            new Manager();

            Console.WriteLine("Goodbye!");

            Console.ReadLine();
        }
    }
}
