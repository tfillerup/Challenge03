/**
 * Created with IntelliJ IDEA.
 * User: Kevin Burnett
 * Date: 12/2/14
 * Time: 5:21 PM
 * To change this template use File | Settings | File Templates.
 */
import java.lang.*;

public class Program {

    /* Search for all the numbers in a string, add them together, then return that final number divided by the total
     * amount of letters in the string. For example: if the string is "Hello6 9World 2, Nic8e D7ay!" the output should
     * be 2. First if you add up all the numbers, 6 + 9 + 2 + 8 + 7 you get 32. Then there are 17 letters in the string.
     * 32 / 17 = 1.882, and the final answer should be rounded to the nearest whole number, so the answer is 2.
     * You may have multi digit numbers as well as negative numbers so be sure to handle those as well.
     * Code
     */

    public static void main(String args[])
    {
        String entries = "Hello6 9World 2, Nic8e D7ay!";
        Calculate(entries);
    }

    static void Calculate(String entries)
    {
        double charCounter = 0;
        double totalNum = 0;

        for (int j = 0; j < entries.length(); j++)
        {
           char c = entries.charAt(j);

            //Check for number
            if (c > 48 && c < 58)
            {
                //totalNum = totalNum + Integer.valueOf(c);
               totalNum = totalNum + Character.getNumericValue(c);
            }
            //Check for character
            else if ((c > 64 && c < 91) || (c > 96 && c < 123))
            {
                charCounter = charCounter + 1;
            }
        }
        //Final computation
        double result = Math.round(totalNum / charCounter);

        System.out.print("Original String: " + entries);
        System.out.print("\n");
        System.out.print("Result: " + result);
    }
}

