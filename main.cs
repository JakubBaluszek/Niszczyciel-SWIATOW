using System;
using static System.Console;
class MainClass {

static void DisplayWelcomeMessage (){
  WriteLine ("Witaj graczu, opowiemy ci historię");
}

static string GetPlayerInput (){
  // wnętrze funkcji
  string rawInput;
  string properInput="";
  WriteLine ("Doktor Biceps prosze podac swoj typ:\n(1) kamien\n(2) papier\n(3) nozyce");
  rawInput = ReadLine();
while (rawInput != "1" && rawInput != "2" && rawInput != "3") {
    WriteLine ("ZLY WYBOR!!! Doktor Biceps prosze podac swoj typ:\n(1) kamien\n(2) papier\n(3) nozyce");
    rawInput = ReadLine();
  if (rawInput == "1") { properInput = "Rock"; }
  else if (rawInput == "2") { properInput = "Paper"; }
  else { properInput = "Scissors"; }
}
return properInput;

}
static string DetermineWinner (string wyborpierwszegogracza, string wybordrugiegogracza)
{
     if (wyborpierwszegogracza == wybordrugiegogracza){
          WriteLine ("Remis");         return "nie przelala sie krew";}
      if (wyborpierwszegogracza == "1" && wybordrugiegogracza == "2")
        {
          WriteLine ("wygral Doktor Biceps");  return "Doktor Biceps obronil swe wlosci";
        }
      if (wyborpierwszegogracza == "1" && wybordrugiegogracza == "3")
        {
          WriteLine ("wygral PlayerONE");      return "playerone destroy the game";
        }
      if (wyborpierwszegogracza == "2" && wybordrugiegogracza == "1")
        {
          WriteLine ("wygral PlayerONE");      return "playerone destroy the game";
        }
      if (wyborpierwszegogracza == "2" && wybordrugiegogracza == "3")
        {
          WriteLine ("wygral Doktor Biceps");  return "Doktor Biceps obronil swe wlosci";
        }
      if (wyborpierwszegogracza == "3" && wybordrugiegogracza == "1")
        {
          WriteLine ("wygral Doktor Biceps");  return "Doktor Biceps obronil swe wlosci";
        }
      if (wyborpierwszegogracza == "3" && wybordrugiegogracza == "2")
        {
          WriteLine ("wygral PlayerONE");      return "playerone destroy the game";
        }
        
       else return "pokwasiorilo sie";
      
}
static void DisplayGamesHistory (string[,] gamesRecord, int gamesRecordSize, int gamesRecordCurrentSize = 10, int lastRecordIndex = 0){
  
int currentIndex;
if (gamesRecordCurrentSize < gamesRecordSize){
  currentIndex = 0;
}
else {
  currentIndex = lastRecordIndex;
}
WriteLine ("Last games history:");
for (int i = 0; i < gamesRecordCurrentSize; i++){
  WriteLine ("Game #{0}:\t{1}\t-\t{2},\t{3}", i+1, gamesRecord[currentIndex,0], gamesRecord[currentIndex,1], gamesRecord[currentIndex,2]);
  currentIndex = (currentIndex + 1) % gamesRecordCurrentSize;
}
/*
  for (int i = 0; i < gamesRecordCurrentSize; i++)
    {
      int currentIndex;
      if (gamesRecordCurrentSize < gamesRecordSize){
        currentIndex = 0;
      }
      else {
        currentIndex = gamesRecordCurrentIndex;
      }
      
      Console.WriteLine ("Gra #{0}: {1} - {2}, wygrał gracz {3}",
        i+1, gamesRecord[currentIndex,0], gamesRecord[currentIndex,1], gamesRecord[currentIndex,2]);
     }
 */
}


 
public static void Main (string[] args) {
      DisplayWelcomeMessage ();

      int gamesRecordSize = 10;
      string[,] gamesRecord = new string[gamesRecordSize,3]; 
      int gamesRecordCurrentIndex = 0;
      int gamesRecordCurrentSize = 0;

      do {
                  
          string wyborpierwszegogracza = GetPlayerInput();
          gamesRecord[gamesRecordCurrentIndex, 0] = wyborpierwszegogracza;

          string wybordrugiegogracza = GetPlayerInput();
          gamesRecord[gamesRecordCurrentIndex, 1] = wybordrugiegogracza;
      
        ReadKey();
        Clear();

        gamesRecord[gamesRecordCurrentIndex, 2] = DetermineWinner(wyborpierwszegogracza,wybordrugiegogracza);

        gamesRecordCurrentIndex = (gamesRecordCurrentIndex + 1) % gamesRecordSize; 

      if (gamesRecordCurrentSize < gamesRecordSize)
        {
          gamesRecordCurrentSize++;
        }


      Console.WriteLine ("Doktor Biceps, czy chcesz się znowu upokorzyć? Wpisz PB żeby walczyć o czarne złoto");
      
    
      }while (Console.ReadLine() != "PB");
       DisplayGamesHistory (gamesRecord, gamesRecordSize, gamesRecordCurrentSize, gamesRecordCurrentIndex);


    
      
}
}