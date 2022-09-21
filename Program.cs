
// RECIPE PRINTER
//- Användaren ska få feedback från programmet att mata in en ingredienser till en lista:
// Varje ingrediens ska sparas i en lista med strängar.
//
// - Ge användaren feedback (på ett snyggt sätt) att, om den är färdig, ska den skriva “Finished”
// (eller kanske bara trycka på enter? Eller något annat?) för att gå vidare.
//
// - När användaren valt att gå vidare ska alla ingredienser användaren skrivit in i tidigare
// steg printas till konsollen:
// Använd en for each -loop för att printa alla ingredienser till konsollen
//
// - Ge användaren möjlighet att ta bort en ingrediens, om den skriver t.ex. “Remove” i konsollen…
//
// - Ge även användaren möjligheten att printa ingredienserna när den vill, inte bara när den är färdig
// och ge den även möjligheten att, efter att den printat alla ingredienser, gå tillbaka och
// lägga till/ta bort saker från listan igen.
//
// Superbonus: Ge användaren en prompt att även fylla i vilken kvantitet som varje specifik ingrediens
// ska ha, och spara denna i en lista med integers eller floats (inte strängar)! Du kan även använda
// Dictionaries, men då får du kolla upp lite själv (se “Resurser” nedan)

// --------------------------------------------------------------------------------------------------

// make dictionary to keep recipe and amount
Dictionary<string, int> recipeList = new();

// create bool that keeps the main program loop active
bool running = true;

// Variable to change text colors
ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

// while loop to keep the program running
while (running)
{
    // Clear screen
    Console.Clear();

    // Print the header
    ShowHeader();

    // Print current recipe
    ShowRecipeList();

    // Ask user what ingredient to add
    Console.Write("\nWhat ingredient would you like to add? ");
    string userInputName = Console.ReadLine();

    // if user writes exit, application ends
    if (userInputName == "exit")
    {
        running = false;
        Console.WriteLine("\nThanks for using Koffes recipe list simulator 2022!");
        Console.ReadLine();
    }

    // elseif user writes "remove"
    else if (userInputName == "remove")
    {
        // ask user what to remove
        Console.Write("\nWhat ingredient would you like to remove? ");
        string userInputRemove = Console.ReadLine();
        RemoveIngredientFromRecipe(userInputRemove);
    }

    else
    {
        // else user adds ingredient
        Console.Write("\nHow many {0} do you want to add? ", userInputName);
        int userInputAmount = Convert.ToInt32(Console.ReadLine());
        AddIngredientToRecipe(userInputName, userInputAmount);
    }
}

void ShowHeader()
{
    Message(" -----------------------------\n|| RECIPE LIST SIMULATOR 2022 ||\n -----------------------------\n", 14);
}

void ShowRecipeList()
{
    Console.WriteLine("| AMOUNT - INGREDIENT |");
    foreach (KeyValuePair<string, int> kvp in recipeList)
    {
        Console.WriteLine("    {1}        {0}", kvp.Key, kvp.Value);
    }
}

void Message(string msg, int color)
{
    Console.ForegroundColor = colors[color];
    Console.WriteLine("\n" + msg);
    Console.ForegroundColor = ConsoleColor.White;
}

void AddIngredientToRecipe(string name, int amount)
{
    try
    {
        recipeList.Add(name, amount);
        Message("Added " + amount + " " + name + " to the recipe list!", 10);
    }
    catch (ArgumentException)
    {
        Message(name + " already on the recipe list!", 12);
    }
    Console.ReadLine();
}
void RemoveIngredientFromRecipe(string name)
{
    if (!recipeList.ContainsKey(name))
    {
        Message(name + " is NOT on the recipe list!", 12);
    }
    else
    {
        recipeList.Remove(name);
        Message("Removed " + name + " from the recipe list!", 12);
    }
    Console.ReadLine();
}