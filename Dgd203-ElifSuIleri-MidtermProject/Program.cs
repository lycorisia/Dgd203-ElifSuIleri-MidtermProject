using System;
using System.Collections.Generic;

class RPGClassSelectionGame
{
    static void Main()
    {
        Console.WriteLine("Hello, welcome to the Selection Coven! I am EMI! I will be your Class Seeker today :).");
        Console.WriteLine("I will give you a scenario for you to experience. This will make me look into your mind, heart and soul.");
        Console.WriteLine("Depending on your actions I will give you one of 4 classes: MAGE, WARRIOR, ROGUE, or HEALER!.");
        Console.WriteLine("But Maybe You May Even Be Something More...");

        string playerName;
        do
        {
            Console.Write("\nMay I know your name, Adventurer? ");
            playerName = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(playerName));

        Console.WriteLine($"\nWonderful to meet you, {playerName}! Let us begin.\n");

        int warriorScore = 0, mageScore = 0, rogueScore = 0, healerScore = 0;
        var random = new Random();

        var questions = new List<(string question, List<(string answer, string classType)> answers)>
        {
            
            ("~You spawn into a magical forest with a knife at hand, you can see endless trees and sounds of animals. The air is heavy like there's something that isn't supposed to be there. Suddenly you hear an bloodwrenching scream! What do you do?~",
                new List<(string, string)>
                {
                    ("-I can't afford to wait around. Whatever that is needs to be investigated.", "Warrior"),
                    ("-I don't know know who or what made that sound. It's best to move with caution.", "Mage"),
                    ("-There's a possibility that whatever made that scream wasn't human. Blending in with the surroundings is our best bet.", "Rogue"),
                    ("-They sound hurt! If that's a human they need help!.", "Healer")
                }),
            ("~You walk trough the depths of the forest following the sound till you come across a well where the sound is coming from. You need to go down but how?~",
                new List<(string, string)>
                {
                    ("-Jump straight down, It's not that deep... right?", "Warrior"),
                    ("-I am in a forest after all which means theres plats and vines around, I can use that as a rope!", "Mage"),
                    ("-Use the knife to make your fall slower, that way you won't hurt yourself", "Rogue"),
                    ("-I need to go there asap! Whoever down there may need assistance. Let me gather some supplies then go down.", "Healer")
                }),
            ("~Your at the bottom of the well, there seems to be an hallway infront of you. You don't know what's ahead of you considering it's pitch dark. How do you proceed?~",
                new List<(string, string)>
                {
                    ("-We rush ONWARDS! Waiting is not an option", "Warrior"),
                    ("-Use your hand to follow the wall foward", "Mage"),
                    ("-Take slow steps foward, be careful where you step.", "Rogue"),
                    ("-Hold the knife close to your chest and move, no need to be scared right?.", "Healer")
                }),
            ("~You walk till you find something metal infront of you, what is this thing? Wait is this a door?. It is! What do you do?~",
                new List<(string, string)>
                {
                    ("-I will use the knife to force the door open ", "Warrior"),
                    ("-Let me try to see if theres a way to open the door by feeling around the metal", "Mage"),
                    ("-A door can be picklocked right? Let me find those SWEET hinges", "Rogue"),
                    ("-A DOOR?! I CAN BARELY SEE HOW CAN I OPEN A DOOR?! It's fine I can open this, Let me find a lever maybe???.", "Healer")
                }),
            ("~The lights suddenly light up and your now face to face with a door, a giant metal door with no visible way to open it. Great, now what?~",
                new List<(string, string)>
                {
                    ("-It's just you and me door, who will win. CHARGE TO VICTORY!?", "Warrior"),
                    ("-A door means an obsticle, every obsticle has a way of solving it right? Let's observe the door", "Mage"),
                    ("-Okay let's backtrack and see how we can open the door", "Rogue"),
                    ("-Let's just take a deep breath and clear our head. Patience is the key", "Healer")
                }),
            ("~The door opens slowly revealing an dark room, the screams are gone it's silent. You move foward and see the injured person, what do you do?~",
                new List<(string, string)>
                {
                    ("-Run next to the injured person and get ready for a fight.", "Warrior"),
                    ("-Slowly approach the injured person, keep an eye for anything unusual. ", "Mage"),
                    ("-Let's move silently around the room, looking for any traps or hidden enemies before approaching.", "Rogue"),
                    ("-Let me approach the injured person carefully, checking for immediate signs of danger before tending to their wounds.", "Healer")
                }),
            ("~Coming closer you look at the injured person you realize it's not a person, It's a doll. You been tricked. The door closes behind you trapping you inside.~ ",
                new List<(string, string)>
                {
                    ("-I need to stay calm and collected and wait for any changes around you to strike.", "Warrior"),
                    ("-A doll? Okay then...let me observe the doll first then observe the surroundings.", "Mage"),
                    ("-This doll is clearly dangerous, lets take a couple steps back so I can look around my surroundings .", "Rogue"),
                    ("-I am stuck here, Let me keep this doll close to me like a company? Maybe I can use this somehow like a shield!.", "Healer")
                }),
            ($"~You hear footsteps coming from the other side of the room approaching is YOU, {playerName}. But how?~",
                new List<(string, string)>
                {
                    ("-Whoever that thing is, is not me. Knife I entrust my life to you.", "Warrior"),
                    ("-Is this an illusion or a copy maybe? Or am I the copy?", "Mage"),
                    ("-It must be a trick to get me distracted, I will try to outsmart it.", "Rogue"),
                    ("-Let me try to communicate with well, me.", "Healer")
                }),
            ($"~{playerName} walks right infront of you looking deeply into your eyes. You try to move but you can't?!~",
                new List<(string, string)>
                {
                    ("-I will scream,curse WHATEVER demand to know what they are", "Warrior"),
                    ("-I am under some sort of spell I guess... Okay let me try to find a way to break free ", "Mage"),
                    ("-Obviously I can't move so I will just say I am fucked ", "Rogue"),
                    ("-I can talk to them, They are me right so they can understand me!", "Healer")
                }),
            ($"~{playerName} reacher their hand first to your chest, then between your eyes and lastly to your forehead. You don't know what they are doing.~",
                new List<(string, string)>
                {
                    ("-I WILL CURSE UNTIL MY LAST BREATH YOU BI-", "Warrior"),
                    ("-Is this some sort of ritual, what is their end goal?", "Mage"),
                    ("-What a way to die, yippie...", "Rogue"),
                    ("-I know they can hear me they aren't hurting me right! Please listen to me the other me", "Healer")
                }),
            ($"~You close your eyes maybe because your desperate,maybe your enraged or maybe you accepted your death. You suddenly feel a familiar warmth. Curious you open your eyes to discover your in a white room face to face with {playerName}.~",
                new List<(string, string)>
                {
                    ("-I am getting tired of this chase game", "Warrior"),
                    ("-I wanna understand where I am, I want to understand the meaning of this. ", "Mage"),
                    ("-So I am alive, now lets see a way out.", "Rogue"),
                    ("-I told you they meant no harm :). I wanna wait and see", "Healer")
                }),
            ($"~{playerName} comes even closer staring at you not saying anything. You suddenly feel the knife appear in your hand, it seems you got control of your body. {playerName} opens their arm's like an embrace?",
                new List<(string, string)>
                {
                    ("-I will stab them right on the neck and watch them bleed out", "Warrior"),
                    ("-I don't trust them but they haven't done any harm. I would wait to see what they do.", "Mage"),
                    ("-I would give them the hug they want only to stab them. Shouldn't have trusted someone they played so much", "Rogue"),
                    ("-Drop the knife and give them a warm embrace", "Healer")
                }),
            ($"~The room starts to become brighter consuming you and {playerName}.~ You suddenly wake up infront of EMI. She look's back at you with a warm smile 'Well how was it?'",
                new List<(string, string)>
                {
                    ("-It was a chase game with no end. I don't know what anything was, all a blur.", "Warrior"),
                    ("-It was confusing, I can't explain it I have so many question.", "Mage"),
                    ("-Creepy. Absolutely creepy.", "Rogue"),
                    ("-It was sure a experience, It was weird but it wasn't awful.", "Healer")
                }),
            ("EMI smiles widely 'I hope I didn't startle you too much but good news I have gathered all that I needed' She exclaims",
                new List<(string, string)>
                {
                    ("-At least it's over. Now time to see what the results are! ", "Warrior"),
                    ("-I am amazed at the experience. I wonder how you managed to do that. Please do tell me my results", "Mage"),
                    ("-I am just glad it wasn't real. Hope you wheren't just fuckin' with me", "Rogue"),
                    ("-NO NO I wasn't startled at all. I am excited for the result's", "Healer")
                })
        };
        foreach (var question in questions)
{
    Console.WriteLine(question.question);

    // Shuffle answers
    var randomizedAnswers = new List<(string answer, string classType)>(question.answers);
    for (int i = randomizedAnswers.Count - 1; i > 0; i--)
    {
        int j = random.Next(i + 1);
        (randomizedAnswers[i], randomizedAnswers[j]) = (randomizedAnswers[j], randomizedAnswers[i]);
    }

    // Display randomized answers
    for (int i = 0; i < randomizedAnswers.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {randomizedAnswers[i].answer}");
    }

    // Player selects an answer
    int choice;
    do
    {
        Console.Write("\nYour choice (1-4): ");
    } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4);

    // Update scores based on the selected answer
    switch (randomizedAnswers[choice - 1].classType)
    {
        case "Warrior": warriorScore++; break;
        case "Mage": mageScore++; break;
        case "Rogue": rogueScore++; break;
        case "Healer": healerScore++; break;
    }
}

Console.WriteLine("Hmm...");

// Determine the player's class and description
string playerClass = "Adventurer";
string classDescription = "an adventurer, exploring all possibilities!";
string rareMessage = "";

if (warriorScore > mageScore && warriorScore > rogueScore && warriorScore > healerScore)
{
    playerClass = "Warrior";
    classDescription = "Brave and Strong. You are loyal to what you believe and nothing else.";
}
else if (mageScore > warriorScore && mageScore > rogueScore && mageScore > healerScore)
{
    playerClass = "Mage";
    classDescription = "With a thirst for knowledge, you wield powerful magic to discover this world's secrets.";
}
else if (rogueScore > warriorScore && rogueScore > mageScore && rogueScore > healerScore)
{
    playerClass = "Rogue";
    classDescription = "Silent and cunning, you don't take challenges head-on but try to find a way best suited for you.";
}
else if (healerScore > warriorScore && healerScore > mageScore && healerScore > rogueScore)
{
    playerClass = "Healer";
    classDescription = "Compassionate to the core. You see the good in every situation, trying to see the best in everything.";
}
else
{
    if (warriorScore == mageScore)
    {
        playerClass = "Battle Mage";
        rareMessage = $"Oh my, it seems you have a balance of Warrior and Mage. You are a Battle Mage, {playerName}!";
        classDescription = "A perfect blend of strength and intellect, you wield both blade and magic to protect what you believe.";
    }
    else if (warriorScore == rogueScore)
    {
        playerClass = "Shadow Knight";
        rareMessage = $"Oh my, it seems you have a balance of Warrior and Rogue. You are a Shadow Knight, {playerName}!";
        classDescription = "You are a shadow in this world. You have loyalty to yourself and only to yourself.";
    }
    else if (warriorScore == healerScore)
    {
        playerClass = "Paladin";
        rareMessage = $"Oh my, it seems you have a balance of Warrior and Healer. You are a Paladin, {playerName}!";
        classDescription = "A noble protector, you balance strength and compassion to defend your allies.";
    }
    else if (mageScore == rogueScore)
    {
        playerClass = "Arcane Trickster";
        rareMessage = $"Oh my, it seems you have a balance of Mage and Rogue. You are an Arcane Trickster, {playerName}!";
        classDescription = "Clever and resourceful, you weave magic to outsmart your foes. Nothing can outsmart you.";
    }
    else if (mageScore == healerScore)
    {
        playerClass = "Celestial";
        rareMessage = $"Oh my, it seems you have a balance of Mage and Healer. You are a Celestial, {playerName}!";
        classDescription = "Wise and empathetic, you use your magic to heal, guided by the knowledge of the cosmos.";
    }
    else if (rogueScore == healerScore)
    {
        playerClass = "Shadow Priest";
        rareMessage = $"Oh my, it seems you have a balance of Rogue and Healer. You are a Shadow Priest, {playerName}!";
        classDescription = "A helper for those who were left in the dark. Those ignored by society, you will protect.";
    }
}

// Display the rare message with description if applicable
if (!string.IsNullOrEmpty(rareMessage))
{
    Console.WriteLine($"\n{rareMessage}");
    Console.WriteLine(classDescription); // Add the class description here
}
else
{
    Console.WriteLine($"\nI, EMI the Class Seeker, looked into your mind, heart, and soul to discover your class... You are a {playerClass}!");
    Console.WriteLine(classDescription); // Add the class description for standard classes
}

// Farewell message
Console.WriteLine($"\nNow that we uncovered your class, {playerName}, it is time for you to depart. Let the gods protect you.");
Console.WriteLine("With that, you leave the Selection Coven, now ready for adventure! I wonder what the future holds. You just hope you get to see EMI again.");

    }
}