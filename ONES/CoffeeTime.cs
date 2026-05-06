using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000092 RID: 146
    [Transaction(TransactionMode.Manual)]
    public class CoffeeTime : IExternalCommand
    {
        // Token: 0x06000374 RID: 884 RVA: 0x00036A30 File Offset: 0x00034C30
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> list = new List<string>();
            list.Add("Coffee should be black as hell, strong as death and sweet as love.\n- Turkish Proverb");
            list.Add("Coffee is a beverage that puts one to sleep when not drank. \n - Alphonse Allais");
            list.Add("I never drink coffee at lunch. I find it keeps me awake for the afternoon\n- Ronald Regan");
            list.Add("If this is coffee, please bring me some tea; but if this is tea, please bring me some coffee\n- Abraham Lincoln");
            list.Add("A mathematician is a device for turning coffee into theorems\n- Alfred Renyi");
            list.Add("Like everyone else who makes the mistake of getting older, I begin each day with coffee and obituaries\n- Bill Cosby");
            list.Add("I wake up some mornings and sit and have my coffee and look out at my beautiful garden, and I go, ’Remember how good this is. Because you can lose it.’\n- Jim Carrey");
            list.Add("A girl in a bikini is like having a loaded pistol on your coffee table - There's nothing wrong with them, but it's hard to stop thinking about it.\n- Garrison Keillor");
            list.Add("Good communication is as stimulating as black coffee, and just as hard.\n- Anne Spencer");
            list.Add("I like my coffee like I like my women. In a plastic cup.\n- Eddie Izzard");
            list.Add("Women aren’t supposed to make coffee…the Bible says, “He-brews”");
            list.Add("Coffee is always a good idea");
            list.Add("When life gives you lemons, trade them for coffee");
            list.Add("Here’s to all the people who remain unharmed because I have coffee and a sense of humor");
            list.Add("I want someone to look at me the way I look at coffee");
            list.Add("Decaf coffee only works if you throw it at people");
            list.Add("You should know that before 10am, no matter what the question is, my answer is always coffee");
            list.Add("I love my Saturday coffee the way I used to love Saturday morning cartoons\n- Nanea Hoffman");
            list.Add("Patience is the time between drinking a cup of coffee and the motivation to begin your day");
            list.Add("Sometimes I go hours without drinking coffee…it’s called sleeping");
            list.Add("May your coffee be strong, and your Monday be short");
            list.Add("I will start working when my coffee does");
            list.Add("What goes best with a cup of coffee? Another cup\n- Henry Rollins");
            list.Add("Coffee is a language in itself\n- Jackie Chan");
            list.Add("I judge a restaurant by the bread and the coffee.\n- Burt Lancaster");
            list.Add("Behind every successful woman is a substantial amount of coffee.\n- Stephanie Piro");
            list.Add("It’s amazing how the world begins to change through the eyes of a cup of coffee.\n- Donna A. Favors");
            list.Add("Science may never come up with a better office communication system than the coffee break.\n- Earl Wilson");
            list.Add("A real prince brings coffee");
            list.Add("Coffee; because hating your job should be done with enthusiasm");
            list.Add("Friends bring happiness into your life. Best friends bring coffee.");
            list.Add("There is no use crying over spilled milk…spilled coffee however, may get you stabbed");
            list.Add("Come here you giant cup of beautiful coffee and lie to me about how much were going to get done today");
            list.Add("I like my coffee like I like myself: strong, sweet, and too hot for you\n- Jac Vanek");
            list.Add("Want to hear a really dark joke?…Decaf");
            list.Add("I have measured out my life with coffee spoons\n- T.S. Eliot");
            list.Add("To make me happy: Make me coffee, bring me coffee, be coffee….coffee");
            list.Add("I don’t have enough coffee or middle fingers for today");
            list.Add("Dontcha wish your coffee was hot like me?");
            list.Add("Instant Human! Just add coffee");
            list.Add("The fact is, I don’t know where my ideas come from. Nor does any writer. The only real answer is to drink way too much coffee and buy yourself a desk that doesn’t collapse when you eat your head against it.\n- Douglas Adams");
            list.Add("Coffee, because crack isn't accepted in the workplace");
            list.Add("Frankly, my dear, I don’t give a damn.\n - GONE WITH THE WIND");
            list.Add("I'm going to make him an offer he can't refuse.\n - THE GODFATHER");
            list.Add("You don't understand! I coulda had class. I coulda been a contender.I could've been somebody, instead of a bum, which is what I am.\n - ON THE WATERFRONT");
            list.Add("Toto, I've got a feeling we're not in Kansas anymore.\n - THE WIZARD OF OZ");
            list.Add("Go ahead, make my day.\n - SUDDEN IMPACT");
            list.Add("You talking to me?\n - TAXI DRIVER");
            list.Add("What we've got here is failure to communicate.\n - COOL HAND LUKE");
            list.Add("Made it, Ma! Top of the world!\n - WHITE HEAT");
            list.Add("Show me the money!\n - JERRY MAGUIRE");
            list.Add("I'm walking here! I'm walking here!\n - MIDNIGHT COWBOY");
            list.Add("You can't handle the truth!\n - A FEW GOOD MEN");
            list.Add("I'll be back\n - THE TERMINATOR");
            list.Add("Mama always said life was like a box ofchocolates.You never know what you'regonna get.\n - FORREST GUMP");
            list.Add("I see dead people\n - THE SIXTH SENSE");
            list.Add("A boy's best friend is his mother.\n - PSYCHO");
            list.Add("Keep your friends close, but your enemies closer\n - GODFATHER II,");
            list.Add("As God is my witness, I'll never be hungry again.\n - GONE WITH THE WIND");
            list.Add("Well, here's another nice mess you've gotten me into!\n - SONS OF THE DESERT");
            list.Add("Say hello to my little friend!\n - SCARFACE");
            list.Add("Here's Johnny!\n - THE SHINING");
            list.Add("Forget it, Jake, it's Chinatown.\n - CHINATOWN");
            list.Add("I have always depended on the kindness of strangers\n - THE STREETCAR NAMED DESIRE");
            list.Add("Hasta la vista, baby\n - TERMINATOR 2: JUDGMENT DAY");
            list.Add("Oh, no, it wasn't the airplanes. It was Beauty killed the Beast\n - KING KONG");
            list.Add("My precious\n - LORD OF THE RINGS");
            list.Add("I'm king of the world!\n - TITANIC");
            list.Add("A man who doesn't spend time with his family can never be a real man.\n - THE GODFATHER");
            try
            {
                Random random = new Random();
                CoffeeTimeForm coffeeTimeForm = new CoffeeTimeForm(list[random.Next(0, list.Count)]);
                coffeeTimeForm.ShowDialog();
            }
            catch (Exception)
            {
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}