using System;
using System.Threading;
using UppgiftGruppFördjupning;

//våra twister på spelet
//ett väggobjekt som drar av poäng vid kollision
//Ändrad färg på spelplanen
//hastigheten på spelaren beronde på poäng



/// <summary>
/// skickar anrop till metoder via instanser
/// ger spelet dess form och håller spelet igång
/// </summary>
/// <param framrate="2">sätter spelarens fart </param>
/// <param GameWorld world = new GameWorld"(30,10);">genererar värld med satt storlek</param>
/// <param Player player = new Player"(Player.Direction.höger, '*');">Placerar ut spelaren med en startrikting åt höger</param>
/// <param world.AllObjects.Add"(player);">Lägger till spelaren bland alla objekt</param>
/// <param Food äpple = new Food"('+', 2, 3);">Skapar en matbit</param>
/// <param world.AllObjects.Add"(äpple);">Lägger till en matbit bland objekten</param>
/// <param Wall vägg = new Wall"('|', 5, 8);">Skapar en vägg</param>
/// <param world.AllObjects.Add"(vägg);">Lägger till en vägg bland objekten</param>
/// <param ConsoleRenderer renderer = new ConsoleRenderer"(world);">Get oss tillgång till render funktionaliteten</param>
// utan att bromsa upp spelet, som Console.ReadLine() gör
ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;


// Initialisera spelet

int frameRate = 2;
GameWorld world = new GameWorld(30,10);
Player player = new Player(Player.Direction.höger, '*');
world.AllObjects.Add(player);
Food äpple = new Food('+', 2, 3);
world.AllObjects.Add(äpple);
Wall vägg = new Wall('|', 5, 8);
world.AllObjects.Add(vägg);
ConsoleRenderer renderer = new ConsoleRenderer(world);




// Huvudloopen
bool running = true;
while (running)
{
    // Kom ihåg vad klockan var i början
    DateTime before = DateTime.Now;

    // Hantera knapptryckningar från användaren
    ConsoleKey key = ReadKeyIfExists();
    switch (key)
    {
        case ConsoleKey.Q:
            running = false;
            break;
        case ConsoleKey.W:
            player.dir = Player.Direction.upp;
            break;
        case ConsoleKey.S:
            player.dir = Player.Direction.ner;
            break;
        case ConsoleKey.A:
            player.dir = Player.Direction.vänster;
            break;
        case ConsoleKey.D:
            player.dir = Player.Direction.höger;
            break;

            
    }

    //ökar frameraten/farten på player beronde på poängen
    frameRate = world.points + 3;





    // Uppdatera världen och rendera om
    renderer.RenderBlank();
    world.Update();
    renderer.Render();

    // Mät hur lång tid det tog
    double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
    if (frameTime > 0)
    {
        // Vänta rätt antal millisekunder innan loopens nästa varv
        Thread.Sleep((int)frameTime);
    }
    
}