# Tower 

It is a puzzle game like Sudoku.

![Image Image](https://raw.githubusercontent.com/KDevZilla/ImageUpload/main/TowerPuzzle/2024_02_05_01_26_00_Tower.png)  

# How to Play


1. Every cell must be filled with a number. The number represents the height 
of the Tower. 
If the board size is 4x4,  
the valid number is 1,2,3,4 (The number from 1 to the size of the board)

2. The number of the cell cannot be duplicated in each row and each column.

3. If you look in the direction of the arrow, 
the number in the arrow at the side of the board 
indicates how many Towers you can see from the point of the arrow.

4. To make the number of Towers you can see 
match the value in an arrow, you must enter 
the appropriate number in the column.

Sample

![Image Image](https://raw.githubusercontent.com/KDevZilla/Resource/main/SkyCraperScreen_HowtoPlay.png)

This image shows the correct value of all of the cells on the board.
The blue rectangle shows that the value in an arrow is 1 because when you 
look from the arrow position you can only see the 4-story Tower.

The same with the green and the orange ones. For the green one, you can see
2 and 4 you so totally you can see 2 Tower 

For the Red one, you can see 1, 2, 3, 4 that's why the value in an arrow is 4

# How to set up a project
1. Just download a project, it is just a small program written in C# Windows Form.
2. There are 2 projects\
      Tower : This is the main project\
      Tower Test: This it the test project
3. For testing the project, you can just run The test cases in IntegrateTest.class
4. This project requires AppInfo folder in same folder of Tower .exe, you no need to do anything
   because visual studio will copy the folder into the build folder.

