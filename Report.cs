using TrainerUtility;
using ListingUtility;
using BookingUtility;
using TrainerClass;
using ListingClass;
using BookingClass;
namespace ReportClass
{
    public class Report
    {
        public void Menu(){
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("If you would like to View Individual Customer Sessions please enter 1");
        System.Console.WriteLine("If you would like to Veiw Historical Customer Sessions please enter 2");
        System.Console.WriteLine("If you would like to Veiw a Historical Revenue Report please enter 3");
        System.Console.WriteLine("If you would like to go back to the main menu please enter 4");
        string userChoice = Console.ReadLine();
            if(IsValidChoice(userChoice)){
                if(userChoice == "1"){
                    CustomerSessions();
                }
                else if(userChoice == "2"){
                    HistoricalSessions();
                }
                else if(userChoice == "3"){
                    RevenueReport();
                }
                else if(userChoice == "4"){

                }
            }
            else{
            SayInvalid();
            } 
        
        }

        public void CustomerSessions(){
            LUtility lutility = new LUtility();
            BUtility butility = new BUtility();
            System.Console.WriteLine("Please enter in a customer email to veiw previous training sessions");
            string email = Console.ReadLine();
            for(int i = 0; i <= Booking.GetCount();i++){
                if(butility.sessionList[i].GetCustomerEmail() == email){
                    string date = butility.sessionList[i].GetTrainingDate();
                    string customer = butility.sessionList[i].GetCustomerName();
                    string person = butility.sessionList[i].GetTrainerName();
                    System.Console.Write("The customer named ");
                    System.Console.Write(customer);
                    System.Console.Write(" had a session on ");
                    System.Console.Write(date);
                    System.Console.Write(" with ");
                    System.Console.Write(person);
                    System.Console.Write("\n");
                }
            }
        }    

        public void HistoricalSessions(){
            System.Console.WriteLine("Here is all Sessions sorted by Customer Alphabetically");
            BUtility butility = new BUtility();
            for(int i = 0; i <= Booking.GetCount();i++){
                int x = Int32.Parse(butility.sessionList[i].GetTrainingDate());
                int y = Int32.Parse(butility.sessionList[i+1].GetTrainingDate());
                if(x>y){
                    Booking templist = butility.sessionList[i];
                    butility.sessionList[i] = butility.sessionList[i+1];
                    butility.sessionList[i+1] = templist;
                    
                }

            }
            
            for(int i = 0; i <= Booking.GetCount();i++){
                int count = 0;
                int countTwo = 0;
                while(butility.sessionList[count].GetCustomerName() == butility.sessionList[count+1].GetCustomerName()){
                    countTwo++;
                    count++;
                }
                System.Console.Write("The customer ");
                System.Console.Write(butility.sessionList[count].GetCustomerName);
                System.Console.Write(" has booked ");
                System.Console.Write(countTwo);
                System.Console.Write(" Sessions");
            }
        }




        public void RevenueReport(){
            LUtility lutility = new LUtility();
            int total = 0;
            System.Console.WriteLine("Please enter Month to see the Revenue Report by Month and Year to see the Revenue Report by Year");
            string choice = Console.ReadLine();
            choice = choice.ToLower();
            if(choice == "month"){
                for(int i = 0; i <= Booking.GetCount();i++){
                    string temp = lutility.listingList[i].GetCostOfSession();
                    if(temp != ""){
                        int num = Int32.Parse(temp);
                        total = (total + num)/12;
                        System.Console.Write("We earned ");
                        System.Console.Write(total);
                        System.Console.Write(" dollars");
                    }    
                }
            }
            else if(choice == "year"){
               for(int i = 0; i <= Booking.GetCount();i++){
                    string temp = lutility.listingList[i].GetCostOfSession();
                    if(temp != ""){
                        int num = Int32.Parse(temp);
                        total = total + num;
                        System.Console.Write("We earned ");
                        System.Console.Write(total);
                        System.Console.Write(" dollars");
                    }    
                }
            }
        }

        //A method to inform the user that they have given an invalid input
        static void SayInvalid(){
            System.Console.WriteLine("\n");
            System.Console.WriteLine("Sorry your choice is invalid");
            PauseAction();
        }

        //A method used to pause the users interface after they have given an invalid choice
        static void PauseAction(){
            System.Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
            //check to see if the User chose a valid menu option
        static bool IsValidChoice(String userInput){
            if(userInput == "1"|| userInput == "2"||userInput == "3"||userInput == "4"){
            return true;
            }
            return false;

        } 
    }
}