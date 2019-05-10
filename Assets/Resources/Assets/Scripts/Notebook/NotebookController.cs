using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NotebookController
{
    private static string[] LevelKeys= {
        "ShipL1", "ShipL2", "ShipL3"
    };

    private static string[] PuzzleKeys= {
        "L1_P1", "L1_P2", "L1_P3", "L2_P1", "L2_P2", "L2_P3", "L3_P1", "L3_P2", "L3_P3"
    };

    //NotesAccess tracks which notes should be available to the player. 0 - locked, 1 - unlocked and current level, 2 - unlocked, but previous level
    private static Dictionary<string, int> NotesAccess = new Dictionary<string, int>
        {
            {"ShipL1",  1},
            {"L1_P1",   0},
            {"L1_P2",   0},
            {"L1_P3",   0},
            {"ShipL2",  0},
            {"L2_P1",   0},
            {"L2_P2",   0},
            {"L2_P3",   0},
            {"ShipL3",  0},
            {"L3_P1",   0},
            {"L3_P2",   0},
            {"L3_P3",   0}
        };

    //The NotesText dictionary stores all the notebook text under the appropriate key. L is shorthand for level. P is shorthand for puzzle
    private static Dictionary<string, string> NotesText = new Dictionary<string, string>
        {
            { "ShipL1",     "Jeg våknet opp i et rom, til min store forundrelse husker jeg ingenting fra i går. Like etter at jeg våknet, møtte jeg Tarek og Hani. Sammen prøver vi å finne ut av hva vi skal gjøre videre..." },
            { "L1_P1",       "Landet vi er i, har fjorder og fjell. De bruker også noen ganger en rar måte å telle på, men jeg tror det er ganske gammeldags." },
            { "L1_P2",       "En ting er sikkert: De spiser mye merkelig mat i dette landet! Hvem skulle tro at noen ville spise et sauehode?" },
            { "L1_P3",       "Nå har jeg notert ned ordtakene! \"Ikke selg skinnet før du har skutt bjørnen.\", \"Snakker du om sola, så skinner den.\"" },
            { "ShipL2",     "Etter at vi fullførte alle oppgavene i Norge, reiste vi videre, det første vi la merke til var at det var veldig varmt her..." },
            { "L2_P1",       "Da vet vi at innbyggerne i dette landet bruker disse metaforene: PLACEHOLDER(tegn ikke støttet av unity). Kanskje det kan gi noen hint om hvilket område vi befinner oss i også?" },
            { "L2_P2",       "Vi er i et område der det er ørkenlandskap, og der de skriver med en annen type bokstaver. Og de har nydelige lavendelblomster og sommerfulger!" },
            { "L2_P3",       "I dette landet spiser de Injera, tshebi, Kitcha fit-fit, Ga'at og Hamli. Jeg blir sulten bare av å tenke på det." },
            { "ShipL3",     "Når vi fullførte utfordingene i Eritra, reiste vi nok en gang til et nytt sted." },
            { "L3_P1",       "Det store maleriet på veggen kunne kanskje gi noen hint om hvor vi er? Sooker, moskeer, sandfargede hus…" },
            { "L3_P2",       "Landet vi er i, bruker et annet skriftspråk enn det latinske. Er det arabisk, kanskje?" },
            { "L3_P3",       "En ting er sikkert: Landet vi er i, er gode på mat! Aubergine, kikerter, lammekjøtt… men svinekjøtt så jeg ikke der. Jeg tipper de har gode søtsaker også!" }
        };

    public static void SetAccess(int access, params string[] notes)
    {
        foreach (var note in notes)
        {
            NotesAccess[note] = access;
        }
    }

    public static int GetAccess(string name)
    {
        return NotesAccess[name];
    }

    public static string GetNote(string key)
    {
        return NotesText[key];
    }

    public static string[] GetLevelKey(int level)
    {
        if (level <= 3)
        {
            List<string> keys = new List<string>();
            for (int i = 0; i < ((level - 1) * 3); i++)
            {
                keys.Add(PuzzleKeys[i]);
            }
            for (int i = 0; i < (level); i++) {
                keys.Add(LevelKeys[i]);
            }
            return keys.ToArray();
        }
        else
        {
        return LevelKeys;
        }

    }

    public static string[] GetPuzzleKey(int level, int puzzle)
    {
        List<string> keys = new List<string>();
        for (int i = 0; i < ((level - 1) * 3 + puzzle); i++)
        {
            keys.Add(PuzzleKeys[i]);
        }
        return keys.ToArray();
    }
}
