using System;
using static System.Console;

class GamesRecord
{
    int gamesRecordSize;
    string[,] gamesRecord;
    int gamesRecordCurrentIndex;
    int gamesRecordCurrentSize;


    public GamesRecord(int recordSize = 2)
    {
        try
        {
            gamesRecordSize = recordSize;
            gamesRecord = new string[gamesRecordSize, 3];
        }
        catch (OverflowException e)
        {
            WriteLine("OverflowException during GamesRecord initialization: \"{0}\"\nrecordSize given was [{1}]\nSetting recordSize to 10", e.Message, recordSize);
            gamesRecordSize = 10;
            gamesRecord = new string[gamesRecordSize, 3];
        }
        gamesRecordCurrentIndex = 0;
            gamesRecordCurrentSize = 0;
        
    }
    public static GamesRecord operator +(GamesRecord a, GamesRecord b)
    {
        int displayRecordIndex;

        if (b.gamesRecordCurrentSize < b.gamesRecordSize) displayRecordIndex = 0;
        else displayRecordIndex = b.gamesRecordCurrentIndex;

        if (a.gamesRecordCurrentSize+ b.gamesRecordCurrentSize > a.gamesRecordSize)
        { 
            GamesRecord Ap = new GamesRecord(a.gamesRecordCurrentSize + b.gamesRecordCurrentSize);
            for (int i = 0; i < a.gamesRecordCurrentSize; i++)
            {
                Ap.AddRecord(a.gamesRecord[i, 0],
                            a.gamesRecord[i, 1],
                            a.gamesRecord[i, 2]);
            }
            Ap.gamesRecordCurrentIndex = a.gamesRecordCurrentIndex;
            Ap.gamesRecordCurrentSize = a.gamesRecordCurrentSize;
            a = Ap;
        }
        for (int i = 0; i < b.gamesRecordCurrentSize; i++)
        {
            a.AddRecord(b.gamesRecord[displayRecordIndex, 0],
                        b.gamesRecord[displayRecordIndex, 1],
                        b.gamesRecord[displayRecordIndex, 2]);
            displayRecordIndex = (displayRecordIndex + 1) % b.gamesRecordCurrentSize;
        }
        return a;
    }


    public void AddRecord(string playerOneChoice, string playerTwoChoice, string result)
    {
        gamesRecord[gamesRecordCurrentIndex, 0] = playerOneChoice;
        gamesRecord[gamesRecordCurrentIndex, 1] = playerTwoChoice;
        gamesRecord[gamesRecordCurrentIndex, 2] = result;
        gamesRecordCurrentIndex = (gamesRecordCurrentIndex + 1) % gamesRecordSize;
        if (gamesRecordCurrentSize < gamesRecordSize)
        {
            gamesRecordCurrentSize++;
        }
    }
    public void DisplayGamesHistory()
    {
        int displayRecordIndex;
        if (gamesRecordCurrentSize < gamesRecordSize)
        {
            displayRecordIndex = 0;
        }
        else
        {
            displayRecordIndex = gamesRecordCurrentIndex;
        }
        WriteLine("Last games history:");
        for (int i = 0; i < gamesRecordCurrentSize; i++)
        {
            WriteLine("Game #{0}:\t{1}\t-\t{2},\t{3}", i + 1, gamesRecord[displayRecordIndex, 0],
            gamesRecord[displayRecordIndex, 1], gamesRecord[displayRecordIndex, 2]);
            displayRecordIndex = (displayRecordIndex + 1) % gamesRecordCurrentSize;
        }
    }


}