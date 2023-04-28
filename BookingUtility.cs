using BookingClass;
using ListingUtility;
namespace BookingUtility
{
    public class BUtility
    {
        public Booking[] sessionList;

        public BUtility(){
            sessionList= new Booking[100];
        }
        public Booking[] GetSession(){
            return sessionList;
        }

        public void Menu(){
        GetFile();
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("If you would like to View Available Training Sessions please enter 1");
        System.Console.WriteLine("If you would like to add a Session please enter 2");
        System.Console.WriteLine("If you would like to update booking status please enter 3");
        System.Console.WriteLine("If you would like to go back to the main menu please enter 4");
        string userChoice = Console.ReadLine();
            if(IsValidChoice(userChoice)){
                if(userChoice == "1"){
                    VeiwSession();
                }
                else if(userChoice == "2"){
                    AddBooking();
                }
                else if(userChoice == "3"){
                    BookingStatus();
                }
                else if(userChoice == "4"){
                    System.Console.Write("\n");
                    return;
                }
            }
            else{
            SayInvalid();
            } 
        
        }
        
        public void VeiwSession(){
            LUtility lutility = new LUtility();
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.WriteLine("Here are the fallowing avalible sessions:");
            for(int i = 0; i <= Booking.GetCount();i++){
                if(lutility.listingList[i].GetTaken() == "false"){
                    string date = lutility.listingList[i].GetDateOfSession();
                    string time = lutility.listingList[i].GetTimeOfSession();
                    string person = lutility.listingList[i].GetTrainerName();
                    System.Console.Write("A session is availbile on ");
                    System.Console.Write(date);
                    System.Console.Write(" at ");
                    System.Console.Write(time);
                    System.Console.Write(" with ");
                    System.Console.Write(person);
                    System.Console.Write("\n");

                }
            }
        }

        public void GetFile(){
            StreamReader inFile = new StreamReader("transactions.txt");
            string a = inFile.ReadLine();
            Booking.SetCount(0);
            while (a != null){
                if(!string.IsNullOrWhiteSpace(a)){
                    Array.Resize(ref sessionList, Booking.GetCount()+1);
                    string[]  b = a.Split('#');
                    sessionList[Booking.GetCount()] = new Booking(b[0], b[1], b[2], b[3], b[4], b[5], b[6]);
                    Booking.CountUp();
                }
                a = inFile.ReadLine();
            }
            inFile.Close();
      
        }

        public void PrintFile(){
            StreamWriter outfile = new StreamWriter("transactions.txt");
            for(int i = 0; i <= Booking.GetCount(); i++){
                string fileID = sessionList[i].GetSessionID();
                string fileName = sessionList[i].GetCustomerName();
                string fileEmail = sessionList[i].GetCustomerEmail();
                string fileDate = sessionList[i].GetTrainingDate();
                string fileTrainerID = sessionList[i].GetTrainerID();
                string fileTrainerName = sessionList[i].GetTrainerName();
                string fileStatus = sessionList[i].GetStatus();
                outfile.WriteLine($"{fileID}#{fileName}#{fileEmail}#{fileDate}#{fileTrainerID}#{fileTrainerName}#{fileStatus}");
                outfile.Write("\n");
            }
        outfile.Close();
        }


        public void AddBooking(){
            int counter = Booking.GetCount();
            string a = "a";
            bool b = false;
            sessionList[counter] = new Booking("","","","","","","");
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.Write("Please enter all your Booking information below for the number ");
            System.Console.Write(counter);
            System.Console.WriteLine(" Booking.");
            System.Console.Write("Please enter ! when you are finished");
            System.Console.Write("\n");
            while(a!="!"){
                counter = Booking.GetCount();
               System.Console.WriteLine("Please enter the Session ID");
               a = Console.ReadLine();
               if(a == "!"){
                break;
                }
                sessionList[counter].SetSessionID(a);
                System.Console.WriteLine("Please enter the Customers Name");
                a = Console.ReadLine();
                if(a == "!"){
                    break;
                }
                sessionList[counter].SetCustomerName(a);
                System.Console.WriteLine("Please enter the Customer Email");
                a = Console.ReadLine();
                if(a == "!"){
                break;
                }
                sessionList[counter].SetCustomerEmail(a);
                System.Console.WriteLine("Please enter the Training Date");
                a = Console.ReadLine();
                if(a == "!"){
                break;
                }
                sessionList[counter].SetTrainingDate(a);
                if(a == "!"){
                break;
                }
                System.Console.WriteLine("Please enter the Trainer ID");
                a = Console.ReadLine();
                if(a == "!"){
                    break;
                }
                sessionList[counter].SetTrainerId(a);
                System.Console.WriteLine("Please enter the Trainer Name");
                a = Console.ReadLine();
                if(a == "!"){
                    break;
                }
                sessionList[counter].SetTrainerName(a);
                sessionList[counter].SetStatus("booked");
                Booking.CountUp();
                counter++;
            }
            PrintFile();
            Menu();
        }


        public void BookingStatus(){
            string status;
            string id;
            bool check = true;
            Booking tempList = null;
            System.Console.WriteLine("-----------------------------------------------------------------------------------------");
            System.Console.WriteLine("Please enter the Session ID of the Session you would like to change the booking status of");
            id = Console.ReadLine();
            string temp = "";
            int a = findBooking(id,ref sessionList);
            if(a == -1){
                System.Console.WriteLine("Sorry the ID of that Session does not exist");
            }
            else{
                while(check = false){
                System.Console.WriteLine("Please Type Completed or Canceled to Edit the Booking Status");
                status = Console.ReadLine();
                    if(CheckStatus(status)){
                        sessionList[a].SetStatus(status);
                        System.Console.WriteLine("Booking Status has been updated!");
                        check = true;
                    }
                    else{
                        System.Console.WriteLine("Sorry please enter Completed or Canceled to Edit the Booking Status");
                    }
                }
            }
                
                
         PrintFile();       
        }

        public int findBooking(string id,ref Booking[]sessionList){
            for(int i = 0; i <= Booking.GetCount();i++){
                if(sessionList[i].GetSessionID() == id){
                    return i;
                }
            }
            return -1;
        }


//tempList = sessionList[a];
//sessionList[a].SetStatus("");
        static bool CheckStatus(String userInput){
            if(userInput.ToLower() == "cancelled"|| userInput.ToLower() == "completed"){
            return true;
            }
            return false;
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