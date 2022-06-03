// This is challenge work for the "C# Players Guide"
// Level 19 the Vin's Trouble Challenge
// This challenge mirrors the Level 18 challenge, but requires that that Arrow Class is changed from public to private
// Addtionally a "getter" methods must be added for each of the fields in the class.


//Main
StartMenu();
Arrow ArrowOne = ArrowFactory(); // Call Arrow Factory, this allows more than one instance of arrow to be created or added later
float ArrowCost = ArrowOne.GetCost();
FinalCloseOut(ArrowOne, ArrowCost);

//Methods
void StartMenu()
{
    char face = ((char)2);
    Console.WriteLine("***************Arrow Factory 3000: Ready to take your order*************");
    Console.WriteLine("\nWelcome to Vin Fleatcher's High End Arrows");
    Console.WriteLine("Fabulous Arrows for Fabulous Rangers!");
    Console.WriteLine("\n" + face + " Press any key to build the arrows of your dreams " + face);
    Console.ReadKey();
    Console.Clear();
}

// ArrowFactory Method (Method of methods) to return new arrow:
// This is needed so that main can call as many arrows as is needed (if needed)
Arrow ArrowFactory()
{
    Console.WriteLine("*******************Arrow Factory 3000: Building order******************");
    Arrowhead ArrowHead = BuildArrowHead(); //must be set to Arrowhead because of the enum
    Fletchingmaterial FletchingMaterial = BuildFletchingMaterial(); //must be set to Fletchingmaterial because of the enum
    float TotalLength = BuildTotalLength();
    return new Arrow(ArrowHead, FletchingMaterial, TotalLength);
}

//must be set to Arrowhead because of the enum
Arrowhead BuildArrowHead()
{
    //Get user info for Arrowhead
    string arrow_info = "null";
    while (arrow_info != "steel" && arrow_info != "wood" && arrow_info != "obsidian")
    {
        Console.WriteLine("\nPlease enter the arrowhead type for your custom arrows (Steel,Wood, or Obsidian): ");
        arrow_info = Console.ReadLine().ToLower();
    }
    Arrowhead head = arrow_info switch //must be set to Arrowhead because of the enum
    {
        //standardized input using enum
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian,
    };
    return head;
}

Fletchingmaterial BuildFletchingMaterial() //must be set to Fletchingmaterial because of the enum
{
    // Get user info for Fletching type
    string fletching_info = "null";
    while (fletching_info != "plastic" && fletching_info != "turkey feathers" && fletching_info != "goose feathers")
    {
        Console.WriteLine("\nPlease enter the Fletching type for your custom arrows (Plastic, Turkey Feathers, or Goose Feathers): ");
        fletching_info = Console.ReadLine().ToLower();
    }
    Fletchingmaterial fletch = fletching_info switch  //must be set to Fletchingmaterial because of the enum
    {
        //standardized input using enum
        "plastic" => Fletchingmaterial.Plastic,
        "turkey feathers" => Fletchingmaterial.TurkeyFeathers,
        "goose feathers" => Fletchingmaterial.GooseFeathers,
    };
    return fletch;
}

float BuildTotalLength()
{
    //Get user info for Arrow Length
    float Length;
    do
    {
        Console.WriteLine("\nPlease enter the shaft length of your custom arrows (Between 60 and 100 cm): ");
        Length = Convert.ToSingle(Console.ReadLine());
    }
    while (Length < 60 || Length > 100);
    return Length;
}

void FinalCloseOut(Arrow arrowOne, float arrowCost)
{
    Console.Clear();
    Console.WriteLine("*******************Arrow Factory 3000: Processing order******************");
    Console.WriteLine($"The arrow you created has the following characteristics: " +
    $"\nThe Arrowhead is made of {ArrowOne.GetArrowhead()}" +
    $"\nThe Fletching is made of {ArrowOne.GetFletchingMaterial()} " +
    $"\nThe Shaft is {ArrowOne.GetTotalLength()} cm");
    Console.WriteLine($"\nThis type of custom arrow costs a total of {ArrowCost} gold per arrow");
    Console.Write($"\nHow many of these arrows would you like to order?: ");
    float TotalCost = Convert.ToSingle(Console.ReadLine());
    TotalCost *= ArrowCost;
    Console.WriteLine($"\nThe total amount due for these luxury custom arrows: {TotalCost} gold");
    Console.WriteLine("\nThanks for shopping at Vin Fleatchers!");
    Console.WriteLine("\nPress any key to exit the Arrow Factory 3000");
    Console.ReadKey();
}
class Arrow
{
    //must be set to Arrowhead because of the enum
    //must be set to Fletchingmaterial because of enum
    // Set to private
    private Arrowhead _ArrowHead;
    private Fletchingmaterial _FletchingMaterial;
    private float _TotalLength;

    //must be set to Arrowhead because of the enum
    //must be set to Fletchingmaterial because of enum 
    public Arrow(Arrowhead ArrowHead, Fletchingmaterial FletchingMaterial, float TotalLength)
    {
        _ArrowHead = ArrowHead;
        _FletchingMaterial = FletchingMaterial;
        _TotalLength = TotalLength;
    }
    //Used get to work around private setting (used by lines 93 -95)
    public Arrowhead GetArrowhead() => _ArrowHead;
    public Fletchingmaterial GetFletchingMaterial() => _FletchingMaterial;
    public float GetTotalLength() => _TotalLength;     
    //Method for total price
    public float GetCost()
    {
        float HeadCost = _ArrowHead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5
        };

        float FletchingCost = _FletchingMaterial switch
        {
            Fletchingmaterial.Plastic => 10,
            Fletchingmaterial.TurkeyFeathers => 5,
            Fletchingmaterial.GooseFeathers => 3,
        };

        float LengthCost = .05f * _TotalLength;
        return HeadCost + FletchingCost + LengthCost;
    }
}

//Enum
enum Arrowhead { Steel, Wood, Obsidian }
enum Fletchingmaterial { Plastic, TurkeyFeathers, GooseFeathers }
