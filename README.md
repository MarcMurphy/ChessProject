# Marks Notes README

I'm going to use this space to explain some of the decisions I made

As per the spec, the submission only handles the movement of Pawns (and Knights, which I added to verify the code structure), with no capturing implemented.
I believe with the implemented design, implementing new pieces is straight forward
	* Create class which inherits from BasePiece
	* Update PieceValidMoveCalculator with a new function for the PieceType
It took less than 10 minutes to implement a basic Knight class.

The console window is playable.
You can enter two coordinates, and the piece will move there if it's a valid move.
e.g. the input 'a7 a5' will move the pawn on a7 to a5, because the pawn can initially move two squares. The input 'b8 c6' will move the night on B8 to B6.
Note that the rendering code was just put in as a proof of concept and the code is rather messy due to having to change the console text colour constantly to make it visually appealing.

Design decisions I made
1. Removed 'ChessBoard' member variable from Pawn
	* A design where Pawn (or BasePiece in my code) does not know about the entire ChessBoard greatly reduces coupling.
2. Gutted 'Move' function in Pawn
	* Having Pawn move itself seemed weird considering the Add function was in ChessBoard. ChessBoard now controls the pieces movement, with the BasePiece function only updating a bool for HasMoved
3. Removed Limits_The_Number_Of_Pawns unit test in ChessBoard_Tests.cs
	* Made the function private and removed the Test tag. Left a comment with an explanation, essentially test is not valid.
4. Installed Moq for my own unit tests of PieceValidMoveCalculator_Tests
	* Installing Moq allowed my to assume IsLegalBoardPosition is always true. Because IsLegalBoardPosition is being tested elsewhere, it is safe to assume it will always be true in here if it's own unit tests are working
5. Refactored ChessBoard_Tests LegalPosition tests to use the TestCase tag
	* Saves lots of space, removes duplication
6. Changed ChessBoard.Add suggested implementation of setting the coordinate to (-1,-1)
	* Setting it to (-1,-1) seemed like a bad way of checking it was successful, changed to return a ValidationResult with a success boolean and appropriate error message
7. Refactored all the 'xCoordinate / yCoordinate' references to use built in 'Point' class
	* Saves on number of parameters everywhere, looks cleaner

Possible obstacles worth considering in future
1.	Only allow pieces to move in alternating colours
	*	Add a Player class, assign each player a colour. Use an IsTurn property to allow movement
2. 'Replay famous chess games' mentionned in spec
	* With a little extension on the coordinate parser provided, it should be straight forward to read in inputs to setup a default board position.	