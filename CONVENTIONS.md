# Code conventies
## Dont repeat yourself ##
### Example:

    Console.Writeline("1");             
    Console.Writeline("2");
    Console.Writeline("3");
    Console.Writeline("4");


## PascalClass for classes and singletons ##
### Example:
    
   public class PlayerName
   {

   }

## camelCase for variables, functions, and members.
### Example:

    public class Man
    {
        private firstName;
    }
    

## Code in english.

### Example:


    public string Naam {}; this is wrong.
    public string Name{}; This is right.

## Variables with the right name.

## Example:

    const a = 23;
    const dunno = 'Jantje';

    function do() {
        if (a < 18) {
        alert('to bad...' + dunno);
     }
    }   
    
    This code is not right because i dont no what  a and dunno for stand. make every name clear what i meant to do.


## use singular for classes

### Example:

    public class Drinks{
        
    } is wrong
    public class Drink{

    } is right