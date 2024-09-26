Module Module1

    'Tanmay Sharma
    '12/12/2022
    'Rubber Duck Debugging

    'Code For Pausing = Threading.Thread.Sleep(1000)

    'different responses that the computer/duck chooses from
    Dim response() As String = {"I see", "Oh, that's a good one", "Intresting", "I've heard of that before"}
    Dim rand As New Random

    'variables for the log board
    Dim googleResponse1, googleResponse2, googleResponse3 As String
    Dim askSomeone, someoneSay As String

    Sub Main()
        Dim sleepTimer As Integer = 1000
        Dim random1 As Integer = rand.Next(0, 3)
        Dim random2 As Integer = rand.Next(0, 3)
        'keeps looping through random numbers until the two random runbers are different from one another
        While random2 <> random1
            random2 = rand.Next(0, 3)
        End While

        'gets the problem
        printDuck()
        Dim finalProblem As String = problem(random1)
        Threading.Thread.Sleep(sleepTimer)
        Console.Clear()

        'checks if the program is crashing
        printDuck()
        Dim FinalCrashing As String = crashing()
        Threading.Thread.Sleep(sleepTimer)
        Console.Clear()

        'gets the google searches and stores them in global variables
        printDuck2()
        googleSearch()
        Threading.Thread.Sleep(sleepTimer)
        Console.Clear()

        'gets a rephrased problem
        printDuck2()
        Dim rephrasedResponse As String = rephrase(random2)
        Threading.Thread.Sleep(sleepTimer)
        Console.Clear()

        'gets the name of the person asked and what they said, storing both inputs in global variables
        printDuck3()
        askAnyone()
        Threading.Thread.Sleep(sleepTimer)
        Console.Clear()

        'gets the final problem again (last time)
        printDuck3()
        Dim finalProblemAgain As String = problemAgain()
        Threading.Thread.Sleep(sleepTimer)
        Console.Clear()

        'prints the log board using a bunch of arguments and data stored in the global variables
        printDuck()
        helpBoardLog(finalProblem, FinalCrashing, rephrasedResponse, finalProblemAgain)

    End Sub

    ''' <summary>
    ''' prints duck every time so the console.clear doesn't get rid of it
    ''' </summary>
    Sub printDuck()
        Console.WriteLine("
               ,,,,,,,,,,,,
            ******************
          .***///////////////**
          //&@@(/((((((((/(@@(/*
          //@@@(((((((((((#@@@//
          ///(((((##((##(((((///
         **///####((///(###(///
     *****/////(#####%%&%#((////***.
   ******/////(((((((((((((((////*****
   ///////////((((######((((///////////
   //////////(((((#####((((((/////////
     //////(((((((((((((((((((//////*
     */////((((((((((((((((((((/////
       ////((((((((((((((((((((///,
           .((((((((((((((((((/
             
        ")
    End Sub
    ''' <summary>
    ''' another duck
    ''' </summary>
    Sub printDuck2()
        Console.WriteLine(" 

            ,,,,,,,,,, 
        .**************** 
       ******************** 
      /////////////////////* 
      ////////@@@@@/////////,**** 
      /((/((((((((((((//////******** 
    //(//(((((#(((((((//////********* 
      /%%%%%%%%#((((((((////********** 
    .*//((((((###(((//////////******** 
    ////((((((((//////////////**////// 
    /////(((((///////////////////////* 
    //////////(((((((/(/////(((/////* 
     ////////(((((((((((((///////// 
        ////(((((((((((((((///((( 
              ((((((((((( 


")
    End Sub
    ''' <summary>
    ''' a thrid duck
    ''' </summary>
    Sub printDuck3()
        Console.WriteLine(" 

               ,,,,,,,,,,,, 
            ****************** 
          .***///////////////** 
          //&@@(/((((((((/(@@(/* 
          //@@@(((((((((((#@@@// 
          ///(((((##((##(((((/// 
         **///####((///(###(/// 
     *****/////(#####%%&%#((////***. 
   ******/////(((((((((((((((////***** 
   ///////////((((######((((/////////// 
   //////////(((((#####((((((///////// 
     //////(((((((((((((((((((//////* 
     */////((((((((((((((((((((///// 
       ////((((((((((((((((((((///, 
           .((((((((((((((((((/ 

 
")

    End Sub

    ''' <summary>
    ''' prompts the user for a problem and returns it
    ''' </summary>
    ''' <param name="rand"></param>
    ''' <returns></returns>
    Function problem(rand As Integer)
        Dim input As String = CheckIfValidInput("What is the problem you are facing? Please try to be specific. -> ")
        Console.WriteLine(response(rand))
        Return input
    End Function

    ''' <summary>
    ''' asks the user if the program is crashing and returns wether it is or not
    ''' </summary>
    ''' <returns></returns>
    Function crashing()
        Dim response As String = CheckIfValidInput("Is the program crashing? (y/n) -> ")
        response = response.ToLower()
        'asks for stack trace error if the program is crashing
        If response = "y" OrElse response = "yes" Then
            Dim stackTraceError As String = CheckIfValidInput("What is the error from stack trace? ")
            Dim response2 As String = ""
            Dim url As String = ""
            url = "https://www.google.com/search?q=" & stackTraceError
            Process.Start(url)
            'makes sure the user looked at the opened google search window
            Do
                response2 = CheckIfValidInput("I opened up the stack trace error on Google, did you look at it? (y/n) -> ")
                response2 = response2.Trim.ToLower
            Loop While response2 = "n" OrElse response2 = "no"
        End If
        Return response
    End Function

    ''' <summary>
    ''' asks the user for google searches and stores them in global variables
    ''' </summary>
    Sub googleSearch()
        googleResponse1 = CheckIfValidInput("What searches did you try in Google? Tell me 3 -> ")
        googleResponse2 = CheckIfValidInput("That's one, what other terms did you try? ")
        Console.Write("And one more? ")
        googleResponse3 = CheckIfValidInput("And one more? ")
        Console.WriteLine("I'm suprised those didn't help")
    End Sub



    ''' <summary>
    ''' asks the user for a rephrased problem and then returns it
    ''' </summary>
    ''' <param name="rand"></param>
    ''' <returns></returns>
    Function rephrase(rand As Integer)
        Dim response2 As String = CheckIfValidInput("Can you try to rephrase the problem for me? Tell me what is happening before the problem occurs? ")
        Console.WriteLine(response(rand))
        Return response2
    End Function

    ''' <summary>
    ''' gets the name of the person the user asked and what they said, storing them in global variables
    ''' </summary>
    Sub askAnyone()
        askSomeone = CheckIfValidInput("Who else did you ask about this problem? ")
        someoneSay = CheckIfValidInput("What did they say? ")
        Console.Write("Hmmmm")
        'prints 3 dots to show that the duck is thinking
        For i As Integer = 0 To 2
            Threading.Thread.Sleep(500)
            Console.Write(".")
        Next
    End Sub

    ''' <summary>
    ''' prompts the user for a problem again and returns it
    ''' </summary>
    ''' <returns></returns>
    Function problemAgain()
        Dim response As String = CheckIfValidInput("What exactly is the problem again? ")
        Return response
    End Function

    ''' <summary>
    ''' prints out the help board using arguments and global variables
    ''' </summary>
    ''' <param name="probDescrip"></param>
    ''' <param name="crashing"></param>
    ''' <param name="probRephrased"></param>
    ''' <param name="probAgain"></param>
    Sub helpBoardLog(probDescrip, crashing, probRephrased, probAgain)
        Console.WriteLine("Okay, you better get Mr. Klins, here's the log for the help board: ")
        Console.WriteLine()
        Console.WriteLine("Problem description: " & probDescrip)
        Console.WriteLine("Crashing?  " & crashing)
        Console.WriteLine("Google searches: ")
        Console.WriteLine("1. " & googleResponse1)
        Console.WriteLine("2. " & googleResponse2)
        Console.WriteLine("3. " & googleResponse3)
        Console.WriteLine()
        Console.WriteLine("Problem rephrased, with steps leading up to it: " & probRephrased)
        Console.WriteLine("Person who helped: " & askSomeone)
        Console.WriteLine("What they said: " & someoneSay)
        Console.WriteLine("The problem again: " & probAgain)
        Console.WriteLine()
    End Sub

    ''' <summary>
    ''' makes sure the user provides a response, otherwise the prompt is repeated
    ''' </summary>
    ''' <param name="prompt"></param>
    ''' <returns></returns>
    Function CheckIfValidInput(prompt As String)
        Dim userInput As String
        Do
            Console.Write(prompt)
            userInput = Console.ReadLine()
        Loop While userInput = ""
        Return userInput
    End Function

End Module
