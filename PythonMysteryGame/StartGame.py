#   StartGame.py
import HelperFunctions.GamePrep as GamePrep
import HelperFunctions.General as General

playPrompt = "Do you want to play?: "
response = General.validatingInput(playPrompt, ["yes", "no"])
playPrompt = "Do you want to play again?: "
playing = General.playCheck(response)

while( playing ):
    GamePrep.resetBoard()
    GamePrep.startMysteryGame()
    playing = General.playCheck(General.validatingInput(playPrompt, ["yes", "no"]))
