# TradeExercise
An Exercise for digistrat consulting

Here is a small documentation covering the steps I made to finish this exercise.

The purpose of this exercise is to Accept or Reject trades grouped by CorrelationID based on a limit.

**About the Program**

-type: WPF

-Architecture: MVVM

-Testing: MS unit test

-Logging: log4net

-Style: Dark Mode

**Note:** the only third party library used is Log4net. Everything else it written by me.

**Note:** I tried to show a little from everything: UI, Architecture...

**Note:** The app is not well optimized for memory consumption due to lack of time.

**Note:** open file dialog removed because it is using win32 library which needs to be loaded manually. So i decided to remove it so the code will work directly when you download it as zip file. So please just enter the file path manually. 


# MVVM Architecture in this project
As this is a small app, I should have used models, views and viewmodels inside the same project.

But I decided to add them in separate projects because I want to show how the architecture should be in big projects.

When you develop big projects then a small folder to handle models or view models will not be a good practice, especially if you are going to reuse this code in other projects.

![alt text](https://raw.githubusercontent.com/hasanajouz/TradeExercise/master/Images/Projects.jpg)

# Models
There are more than one model in this program.

-Trade is a class with some XML attributes to represent the data from the XML file

-TradeResult is a class to represent the final result. One of its properties is the State.

-State is and enum with three options (Pending, Rejected, Accepted)

and some other helping models.

# Helpers
In helpers project we can find all the classes related to:

1-XMLHelper: to deal with everything about XML.

2-CSVHelper: to deal with everything related to CSV.

3-LogicHelper: to make all the trades logic and calculate the state.

4-Logger: it has an interface to deal with Log4net logger and created my own simple class to register logs.

5-MockDataStore: to create simple data to be used in the testing.

# Unit Testing
As it is a small app, I made unit testing with ms unit testing.

It is just simple values check.

And I tried to cover all fields and methods with my tests

![alt text](https://raw.githubusercontent.com/hasanajouz/TradeExercise/master/Images/tests1.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/TradeExercise/master/Images/tests2.jpg)

# Special Cases
I tried to cover some cases to check the list of trades before processing.

It should be changed because it takes more memory and cpu.

I just added it to show some of my analysis skills.

For example: if there is more than a row with the same TradeID.

or one of the groups of CorrelationId doesn't have the same limit or number of trades.

or there are more trades than the number of trades.

Those are all logical mistakes.

So i checked them in the app and i made tests to check them.

# Log4net
It is one of the best loggers for .net projects.

The file is saved as "server.log" on the same path as the exe path.

I dealt with different types of log: errors, exceptions, info...

What I didn't cover in this app is the global exception handling.


# View Model
After all the tests went well. I started to implement the UI.

So, I started with the view model.

I created the base view model which all the view models will inherit from.

It handles all common properties and specially the "PropertyChangedEventHandler"

and I created a basic class to inherit from ICommand to handle commands. it is called “DelegateCommand"

![alt text](https://raw.githubusercontent.com/hasanajouz/TradeExercise/master/Images/viewmodels.jpg)



# UI and Binding
After, I created the view main page.

And I tried to show small example about local styles.

![alt text](https://github.com/Hasanajouz/TradeExercise/blob/master/Images/localstyles.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/TradeExercise/master/Images/ui1.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/TradeExercise/master/Images/ui2.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/TradeExercise/master/Images/error.jpg)





 




