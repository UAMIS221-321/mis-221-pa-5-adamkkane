namespace ExtraClass
{
    public class Extras
    {
        public void GymShop(){
            bool tru = true;
            int smoothies = GetRandom();
            int protienBars = GetRandom();
            int yogaMats = GetRandom();
            System.Console.WriteLine("Welcome to the Gym Shop below are the items we have in stock: ");
            System.Console.Write(smoothies); System.Console.Write(" smoothies, ");
            System.Console.Write(protienBars); System.Console.Write(" protien bars, and ");
            System.Console.Write(yogaMats); System.Console.Write(" yoga mats.");
            System.Console.Write("\n");
            while(tru){
            System.Console.WriteLine("Please Enter Smoothie, Protien Bar, or Yoga Mat to indicate the item you would like to buy or enter back to return to the main menu");
            string userChoice = Console.ReadLine();
            userChoice = userChoice.ToLower();
                if(userChoice == "smoothie"&&smoothies > 0){
                System.Console.Write("\n"); 
                smoothies = smoothies -1;
                System.Console.Write("Thank you! We now have "); System.Console.Write(smoothies); System.Console.Write(" availible.");
                }
                else if(userChoice == "protien bar"&&protienBars > 0){
                System.Console.Write("\n"); 
                protienBars = protienBars -1;
                System.Console.Write("Thank you! We now have "); System.Console.Write(protienBars); System.Console.Write(" availible.");
                }
                else if(userChoice == "yoga mat"&&yogaMats > 0){
                System.Console.Write("\n"); 
                yogaMats = yogaMats -1;
                System.Console.Write("Thank you! We now have "); System.Console.Write(yogaMats); System.Console.Write(" availible.");
                }
                else if(userChoice == "back"){
                    tru = false;
                System.Console.Write("\n"); 
                }
                else{
                    System.Console.Write("\n");
                    System.Console.Write("I am sorry we either do not have that item in stock or you are requesting the wrong item please try entering your item again or enter back to return to the main menu.");
                }
            }
            }
        

    public void RoomMenu(){
    System.Console.WriteLine("\n");
    System.Console.WriteLine("Hello here is a diagram of our workout room selection");
    System.Console.WriteLine("We have 10 rooms in total and a room with a O is open and a X is taken");
    PrintRooms();
}

//Main calculation Method for room selection
public void PrintRooms(){
    int open = 0;
    int taken = 0;
    Random rnd = new Random();
    int rows = rnd.Next(4,10);
    System.Console.WriteLine("\n");
    System.Console.WriteLine("1 2 3 4 5 6 7 8 9 10");
    for(int b = 0; b < 10; b++){
            int d = rnd.Next(2);
            if(Random(d)){
                System.Console.Write("O ");
                open++;
            }
            else{
                System.Console.Write("X ");
                taken++;
            }
        }

    if(open == 0){
        System.Console.WriteLine("\n");
        System.Console.WriteLine("Im so sorry we have no rooms open at this time. We are sorry for this inconvience please come again another day");
    }
    else{
    System.Console.WriteLine("\n");
    System.Console.Write("We currently have ");
    System.Console.Write(open);
    System.Console.Write(" open rooms. How many rooms would you like to book");
    System.Console.WriteLine("\n");
    string stringRooms = Console.ReadLine();
    if(IsValidRoom(stringRooms)){
        double numRooms = int.Parse(stringRooms);
        if(numRooms > open){
            System.Console.WriteLine("\n");
            System.Console.Write("I am so sorry but unfortunately we do not have that many rooms avalible");
        }
    
        else{
            System.Console.WriteLine("\n");
            System.Console.Write("Thank you so much for using our service we have reserved ");
            System.Console.Write(numRooms);
            System.Console.Write(" rooms for you. Please Come again!");
            }
        }
        else{
            System.Console.WriteLine("\n");
            SayInvalid();
        }
    }
}

//check to see if the User chose a valid room option
public bool IsValidRoom(String userInput){
    if(userInput == "1"|| userInput == "2"||userInput == "3"||userInput == "4"||userInput == "5"||userInput == "6"||userInput == "7"||userInput == "8"||userInput == "9"||userInput == "10"){
         return true;
    }
    return false;

}

        public int GetRandom(){
            Random rnd = new Random();
            int random = rnd.Next(0,9);
            return random;
        }

        public bool Random(int c){
            if(c == 0){
            return true;
            }
            else{
            return false;
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
            Console.Clear();
            
        }   
    }
}