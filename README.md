# Password-Generator
Password Generator using different methods of randomization that user can select.

The form was designed using windows forms. The application allows users to generate passwords of a set length or a default length of 8. User can set the length of the password and can also enter in a string to have the program randomize into a password for them. 






![image](https://user-images.githubusercontent.com/47538097/166158734-b9fd5ca1-fd78-47ca-99bf-80780dd93908.png)




The first selection for randomization uses a simple replace method in C# to replace certain letters with symbols and then runs them through a randomization function to scramble the text. 

The "enter custom string" button will bring up a window that allows the user to enter in a custom string. Once the string is entered the program will run that through the random method. Using this will ignore a custom string length. 

Currently the save and load buttons will save passwords to a SQL database I built but the code can be modified to use a different SQL database connection if necessary.

Future Changes:

- Implement an export feature to export the items saved in the database to an excel document. 
- Implement different methods of randomization for strings entered by users. 
