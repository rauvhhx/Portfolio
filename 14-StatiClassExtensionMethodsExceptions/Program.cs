using System;
using LoginSystemApp.Services;
using LoginSystemApp.Exceptions;

namespace LoginSystemApp
{
    public class Program
    {
        public static void Main()
        {
            LoginSystem loginSystem = new LoginSystem();

            while (true)
            {
                try
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    if (loginSystem.Login(username, password))
                        break;
                }
                catch (InvalidUsernameException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (InvalidPasswordException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    Console.WriteLine();
                    loginSystem.ShowAllUsers();
                }
                catch (IncorrectPasswordException ex)
                {
                    Console.WriteLine("WARNING: " + ex.Message);
                }
                catch (AccountLockedException ex)
                {
                    Console.WriteLine("CRITICAL: " + ex.Message);
                    Console.WriteLine("Please contact the administrator.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
                }

                Console.WriteLine();
            }
        }
    }
}
