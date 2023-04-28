using TrainerUtility;
using ListingUtility;
using BookingUtility;
using ReportClass;
using ExtraClass;

//start main 
Console.Clear();
Boolean constant = true;
int menuChoice = GetUserChoice();
int selection = RouteMenu(menuChoice);
while(constant){
if(selection == 1){
    TUtility tutility = new TUtility();
    tutility.Menu();
    menuChoice = GetUserChoice();
    selection = RouteMenu(menuChoice);
}
else if(selection == 2){
    LUtility lutility = new LUtility();
    lutility.Menu();
    menuChoice = GetUserChoice();
    selection = RouteMenu(menuChoice);
}
else if(selection == 3){
    BUtility butility = new BUtility();
    butility.Menu();
    menuChoice = GetUserChoice();
    selection = RouteMenu(menuChoice);
}
else if(selection == 4){
    Report rClass = new Report();
    rClass.Menu();
    menuChoice = GetUserChoice();
    selection = RouteMenu(menuChoice);
}
else if(selection == 5){
    Extras extra = new Extras();
    extra.GymShop();
    menuChoice = GetUserChoice();
    selection = RouteMenu(menuChoice);
}

else if(selection == 6){
    Extras extra = new Extras();
    extra.RoomMenu();
    menuChoice = GetUserChoice();
    selection = RouteMenu(menuChoice);
}
else if(selection == 7){
    Exit();
    constant = false;
}
else{
    SayInvalid();
}
}
 //end main

//Used to get the User choice of the first menu option
static int GetUserChoice(){
    DisplayMenu();
    string userChoice = Console.ReadLine();
    if(IsValidChoice(userChoice)){
        return int.Parse(userChoice);
    }
    else{
    SayInvalid();
    return 0;
    } 
}

//first menu options
static void DisplayMenu(){
    System.Console.WriteLine("If you would like to Manage Trainer Data please enter 1");
    System.Console.WriteLine("If you would like to Manage Listing Data please enter 2");
    System.Console.WriteLine("If you would like to Manage Customer Booking Data please enter 3");
    System.Console.WriteLine("If you would like to Run Reports please enter 4");
    System.Console.WriteLine("If you would like to Visit the Gym Shop please enter 5");
    System.Console.WriteLine("If you would like to Reserve a Personal Training Room please enter 6");
    System.Console.WriteLine("If you would like to Exit please enter 7");
    System.Console.WriteLine("\n");
}



//check to see if the User chose a valid menu option
static bool IsValidChoice(String userInput){
    if(userInput == "1"|| userInput == "2"||userInput == "3"||userInput == "4"||userInput == "5"||userInput == "6"||userInput == "7"){
         return true;
    }
    return false;
}

//Used to take the user to the next corect screen/task
static int RouteMenu(int menuChoice){
    if(menuChoice == 1){
        return 1;
    }
    else if(menuChoice == 2){
        return 2;
    }
    else if(menuChoice == 3){
        return 3;
    }
    else if(menuChoice == 4){
        return 4;
    }
    else if(menuChoice == 5){
        return 5;
    }
    else if(menuChoice == 6){
        return 6;
    }
    else if(menuChoice == 7){
        return 7;
    }
    else{
        return 8;
    }
}

//A short method to Exit out of the program
static void Exit(){
 Console.Clear();
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
