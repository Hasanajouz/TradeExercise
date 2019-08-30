# TradeExercise
An Exercise for digistrat consulting

Here is a small documentation covering the steps I made to finish this exercise.

The purpose of this exercise is to Accept or Reject trades grouped by CorrelationID based on a limit.  

# MVVM Architecture in this project
As this is a small app, I should have used models, views and viewmodels inside the same project.
But I decided to add them in separate projects because I want to show how big projects hould be architectured.
When you develop big projects then a small folder to handle models or view models will not be a good practice, especially if you are going to reuse this code in other projects.

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/projects.jpg)

# Model
In this app there will be only one model to handle everything I called it: BlacksCholes

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/model.jpg)

# Calculations
all the calculations will be in the helper projects.
there will be two files
1- BlacksCholesCalculator.cs to calculate the pricing using Blacks Choles way.
2-NormalDistributionHelper to calculate the normal distribution because it is used in one of the formulas of calculating the call price.
I tried more than one method to calculate Normal Distribution because i was searching for one which gives the more accurate result.
I found one in the internet that passed all my tests to give exact the same results as the suggested website.

# Unit Testing
As it is a small app, I made unit testing with ms unit testing.
It is just simple values check.
And I tried to cover all fields and methods with my tests

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/unitTest.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/function_tested.jpg)

# View Model
After all the tests went well. I started to implement the UI.
So, I started with the view model.
I created the base view model which all the view models will inherit from.
It handles all common properties and specially the "PropertyChangedEventHandler"
and I created a basic class to inherit from ICommand to handle commands. it is called “DelegateCommand"

# UI and Binding
After I created the view main page.
And I tried to show small example about local styles.
![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/binding.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/empty_ui.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/ui_with_error_message.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/ui_example_1.jpg)




 




